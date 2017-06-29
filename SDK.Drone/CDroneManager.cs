using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SDK.Comm;
using System.IO;

namespace SDK.Drone
{
	public struct SGeoLoc
	{
		public double lat;
		public double lng;
		public double alt;
		public double altFromGround;
		public double heading;
    }

	public struct SMissionItem
	{
		public MAVLink.MAV_CMD command;
		public double lat;
		public double lng;
		public double alt;

        public MAVLink.MAV_FRAME frame;

        public float p1;				// param 1
        public float p2;				// param 2
        public float p3;				// param 3
        public float p4;				// param 4

        public bool IsHome;

        public SMissionItem Set(double lat, double lng, double alt, MAVLink.MAV_CMD command, bool isHome = false)
        {
            this.lat = lat;
            this.lng = lng;
            this.alt = (float)alt;
            this.command = command;
            IsHome = isHome;

            return this;
        }
        public static SMissionItem Create(double lat, double lng, double alt, MAVLink.MAV_CMD command, bool isHome = false)
        {
            return new SMissionItem().Set(lat, lng, alt, command, isHome);
        }
	}
    public struct SMission
    {
        public List<SMissionItem> Items;
        public string Name;

        public SMission(string name)
        {
            Items = new List<SMissionItem>();
            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }

    class TargetCandidate
    {
        public  int    NumberOfTrackedFrames { get; set; }
        public  double DetectionRatioThreshold { get; set; }
        public  int    DetectionCount { get; set; }
        //public  int    NoDetectionCount { get; set; }
        public int LastFrameDetected { get; set; }
        public  bool   Detection  { get; set; }
        public  int    ID { get; set; }
    }

    //class CollInit
    //{
    //    Dictionary<int, TargetCandidate> TargetCandidateד = new Dictionary<int, TargetCandidate>()
    //            {
    //                { 1, new TargetCandidate {FirstName="Sachin", LastName="Karnik", ID=211}},
    //                { 112, new StudentName {FirstName="Dina", LastName="Salimzianova", ID=317}},
    //                { 113, new StudentName {FirstName="Andy", LastName="Ruth", ID=198}}
    //            };
    //}
  
    public static class CDroneManager
    {
        // Debug
        private static bool debugLoadPacketsFromFile = false;
        // /Debug

        public static CUnmanagedComm Comm;
		private static MAVLink.MavlinkParse mavlink = new MAVLink.MavlinkParse();

		private static Dictionary<Type, ManualResetEvent> packetsWaitedOn = new Dictionary<Type, ManualResetEvent>();

        private static Thread asyncThread;
        private static bool threadBusy;

        //public static int numberOfTrackedFrames = 0;
        //public static double detectionRatioThreshold = 0.4;
        //public static int detectionCount = 0;
        //public static int noDetectionCount = 0;
        //public static bool detection = false;

		// Drone parameters
		static byte sysID = 255;
		static byte compID = 255;

        static DateTime lastForceTakeoff;

		// Activity Parameters
		static int moveSpeed = 1;
        private static MAVLink.MAV_STATE droneState;
        public static MAVLink.MAV_STATE DroneState
        {
            get { return droneState; }
        }

        public static bool DroneReady
        {
            get { return droneReady; }
        }
        private static bool droneReady = false;

		static APMModes.Quadrotor mode;

        static APMModes.Quadrotor lastMode;
		public static APMModes.Quadrotor Mode
		{
			get { return mode; }
		}

        public static APMModes.Quadrotor LastMode
        {
            get { return lastMode; }
        }

		static int missionWaypointsCount = 0;
		static SGeoLoc dronePosition;

        // EKF status
        public static float EKFStatus;
        public static int EKFFlags;

		// GPS Parameters
		public static SGeoLoc DronePosition
		{
			get { return dronePosition; }
		}
		public static double GPSHdop = 0;
        static int satCount;
        public static int GPSSatelliteCount { get { return satCount; } }


		static SMissionItem[] missionItems;
		public static List<SMissionItem> MissionItems
		{
			get {
                List<SMissionItem> list = null;
                if (missionItems != null)
                    list = new List<SMissionItem>(missionItems); 
                
                return list; }
                
		}

		// Events
		public delegate void PacketDelegate(object packet, int sysId, int compId);
        public static event PacketDelegate OnPacketReceived;
        public static event Action<byte[], int, int> OnPacketSent;
        public static event Action<string, double, int> OnParamUpdate;

        public static event Action<string> OnError;

		public static event Action<int, int> OnMissionUpdated;
        public static event Action<int, int> OnMissionWritten;

        public static event Action<bool> OnDroneReady;

