using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using SDK.Drone;
using System.IO;

namespace DroneTuner
{
	public partial class FormMavlink : Form
	{
		bool closing = false;
		bool threadDone = false;
		ManualResetEvent safeToCloseEvent = new ManualResetEvent(false);
        private MAVLink.MavlinkParse mavlink = new MAVLink.MavlinkParse();

		public FormMavlink()
		{
			InitializeComponent();

            CDroneManager.OnPacketReceived += CDroneManager_OnPacketReceived;
            CDroneManager.OnPacketSent += CDroneManager_OnPacketSent;
		}

        void CDroneManager_OnPacketSent(byte[] packet, int sysId, int compId)
        {
            if (threadDone)
                return;

            MemoryStream stream = new MemoryStream(packet);
            object sentPacket = mavlink.ReadPacket(stream);

            LogPacket(sentPacket, false, sysId, compId);


            if (closing)
            {
                threadDone = true;
                CloseForm();
            }

        }
        void CDroneManager_OnPacketReceived(object packet, int sysId, int compId)
        {
            if (threadDone)
                return;

            LogPacket(packet, true, sysId, compId);

            if (closing)
            {
                threadDone = true;
                CloseForm();
            }
        }

        private bool IsMessageFilteredOut(string messageName)
        {
            if (threadDone)
                return true;

            // Check filter status
            ListViewItem filteredItem = null;
            if (listViewFilter.Items.Count > 0)
                filteredItem = listViewFilter.FindItemWithText(messageName, false, 0, false);

            if (filteredItem != null)
                return !filteredItem.Checked;

            
            // Add a new message to the list
            listViewFilter.Items.Add(new ListViewItem(messageName)).Checked = true;
            return false;
        }

        private ListViewItem INGOING(ListViewItem item)
        {
            item.BackColor = Color.LightSteelBlue;
            return item;
        }
        private ListViewItem OUTGOING(ListViewItem item)
        {
            item.BackColor = Color.Pink;
            return item;
        }


		private void Log(String value)
		{
			bool show = true;

            listViewMessages.SafeInvoke((Action) delegate 
            { 
                if (!listViewMessages.IsDisposed && show) 
                    listViewMessages.Items.Add(new ListViewItem(value)); 
            }, false);

		}
    	private void LogPacket(object packet, bool ingoing, int sysId, int compId)
		{
            if (threadDone)
                return;

			if (listViewMessages.InvokeRequired)
			{
                try { listViewMessages.Invoke(new Action<object, bool, int, int>(LogPacket), packet, ingoing, sysId, compId); }
                catch { };
				return;
			}

            List<string> fields = new List<string>();
            fields.Add(sysId.ToString());
            fields.Add(compId.ToString());

            if ((ingoing && !checkBoxIngoing.Checked) || (!ingoing && !checkBoxOutgoing.Checked))
                return;

            string messageName = packet.ToString().Replace("MAVLink+mavlink_", "");

            if (IsMessageFilteredOut(messageName))
                return;


			if (listViewMessages.IsDisposed)
				return;


            if (packet.GetType() == typeof(MAVLink.mavlink_gps_raw_int_t))
            {
                MAVLink.mavlink_gps_raw_int_t gps = (MAVLink.mavlink_gps_raw_int_t)packet;
                fields.Add("GPS Raw Int");
                fields.Add(((double)gps.lat / 10000000).ToString());
                fields.Add(((double)gps.lon / 10000000).ToString());
                fields.Add(gps.alt.ToString());
                fields.Add(gps.vel.ToString());
                fields.Add(gps.satellites_visible.ToString());
            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_global_position_int_t))
            {
                MAVLink.mavlink_global_position_int_t gps = (MAVLink.mavlink_global_position_int_t)packet;
				fields.Add("GPS Global Position Int");
				fields.Add(((double)gps.lat / 10000000).ToString());
				fields.Add(((double)gps.lon / 10000000).ToString());
				fields.Add(gps.alt.ToString());
            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_attitude_t))
            {
                MAVLink.mavlink_attitude_t att = (MAVLink.mavlink_attitude_t)packet;
				fields.Add("Attitude");
                fields.Add((att.pitch * 180.0 / Math.PI).ToString());
                fields.Add((att.roll * 180.0 / Math.PI).ToString());
                fields.Add((att.yaw * 180.0 / Math.PI).ToString());
                fields.Add((att.pitchspeed * 180.0 / Math.PI).ToString());
                fields.Add((att.rollspeed * 180.0 / Math.PI).ToString());
                fields.Add((att.yawspeed * 180.0 / Math.PI).ToString());
            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_scaled_imu_t))
			{
				MAVLink.mavlink_scaled_imu_t imu = (MAVLink.mavlink_scaled_imu_t)packet;
				fields.Add("Scaled IMU");
				fields.Add(imu.xmag.ToString());
				fields.Add(imu.ymag.ToString());
				fields.Add(imu.zmag.ToString());
			}
			else if (packet.GetType() == typeof(MAVLink.mavlink_scaled_imu3_t))
			{
				MAVLink.mavlink_scaled_imu3_t imu = (MAVLink.mavlink_scaled_imu3_t)packet;
                fields.Add("Scaled IMU3");
                fields.Add(imu.xmag.ToString());
                fields.Add(imu.ymag.ToString());
                fields.Add(imu.zmag.ToString());
			}
			else if (packet.GetType() == typeof(MAVLink.mavlink_scaled_imu2_t))
			{
				MAVLink.mavlink_scaled_imu2_t imu = (MAVLink.mavlink_scaled_imu2_t)packet;
                fields.Add("Scaled IMU2");
                fields.Add(imu.xmag.ToString());
                fields.Add(imu.ymag.ToString());
                fields.Add(imu.zmag.ToString());
			}
			else if (packet.GetType() == typeof(MAVLink.mavlink_sys_status_t))
			{
				MAVLink.mavlink_sys_status_t status = (MAVLink.mavlink_sys_status_t)packet;
				fields.Add("System Status");
				fields.Add(status.voltage_battery.ToString());
			}
