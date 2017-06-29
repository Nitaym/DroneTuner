using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDK.Drone;

namespace SDK.Controls
{
	public partial class CBatteryView : UserControl
	{
        public bool Connected;

		public CBatteryView()
		{
			InitializeComponent();
		}

		private void CBatteryView_Load(object sender, EventArgs e)
		{
			if (!this.DesignMode)
				CDroneManager.OnPacketReceived += CDroneManager_OnPacket;
		}

		void RefreshInfo(double voltage, double current, int remaining)
		{
            double battery100Value = 12.6;
            double battery0Value = 10.35;

            
            if (this.IsDisposed)
                return;

            labelVoltage.SafeInvoke(() =>
            {
                labelVoltage.Text = voltage.ToString("0.0V");
                labelCurrent.Text = current.ToString("0.0A");
                //             labelBatteryPercentage.Text = remaining.ToString() + "%";
                labelBatteryPercentage.Text = (((voltage - battery0Value) / (battery100Value - battery0Value)) * 100).ToString("0.#") + "%";
            }, false);
		}

		void CDroneManager_OnPacket(object packet, int sysId, int compId)
		{
			if (packet.GetType() == typeof(MAVLink.mavlink_sys_status_t))
			{
				MAVLink.mavlink_sys_status_t status = (MAVLink.mavlink_sys_status_t)packet;

				RefreshInfo(
					(double)status.voltage_battery / 1000,
					(double)status.current_battery / 100,
					status.battery_remaining);
			}			
		}

        private void CBatteryView_Resize(object sender, EventArgs e)
        {
            labelVoltage.Width = labelCurrent.Width = this.Width / 2;
        }
	}
}