        public static bool ReachedPoint(double lat, double lng)
        {
            double dist = CDroneUtilities.GPSPointsDistance(lat, lng, DronePosition.lat, DronePosition.lng);
            return (Math.Abs(dist) < 2);
        }


        public static void UpdateNoBlobFound()
        {
 
        }



        public static void Initialize(CUnmanagedComm comm)
        {
            Comm = comm;
			Comm.OnPacket += Comm_OnPacket;
         
            dronePosition = new SGeoLoc()
            {
                lat = 32.168141,
                lng = 34.808755,
                alt = 0,
                altFromGround = 0,
                heading = 0
            };


            // Debug Serialization
            if (debugLoadPacketsFromFile)
            {
                // Load packets from file - Debug 
                CMavlinkDeserialization.Initialize("mavlink-serialization.log");
                //CMavlinkDeserialization.Initialize("Logs/cementary-mission.log");
                CMavlinkDeserialization.OnPacket += CMavlinkDeserialization_OnPacket;
            }
            else
            {
                // Save packets to file - For later debug purposes
                CMavlinkSerialization.Initialize("mavlink-serialization.log");
            }
		}

        static void CMavlinkDeserialization_OnPacket(byte[] obj)
        {
            // Debug mavlink
            MemoryStream stream = new MemoryStream(obj);
            stream.Position = 0;
            Comm_OnPacket(stream);
        }

        private static bool SendPacket(byte[] packet, int sysId=-1, int compId=-1)
        {
            bool success = false;

            if (Comm == null)
                return success;

            if (OnPacketSent != null)
                OnPacketSent(packet, sysId, compId);

            success = Comm.Write(packet);
            if (!success)
                if (OnError != null)
                    OnError("Error sending command");

            return success;
        }
		private static void Comm_OnPacket(System.IO.Stream stream)
		{
			object packet;
            byte tempSysId = 0;
            byte tempCompId = 0;

            // Save the packet to file
            if (!debugLoadPacketsFromFile)
                CMavlinkSerialization.SavePacket(stream);

			packet = mavlink.ReadPacket(stream, out tempSysId, out tempCompId);

            if ((sysID == 255) || (compID == 255))
            {
                sysID = tempSysId;
                compID = tempCompId;
            }

			while (packet != null)
			{
				HandlePacket(packet);

				// Check if someone is waiting for a packet
				if (packetsWaitedOn.ContainsKey(packet.GetType()))
				{
					// Trigger packet
					packetsWaitedOn[packet.GetType()].Set();
				}

                if (OnPacketReceived != null)
                    OnPacketReceived(packet, tempSysId, tempCompId);

                packet = mavlink.ReadPacket(stream, out tempSysId, out tempCompId);
			}
		}