// 			else if (packet.GetType() == typeof(MAVLink.mavlink_autopilot_version_t))
// 			{
// 				MAVLink.mavlink_autopilot_version_t ver = (MAVLink.mavlink_autopilot_version_t)packet;
// 				listViewMessages.Items.Add(new ListViewItem(new string[] {
// 					"Autopilot Version",
// 					ver.version.ToString(),
// 					ver.custom_version.ToString(),
// 					ver.capabilities.ToString()}));
// 			}
			else if (packet.GetType() == typeof(MAVLink.mavlink_heartbeat_t))
			{
				MAVLink.mavlink_heartbeat_t hb = (MAVLink.mavlink_heartbeat_t)packet;
                fields.Add("Heartbeat");
                fields.Add(hb.autopilot.ToString());
                fields.Add(hb.system_status.ToString());
                fields.Add(hb.mavlink_version.ToString());
			}
            else if (packet.GetType() == typeof(MAVLink.mavlink_statustext_t))
            {
                MAVLink.mavlink_statustext_t status = (MAVLink.mavlink_statustext_t)packet;
				fields.Add("Status Text");
				fields.Add(ASCIIEncoding.ASCII.GetString(status.text));
				fields.Add(status.severity.ToString());
            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_param_value_t))
            {
                MAVLink.mavlink_param_value_t paramValue = (MAVLink.mavlink_param_value_t)packet;
                fields.Add("Param Value");
                fields.Add(ASCIIEncoding.ASCII.GetString(paramValue.param_id));
                fields.Add(paramValue.param_value.ToString());
                fields.Add(paramValue.param_count.ToString());
                fields.Add(paramValue.param_index.ToString());
                fields.Add(paramValue.param_type.ToString());
            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_param_request_read_t))
            {
                MAVLink.mavlink_param_request_read_t paramReq = (MAVLink.mavlink_param_request_read_t)packet;
                fields.Add("Param Request Read");
                fields.Add(ASCIIEncoding.ASCII.GetString(paramReq.param_id));
            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_param_set_t))
            {
                MAVLink.mavlink_param_set_t paramSet = (MAVLink.mavlink_param_set_t)packet;
                fields.Add("Param Set");
                fields.Add(ASCIIEncoding.ASCII.GetString(paramSet.param_id));
                fields.Add(paramSet.param_value.ToString());
            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_mission_count_t))
			{
				MAVLink.mavlink_mission_count_t paramValue = (MAVLink.mavlink_mission_count_t)packet;
				fields.Add("Mission Count");
				fields.Add(paramValue.count.ToString());
				fields.Add(paramValue.target_component.ToString());
				fields.Add(paramValue.target_system.ToString());
			}
            else if (packet.GetType() == typeof(MAVLink.mavlink_mission_item_t))
            {
                MAVLink.mavlink_mission_item_t item = (MAVLink.mavlink_mission_item_t)packet;
				fields.Add("Mission Item");
                fields.Add(item.seq.ToString());
            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_mission_request_t))
            {
                MAVLink.mavlink_mission_request_t item = (MAVLink.mavlink_mission_request_t)packet;
                fields.Add("Mission Request Item");
                fields.Add(item.seq.ToString());
            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_command_ack_t))
            {
                MAVLink.mavlink_command_ack_t paramValue = (MAVLink.mavlink_command_ack_t)packet;
                fields.Add("Ack");
                fields.Add(((MAVLink.MAV_CMD)paramValue.command).ToString());
                fields.Add(((MAVLink.MAV_RESULT)paramValue.result).ToString());

            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_mission_ack_t))
            {
                MAVLink.mavlink_mission_ack_t paramValue = (MAVLink.mavlink_mission_ack_t)packet;
				fields.Add("Mission Ack");
                fields.Add(paramValue.type.ToString());
            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_radio_status_t))
            {
                MAVLink.mavlink_radio_status_t radio = (MAVLink.mavlink_radio_status_t)packet;
				fields.Add("Radio Status");
				fields.Add(radio.rssi.ToString());
                fields.Add(radio.remrssi.ToString());
            }
            else if (packet.GetType() == typeof(MAVLink.mavlink_ekf_status_report_t))
            {
                MAVLink.mavlink_ekf_status_report_t ekf = (MAVLink.mavlink_ekf_status_report_t)packet;
				fields.Add("EKF Status");
				fields.Add(ekf.flags.ToString());
				fields.Add(ekf.velocity_variance.ToString());
				fields.Add(ekf.pos_horiz_variance.ToString());
				fields.Add(ekf.pos_vert_variance.ToString());
				fields.Add(ekf.compass_variance.ToString());
                fields.Add(ekf.terrain_alt_variance.ToString());
            }
            else
            {
                fields.Add(messageName);
                //Log(packet.ToString());
            }

            if (ingoing)
                listViewMessages.Items.Add(INGOING(new ListViewItem(fields.ToArray())));
            else
                listViewMessages.Items.Add(OUTGOING(new ListViewItem(fields.ToArray())));
		}

		void CloseForm()
		{
            this.SafeInvoke(() => Close(), true);
		}

        private void FormMavlink_Load(object sender, EventArgs e)
        {
            listViewFilter.Sorting = SortOrder.Ascending;
        }
        private void FormMavlink_FormClosing(object sender, FormClosingEventArgs e)
		{
            if (CDroneManager.Comm == null)
                return;

			if (CDroneManager.Comm.Connected)
			{
				if (!threadDone)
				{
					// Signal closing
					closing = true;

					// Don't close yet, the OnPacket event will close when it's done
					e.Cancel = true;
				}
				else
				{
					// Thread done - we can close
				}
			}
		}

		private void listViewMessages_SelectedIndexChanged(object sender, EventArgs e)
		{

		}

		private void buttonAll_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in listViewFilter.Items)
			{
				item.Checked = true;
			}
		}
		private void buttonNone_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem item in listViewFilter.Items)
			{
				item.Checked = false;
			}
		}
        private void buttonClear_Click(object sender, EventArgs e)
        {
            listViewMessages.Items.Clear();
        }
        private void buttonRemoveJunk_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listViewFilter.Items)
            {
                if ((item.Text == "statustext_t") ||
                    (item.Text == "mission_request_list_t") ||
                    (item.Text == "mission_request_t") ||
                    (item.Text == "mission_count_t") ||
                    (item.Text == "mission_item_t") ||
                    (item.Text == "mission_ack_t"))
                    item.Checked = true;
                else
                    item.Checked = false;

            }
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listViewMessages.Items.Clear();
        }
	}
}
