using SDK.Drone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneTuner
{
    class CManager
    {
        public static event Action OnRefreshDroneInfo;
        public static event Action<string> OnStatusText;

        private static object lastPacket = null;


        public static void Initialize()
        {
            CDroneManager.OnPacketReceived += CDroneManager_OnPacket;
        }

        private static void UpdateStatus(string status)
        {
            if (OnStatusText != null)
                OnStatusText(status);
        }

        static void CDroneManager_OnPacket(object packet, int sysId, int compId)
        {
            if (packet.GetType() == typeof(MAVLink.mavlink_statustext_t))
            {
                MAVLink.mavlink_statustext_t status = (MAVLink.mavlink_statustext_t)packet;
                string messageString = ASCIIEncoding.ASCII.GetString(status.text);
                UpdateStatus(messageString.Substring(0, Math.Max(0, messageString.IndexOf('\0'))));
            }

            if (packet.GetType() == typeof(MAVLink.mavlink_heartbeat_t))
            {
//                 // Return a heartbeat to the drone, this ensures the drones knows the GCS is on
//                 // and won't panic when on Guided mode
//                 CHeartbeatThread.Initialize();
// 
                if ((lastPacket != null) && (lastPacket.GetType() == typeof(MAVLink.mavlink_heartbeat_t)))
                {
                    // This means we got 2 heartbeats in a row. This shouldn't happen - More messages need to be received
                    CDroneManager.SetConstantUpdates();
                }

                OnRefreshDroneInfo?.Invoke();
            }

            lastPacket = packet;
        }
    }
}