		private static void HandlePacket(object packet)
		{
			if (packet.GetType() == typeof(MAVLink.mavlink_heartbeat_t))
			{
				MAVLink.mavlink_heartbeat_t parsed = (MAVLink.mavlink_heartbeat_t)packet;
                droneState = (MAVLink.MAV_STATE)parsed.system_status;
        
                //MAVLink.MAV_MODE
                mode = (APMModes.Quadrotor)parsed.custom_mode;
			}
			else if (packet.GetType() == typeof(MAVLink.mavlink_global_position_int_t))
			{
				MAVLink.mavlink_global_position_int_t gps = (MAVLink.mavlink_global_position_int_t)packet;
// 				dronePosition.lat = (double)gps.lat / 10000000;
// 				dronePosition.lng = (double)gps.lon / 10000000;
// 				dronePosition.alt = (double)gps.alt / 1000;
                dronePosition.altFromGround = (double)gps.relative_alt / 1000;
				dronePosition.heading = (double)gps.hdg / 100;
			}
			else if (packet.GetType() == typeof(MAVLink.mavlink_gps_raw_int_t))
			{
				MAVLink.mavlink_gps_raw_int_t gps = (MAVLink.mavlink_gps_raw_int_t)packet;
				GPSHdop = (double)gps.eph / 100;
                dronePosition.lat = (double)gps.lat / 10000000;
                dronePosition.lng = (double)gps.lon / 10000000;
                
                dronePosition.alt = (double)gps.alt / 1000;
                satCount = gps.satellites_visible;
                IsDroneReady();
            }
			else if (packet.GetType() == typeof(MAVLink.mavlink_mission_count_t))
			{
				MAVLink.mavlink_mission_count_t paramValue = (MAVLink.mavlink_mission_count_t)packet;
				missionWaypointsCount = paramValue.count;
				missionItems = new SMissionItem[missionWaypointsCount];
			}
			else if (packet.GetType() == typeof(MAVLink.mavlink_mission_item_t))
			{
				MAVLink.mavlink_mission_item_t paramValue = (MAVLink.mavlink_mission_item_t)packet;
				SMissionItem missionItem = new SMissionItem();
				missionItem.command = (MAVLink.MAV_CMD)paramValue.command;

// 				if (missionItem.command == MAVLink.MAV_CMD.TAKEOFF)
// 					// || (missionItem.command == MAVLink.MAV_CMD.RETURN_TO_LAUNCH))
// 				{
// 					missionItem.lat = dronePosition.lat;
// 					missionItem.lng = dronePosition.lng;
// 				}
// 				else
				{
					missionItem.lat = paramValue.x;
					missionItem.lng = paramValue.y;
				}
                missionItem.p1 = paramValue.param1;
                missionItem.p2 = paramValue.param2;
                missionItem.p3 = paramValue.param3;
                missionItem.p4 = paramValue.param4;

                missionItem.alt = paramValue.z;

                // Is this the home?
                missionItem.IsHome = (paramValue.seq == 0);

				missionItems[paramValue.seq] = missionItem;
			}
			else if (packet.GetType() == typeof(MAVLink.mavlink_mission_request_t))
            {
                MAVLink.mavlink_mission_request_t missionReq = (MAVLink.mavlink_mission_request_t)packet;

                SetMissionItem(missionReq.seq);
                IsDroneReady();
            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_param_value_t))
            {
                MAVLink.mavlink_param_value_t paramValue = (MAVLink.mavlink_param_value_t)packet;
                string name = ASCIIEncoding.ASCII.GetString(paramValue.param_id);
                name = name.Trim().Replace("\0", "");
                double val = paramValue.param_value;
                if (OnParamUpdate != null)
                    OnParamUpdate(name, val, paramValue.param_index);
            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_ekf_status_report_t))
            {
                MAVLink.mavlink_ekf_status_report_t ekf = (MAVLink.mavlink_ekf_status_report_t)packet;
                // Check that all estimations are good
                EKFStatus = (float)Math.Max(ekf.pos_vert_variance, Math.Max(ekf.compass_variance, Math.Max(ekf.pos_horiz_variance, Math.Max(ekf.pos_vert_variance, ekf.terrain_alt_variance))));              
                EKFFlags = ekf.flags;
                IsDroneReady();
            }
        }

        private static void IsDroneReady()
        {
            bool tempDroneReady = false;


            if (missionItems != null)
            {
                tempDroneReady =
                    (GPSSatelliteCount > 8) &&
                    (MissionItems.Count > 0) &&
                    (EKFFlags == 933);

                if (tempDroneReady != droneReady)
                    if (OnDroneReady != null)
                        OnDroneReady(tempDroneReady);
            }
            droneReady = tempDroneReady;
        }

		private static bool SendWaitRetry(byte[] packetToSend, Type packetToWaitFor, int timeout = 1000, int retries = 3, int sysId=-1, int compId=-1)
		{
            if (sysId == -1)
                sysId = sysID;
            if (compId == -1)
                compId = compID;

			// First, send
			SendPacket(packetToSend, sysId, compId);

			// Now, Wait for the return packet (retry for 8 times)
            while ((!WaitForPacket(packetToWaitFor, timeout)) && (retries > 0))
			{
				// Try again
                retries--;
                if (retries > 0)
                    SendPacket(packetToSend, sysId, compId);
			}

            return retries > 0;
		}	
		public static bool WaitForPacket(Type packetType, int timeoutMS = 1000)
		{
			// The packet list contains all the packet type that were seen
			// TODO: Should this be thread safe?
			if (!packetsWaitedOn.ContainsKey(packetType))
			{
				packetsWaitedOn.Add(packetType, new ManualResetEvent(false));
			}

			// Wait for 3 seconds
			bool result = packetsWaitedOn[packetType].WaitOne(timeoutMS);

			if (result)
				// Clean up for the next user
				packetsWaitedOn[packetType].Reset();

			return result;
		}

		public static void ReadParameterList()
		{
			MAVLink.mavlink_param_request_list_t req = new MAVLink.mavlink_param_request_list_t();
			req.target_system = 0;
			req.target_component = 0;

			byte[] bytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.PARAM_REQUEST_LIST, req);
			SendPacket(bytes, 0, 0);
		}

        public static void ReadParameterAsync(string name)
        {
            // Just start GetMission on a new thread
            Thread asyncThread = new Thread(() => ReadParameter(name, false));
            asyncThread.Start();
        }
        public static void ReadParameter(string name, bool retry = true)
        {
            byte[] paramID;
            MAVLink.mavlink_param_request_read_t req = new MAVLink.mavlink_param_request_read_t();
            req.target_system = 0;
            req.target_component = 0;

            if (CDatacenter.knownParametersIndex.ContainsKey(name))
            {
                paramID = ASCIIEncoding.ASCII.GetBytes("\0");
                Array.Resize(ref paramID, 16);
                req.param_id = paramID;
                req.param_index = (short)CDatacenter.knownParametersIndex[name];
            }
            else
            {
                paramID = ASCIIEncoding.ASCII.GetBytes(name + "\0");
                // I'm not sure why this is needed, but it is
                Array.Resize(ref paramID, 16);
                req.param_id = paramID;
                req.param_index = -1;
            }



            byte[] bytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.PARAM_REQUEST_READ, req);
            if (retry)
            {
                SendWaitRetry(bytes, typeof(MAVLink.mavlink_param_value_t));
            }
            else
            {
                SendPacket(bytes);
            }
        }
        public static void WriteParameter(string name, double val)
        {
            byte[] paramID;
            MAVLink.mavlink_param_set_t req = new MAVLink.mavlink_param_set_t();
            req.target_system = 0;
            req.target_component = 0;
            paramID = ASCIIEncoding.ASCII.GetBytes(name + "\0");
            // I'm not sure why this is needed, but it is
            Array.Resize(ref paramID, 16);
            req.param_id = paramID;
            req.param_value = (float)val;

            byte[] bytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.PARAM_SET, req);
            SendPacket(bytes);
        }

        public static void RequestDataStream(int streamId, int messageRate, int startStop)
        {
            // This is from the MissionPlanner. Don't change this code as this is written in BLOOD
            MAVLink.mavlink_request_data_stream_t req = new MAVLink.mavlink_request_data_stream_t();
            req.target_system = 0;
            req.target_component = 0;

            req.req_message_rate = (ushort)messageRate;
            req.start_stop = (byte)startStop;
            req.req_stream_id = (byte)streamId;

            byte[] bytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.REQUEST_DATA_STREAM, req);
            SendPacket(bytes);
        }
        public static void SetConstantUpdates()
        {
            // This is from the MissionPlanner. Don't change this code as this is written in BLOOD
            RequestDataStream(2, 2, 1);
            RequestDataStream(2, 2, 1);
            RequestDataStream(6, 2, 1);
            RequestDataStream(6, 2, 1);
            RequestDataStream(10, 6, 1);
            RequestDataStream(10, 6, 1);
            RequestDataStream(11, 6, 1);
            RequestDataStream(11, 6, 1);
            RequestDataStream(12, 2, 1);
            RequestDataStream(12, 2, 1);
            RequestDataStream(1, 2, 1);
            RequestDataStream(1, 2, 1);
            RequestDataStream(3, 2, 1);
            RequestDataStream(3, 2, 1);
        }
        public static void SetNoUpdates()
        {
            byte dataSteamType = 0; // ALL data streams
            ushort updateRate = 1;    // 1Hz

            MAVLink.mavlink_request_data_stream_t req = new MAVLink.mavlink_request_data_stream_t();
            req.target_system = sysID;
            req.target_component = compID;

            req.req_message_rate = updateRate;
            req.start_stop = 0;				   // start
            req.req_stream_id = dataSteamType; // id

            byte[] bytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.REQUEST_DATA_STREAM, req);
            SendPacket(bytes);
            Thread.Sleep(100);
            SendPacket(bytes);
        }

        public static void RebootAutopilot(bool bootloaderMode = false)
        {
			MAVLink.mavlink_command_long_t cmd = new MAVLink.mavlink_command_long_t();
			cmd.target_system = sysID;
			cmd.target_component = compID;
            cmd.command = (ushort)MAVLink.MAV_CMD.PREFLIGHT_REBOOT_SHUTDOWN;
            cmd.param1 = (float)(bootloaderMode ? 3 : 1);
            cmd.param2 = (float)1;

			byte[] commandBytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.COMMAND_LONG, cmd);
			SendPacket(commandBytes);

        }

		public static void GetMissionAsync()
		{
            if (threadBusy)
                return;

            threadBusy = true;
			// Just start GetMission on a new thread
			asyncThread = new Thread(new ThreadStart(GetMission));
			asyncThread.Start();
		}
		private static bool GetMissionItem(int itemNumber)
		{
			MAVLink.mavlink_mission_request_t req = new MAVLink.mavlink_mission_request_t();
			req.target_system = sysID;
			req.target_component = compID;
			req.seq = (ushort)itemNumber;

			byte[] bytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.MISSION_REQUEST, req);

			return SendWaitRetry(bytes, typeof(MAVLink.mavlink_mission_item_t), 1000, 10);
		}
		public static void GetMission()
		{
			MAVLink.mavlink_mission_request_list_t req = new MAVLink.mavlink_mission_request_list_t();
			req.target_system = sysID;
			req.target_component = compID;

			byte[] bytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.MISSION_REQUEST_LIST, req);

            if (SendWaitRetry(bytes, typeof(MAVLink.mavlink_mission_count_t)))
            {
                if (OnMissionUpdated != null)
                    OnMissionUpdated(0, missionWaypointsCount);

                for (int i = 0; i < missionWaypointsCount; i++)
                {
                    if (!GetMissionItem(i))
                    {
                        // Getting mission item failed
                        if (OnMissionUpdated != null)
                            OnMissionUpdated(-1, missionWaypointsCount);

                        threadBusy = false;
                        return;
                    }

                    // Getting mission item succeeded
                    if (OnMissionUpdated != null)
                        OnMissionUpdated(i, missionWaypointsCount);
                }


                // Send Ack
                MAVLink.mavlink_mission_ack_t ack = new MAVLink.mavlink_mission_ack_t();
                ack.target_system = 1;
                ack.target_component = 0;
                ack.type = (byte)MAVLink.MAV_MISSION_RESULT.MAV_MISSION_ACCEPTED;
                byte[] ackBytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.MISSION_ACK, ack);
                SendPacket(ackBytes);

                // Notify everyone
                if (OnMissionUpdated != null)
                    OnMissionUpdated(missionWaypointsCount, missionWaypointsCount);
            }
            else
            {
                // Loading mission failed
                if (OnMissionUpdated != null)
                    OnMissionUpdated(-1, missionWaypointsCount);
            }

            threadBusy = false;
		}
        private static void SetMissionItem(int number)
        {
            MAVLink.mavlink_mission_item_t item = new MAVLink.mavlink_mission_item_t();
            item.target_system = sysID;
            item.target_component = compID;
            item.seq = (ushort)number;

            item.command = (ushort)missionItems[number].command;

            item.x = (float)missionItems[number].lat;
            item.y = (float)missionItems[number].lng;

            item.param1 = missionItems[number].p1;
            item.param2 = missionItems[number].p2;
            item.param3 = missionItems[number].p3;
            item.param4 = missionItems[number].p4;
            item.z = (float)missionItems[number].alt;

            byte[] bytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.MISSION_ITEM, item);

            if (SendPacket(bytes))
            {
                // Notify everyone
                if (OnMissionWritten != null)
                    // Convert from zero based to 1-based
                    OnMissionWritten(number + 1, missionItems.Count());
            }

        }
        public static void SetMissionAsync(List<SMissionItem> mission, bool uploadToDrone = false)
        {
            // First, override our mission with the written mission
            missionItems = mission.ToArray();

            if (!uploadToDrone)
                return;
            
            if (threadBusy)
                return;

            threadBusy = true;
            // Just start GetMission on a new thread
            asyncThread = new Thread(new ThreadStart(SetMission));
            asyncThread.Start();
        }
        private static void SetMission()
		{
            MAVLink.mavlink_mission_count_t req = new MAVLink.mavlink_mission_count_t();
			req.target_system = sysID;
			req.target_component = compID;
            req.count = (ushort)missionItems.Length;

			byte[] bytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.MISSION_COUNT, req);

            // Notify the start of the process
            if (OnMissionWritten != null)
                OnMissionWritten(0, missionItems.Length);

            // First notify the drone about our intentions and wait for it to ask us for the mission
            if (!SendWaitRetry(bytes, typeof(MAVLink.mavlink_mission_request_list_t), 10000))
            {
                // Notify everyone
                if (OnMissionWritten != null)
                    OnMissionWritten(-1, missionItems.Length);
                threadBusy = false;
                return;
            }

            // Now the process is done asynchronously
            // The drone asks us for a mission item and we reply.
            // Wait for it to end
            if (WaitForPacket(typeof(MAVLink.mavlink_mission_ack_t), 30000))
                // Notify everyone
			    if (OnMissionWritten != null)
                    OnMissionWritten(missionItems.Length, missionItems.Length);

            threadBusy = false;
		}


		private static void CommandLong(MAVLink.MAV_CMD command, float param1, float param2)
		{
			CommandLong(command, param1, param2, 0, 0);
		}
		private static void CommandLong(MAVLink.MAV_CMD command, float param1, float param2, float param3, float param4)
		{
			MAVLink.mavlink_command_long_t cmd = new MAVLink.mavlink_command_long_t();
			cmd.target_system = sysID;
			cmd.target_component = compID;

			cmd.command = (ushort)command;
			cmd.param1 = param1;
			cmd.param2 = param2;
			cmd.param3 = param3;
			cmd.param4 = param4;


			byte[] commandBytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.COMMAND_LONG, cmd);

			SendPacket(commandBytes);
		}

		public static void ChangeFlightMode(APMModes.Quadrotor mode)
		{
			MAVLink.mavlink_set_mode_t cmd = new MAVLink.mavlink_set_mode_t();
			cmd.target_system = sysID;
			cmd.base_mode = 1; // Not sure what this is
			cmd.custom_mode = (uint)mode;

			byte[] commandBytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.SET_MODE, cmd);
			SendPacket(commandBytes);
            System.Threading.Thread.Sleep(10);
            SendPacket(commandBytes);
        }

        public static void UpdateLastFlightMode(APMModes.Quadrotor mode)
        {
           
            lastMode = mode;
        }

		public static void Takeoff(double altitudeInMeters)
		{
			MAVLink.mavlink_command_long_t cmd = new MAVLink.mavlink_command_long_t();
			cmd.target_system = sysID;
			cmd.target_component = compID;
			cmd.command = (ushort)MAVLink.MAV_CMD.TAKEOFF;
			cmd.param7 = (float)altitudeInMeters;

			byte[] commandBytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.COMMAND_LONG, cmd);
			SendPacket(commandBytes);
		}

        public static bool ForceTakeoff(double altInMeters)
        {
            if ((DateTime.Now - lastForceTakeoff).TotalSeconds < 7)
                return false;
            lastForceTakeoff = DateTime.Now;


            ChangeFlightMode(APMModes.Quadrotor.ROTOR_LOITER);
            Thread.Sleep(1000);

            ArmDisarm(true);

            Thread.Sleep(1000);
            ChangeFlightMode(APMModes.Quadrotor.ROTOR_GUIDED);
            Thread.Sleep(1000);
            Takeoff(altInMeters);

            return true;
        }

        public static bool MissionGo()
        {
            if (droneState == MAVLink.MAV_STATE.STANDBY)
            {
                ForceTakeoff(5);

                Thread.Sleep(1000);
                ChangeFlightMode(APMModes.Quadrotor.ROTOR_AUTO);

                return true;
            }

            return false;
        }
        public static void PauseMission()
        {
            if (mode == APMModes.Quadrotor.ROTOR_AUTO)
                ChangeFlightMode(APMModes.Quadrotor.ROTOR_GUIDED);
        }
        public static void ResumeMission()
        {
            ChangeFlightMode(APMModes.Quadrotor.ROTOR_AUTO);
        }

		public static void ArmDisarm(bool arm)
		{
			MAVLink.mavlink_command_long_t command = new MAVLink.mavlink_command_long_t();
			command.target_system = 1;
			command.target_component = 0;
			command.command = (ushort)MAVLink.MAV_CMD.COMPONENT_ARM_DISARM;
			command.param1 = arm ? 1 : 0;
			byte[] commandBytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.COMMAND_LONG, command);
			SendPacket(commandBytes);
		}

		// Set velocity, in m/s
		private static void SetVelocity(double vx, double vy, double vz)
		{
			const int MAVLINK_SET_POS_TYPE_MASK_POS_IGNORE = ((1<<0) | (1<<1) | (1<<2));
// 			const int MAVLINK_SET_POS_TYPE_MASK_VEL_IGNORE = ((1<<3) | (1<<4) | (1<<5));
			const int MAVLINK_SET_POS_TYPE_MASK_ACC_IGNORE = ((1<<6) | (1<<7) | (1<<8));

			MAVLink.mavlink_set_position_target_global_int_t cmd = new MAVLink.mavlink_set_position_target_global_int_t();
// 			cmd.target_system = sysID;
// 			cmd.target_component = compID;
			cmd.target_system = 1;
			cmd.target_component = 0;
			cmd.coordinate_frame = 5; // MAV_FRAME_GLOBAL_INT 
			// Use only speed
			cmd.type_mask = MAVLINK_SET_POS_TYPE_MASK_POS_IGNORE | MAVLINK_SET_POS_TYPE_MASK_ACC_IGNORE;

			cmd.vx = (float)vx;
			cmd.vy = (float)vy;
			cmd.vz = (float)vz;

			byte[] commandBytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.SET_POSITION_TARGET_GLOBAL_INT, cmd);
			SendPacket(commandBytes);
		}

        public static void GoToWaypoint(double latitude, double longitude, double altInMeters)
        {
            MAVLink.mavlink_mission_item_t msg = new MAVLink.mavlink_mission_item_t();
            msg.seq = 0;
            msg.current = 2; // TODO use guided mode enum
            msg.frame = (byte)MAVLink.MAV_FRAME.GLOBAL;
            msg.command = (ushort)MAVLink.MAV_CMD.WAYPOINT; //
            msg.param1 = 0; // TODO use correct parameter
            msg.param2 = 0; // TODO use correct parameter
            msg.param3 = 0; // TODO use correct parameter
            msg.param4 = 0; // desired yaw
            msg.x = (float) latitude;
            msg.y = (float) longitude;
            msg.z = (float) altInMeters;
            msg.autocontinue = 1; // TODO use correct parameter
            msg.target_system = sysID;
            msg.target_component = compID;

            byte[] commandBytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.MISSION_ITEM, msg);
            SendPacket(commandBytes);
        }
		public static void ConditionYaw(double targetAngle, double angularSpeed, bool CW, bool relative)
		{
			MAVLink.mavlink_mission_item_t msg = new MAVLink.mavlink_mission_item_t();
			msg.seq = 0;
			msg.current = 2; // TODO use guided mode enum
			msg.frame = (byte)MAVLink.MAV_FRAME.GLOBAL;
			msg.command = (ushort)MAVLink.MAV_CMD.CONDITION_YAW;
			msg.param1 = (float)targetAngle; // 0-360. 0 is North
			msg.param2 = (float)angularSpeed; // Deg per second
			msg.param3 = (float)(CW ? 1.0 : -1.0); // 1 - CW, -1 CCW
			msg.param4 = (float)(relative ? 1 : 0); // 1 - Relative, 0 - Absolute
			msg.autocontinue = 1; // TODO use correct parameter
			msg.target_system = sysID;
			msg.target_component = compID;

			byte[] commandBytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.MISSION_ITEM, msg);
			SendPacket(commandBytes);
		}


        public static void GuidedPosition(double lat, double lng, double alt)
        {
            //const int MAVLINK_SET_POS_TYPE_MASK_POS_IGNORE = ((1 << 0) | (1 << 1) | (1 << 2));
			const int MAVLINK_SET_POS_TYPE_MASK_VEL_IGNORE = ((1 << 3) | (1 << 4) | (1 << 5));
            const int MAVLINK_SET_POS_TYPE_MASK_ACC_IGNORE = ((1 << 6) | (1 << 7) | (1 << 8));

            MAVLink.mavlink_set_position_target_global_int_t cmd = new MAVLink.mavlink_set_position_target_global_int_t();
            // 			cmd.target_system = sysID;
            // 			cmd.target_component = compID;
            cmd.target_system = 0;
            cmd.target_component = 1;
            cmd.coordinate_frame = 5; // MAV_FRAME_GLOBAL_INT 
            // Use only speed
            cmd.type_mask = MAVLINK_SET_POS_TYPE_MASK_VEL_IGNORE | MAVLINK_SET_POS_TYPE_MASK_ACC_IGNORE;

            cmd.lat_int = (int)(lat * 10000000);
            cmd.lon_int = (int)(lng * 10000000);
            cmd.alt = (float)alt;

            byte[] commandBytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.SET_POSITION_TARGET_GLOBAL_INT, cmd);
            SendPacket(commandBytes);
        }


		public static void MoveForward()
		{
//  			CommandLong(MAVLink.MAV_CMD.MANUAL_REPOSITION, 0, -moveSpeed);
			SetVelocity(0, -moveSpeed, 0);
		}
		public static void MoveBack()
		{
// 			CommandLong(MAVLink.MAV_CMD.MANUAL_REPOSITION, 0, moveSpeed);
			SetVelocity(0, moveSpeed, 0);
		}
		public static void MoveLeft()
		{
// 			CommandLong(MAVLink.MAV_CMD.MANUAL_REPOSITION, -moveSpeed, 0);
			SetVelocity(-moveSpeed, 0, 0);
		}
		public static void MoveRight()
		{
// 			CommandLong(MAVLink.MAV_CMD.MANUAL_REPOSITION, moveSpeed, 0);
			SetVelocity(moveSpeed, 0, 0);
		}
		public static void MoveStop()
		{
// 			CommandLong(MAVLink.MAV_CMD.MANUAL_REPOSITION, 0, 0);
			SetVelocity(0, 0, 0);
		}

        // Move the quad in simple steps. Step sizes are in meters
        public static void Step(double frontBackStep, double leftRightStep)
        {
            double earthRadius = 6371000;

            // Rotate to N-S coordinates
            double LongitudeOffsetMeters =
                frontBackStep * Math.Sin(CDroneManager.DronePosition.heading * Math.PI / 180.0) +
                leftRightStep * Math.Cos(CDroneManager.DronePosition.heading * Math.PI / 180.0);
            double LatitudeOffsetMeters =
                frontBackStep * Math.Cos(CDroneManager.DronePosition.heading * Math.PI / 180.0) +
                leftRightStep * Math.Sin(CDroneManager.DronePosition.heading * Math.PI / 180.0);

            // Now to lat long
            double newLatitude = CDroneManager.DronePosition.lat +
                (LatitudeOffsetMeters / earthRadius) * (180 / Math.PI);
            double newLongitude = CDroneManager.DronePosition.lng +
                (LongitudeOffsetMeters / earthRadius) * (180 / Math.PI) /
                Math.Cos(CDroneManager.DronePosition.lat * Math.PI / 180);

            GoToWaypoint(newLatitude, newLongitude, dronePosition.altFromGround);
        }

        public static void StepForward(double stepSize = 2)
        {
            Step(stepSize, 0);
        }
        public static void StepBack(double stepSize = 2)
        {
            Step(-stepSize, 0);
        }
        public static void StepLeft(double stepSize = 1)
        {
            Step(0, stepSize);
 //          CDroneManager.MoveLeft();
//             Thread.Sleep(1500);
//             CDroneManager.MoveStop();	
        }
        public static void StepRight(double stepSize = 1)
        {
            Step(0, -stepSize);
//            CDroneManager.MoveRight();
//             Thread.Sleep(1500);
//             CDroneManager.MoveStop();
        }

		public static void SetAlt(Double alt)
		{
			GoToWaypoint(CDroneManager.dronePosition.lat, CDroneManager.dronePosition.lng, alt);
		}

        public static void Heartbeat()
        {
            // Straight from mission planner
			MAVLink.mavlink_heartbeat_t hb = new MAVLink.mavlink_heartbeat_t();
			hb.autopilot = (byte) MAVLink.MAV_AUTOPILOT.INVALID;
            hb.type = (byte)MAVLink.MAV_TYPE.GCS;
            hb.mavlink_version = 3;

			byte[] commandBytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.HEARTBEAT, hb);
			SendPacket(commandBytes);	        
        }


//         void SetupMavConnect(byte sysid, byte compid, byte mgsno, mavlink_heartbeat_t hb)
//         {
//             sysidcurrent = sysid;
// 
//             mavlinkversion = hb.mavlink_version;
//             MAV.aptype = (MAV_TYPE)hb.type;
//             MAV.apname = (MAV_AUTOPILOT)hb.autopilot;
// 
//             setAPType(sysid);
// 
//             MAV.sysid = sysid;
//             MAV.compid = compid;
//             MAV.recvpacketcount = mgsno;
//             log.InfoFormat("ID sys {0} comp {1} ver{2} type {3} name {4}", MAV.sysid, MAV.compid, mavlinkversion, MAV.aptype.ToString(), MAV.apname.ToString());
//         }


        public static void SetControl(bool aquire)
        {
            // Straight from mission planner
            MAVLink.mavlink_change_operator_control_t packet = new MAVLink.mavlink_change_operator_control_t();
            packet.target_system = sysID;
            packet.control_request = aquire ? (byte)1 : (byte)0;
            packet.version = 0;

            byte[] pass = ASCIIEncoding.ASCII.GetBytes("\0");
            // I'm not sure  why this is needed, but it is
            Array.Resize(ref pass, 25);
            packet.passkey = pass;

            byte[] commandBytes = mavlink.GenerateMAVLinkPacket(MAVLink.MAVLINK_MSG_ID.CHANGE_OPERATOR_CONTROL, packet);
            SendPacket(commandBytes);	                    
        }

        public static void SIM_InjectPosition(double lat, double lng, double alt, SMission? mission, bool refreshMission)
        {
            mode = APMModes.Quadrotor.ROTOR_AUTO;

            dronePosition.altFromGround = alt;
            dronePosition.heading = 57;
            GPSHdop = 0.9;
            dronePosition.lat = lat;
            dronePosition.lng = lng;

            dronePosition.alt = alt;
            satCount = 18;

            if (OnDroneReady != null)
                OnDroneReady(true);

            if (refreshMission)
            {
                if (mission.HasValue)
                {
                    missionItems = mission.Value.Items.ToArray();

                    if (OnMissionUpdated != null)
                        OnMissionUpdated(12, 12);
                }
            }
        }
    }
}
