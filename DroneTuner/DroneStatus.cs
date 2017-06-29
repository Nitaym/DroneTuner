using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDK.Controls;
using SDK.Drone;
using System.Globalization;


namespace DroneTuner
{
    public partial class DroneStatus : UserControl
    {
        public DroneStatus()
        {
            InitializeComponent();

            CManager.OnRefreshDroneInfo += CManager_OnRefreshDroneInfo;
            CManager.OnStatusText += CManager_OnStatusText;
        }

        void CManager_OnStatusText(string obj)
        {
            labelDroneStatusMessage.SafeInvoke((Action)delegate
            {
                labelDroneStatusMessage.Text = obj;
            }, false);           
        }

        void CManager_OnRefreshDroneInfo()
        {
            this.SafeInvoke((Action)delegate
            {
                if (this.IsDisposed)
                    return;

                CDroneManager.UpdateLastFlightMode(CDroneManager.Mode);

                labelMode.Text = APMModes.ModeToString(CDroneManager.Mode);
                
                labelAlt.Text = CDroneManager.DronePosition.altFromGround.ToString("0.0m");

                labelHDOP.Text = String.Format("{0:0.0m} ({1})", CDroneManager.GPSHdop, CDroneManager.GPSSatelliteCount);


                labelHeading.Text = CDroneManager.DronePosition.heading.ToString("0.0°");

                CultureInfo cultureInfo = CultureInfo.GetCultureInfoByIetfLanguageTag("en-US");
                TextInfo textInfo = cultureInfo.TextInfo;

                /*labelDroneState.Text = textInfo.ToTitleCase(CDroneManager.DroneState.ToString().ToLower());*/

                labelEKF.Text = CDroneManager.EKFStatus.ToString("0.000") + " (" + CDroneManager.EKFFlags + ")";
            }, false);
        }

        private void DroneStatusBar_Resize(object sender, EventArgs e)
        {
//             int spacePerStat = this.Width / 5;
//             int margin = 10;
//             int titleInfoSpace = 15;
//             int titleSpace = (int)(spacePerStat * 0.6);
//             int infoSpace = (int)(spacePerStat * 0.4);
// 
//             labelTitle1.Left = margin;
//             labelTitle1.Width = titleSpace;
//             labelAlt.Left = labelTitle1.Left + labelTitle1.Width + titleInfoSpace;
//             labelAlt.Width = infoSpace;
// 
//             labelTitle2.Left = labelTitle1.Left + spacePerStat;
//             labelTitle2.Width = titleSpace;
//             labelHeading.Left = labelTitle2.Left + labelTitle2.Width + titleInfoSpace;
//             labelHeading.Width = infoSpace;
// 
//             labelTitle3.Left = labelTitle2.Left + spacePerStat;
//             labelTitle3.Width = titleSpace;
//             labelEKF.Left = labelTitle3.Left + labelTitle3.Width + titleInfoSpace;
//             labelEKF.Width = infoSpace;
// 
//             labelTitle4.Left = labelTitle3.Left + spacePerStat;
//             labelTitle4.Width = titleSpace;
//             labelHDOP.Left = labelTitle4.Left + labelTitle4.Width + titleInfoSpace;
//             labelHDOP.Width = infoSpace;
// 
//             labelTitle5.Left = labelTitle4.Left + spacePerStat;
//             labelTitle5.Width = titleSpace;
//             labelMode.Left = labelTitle5.Left + labelTitle5.Width + titleInfoSpace;
//             labelMode.Width = infoSpace;
        }

        private void labelDroneStatusMessage_Click(object sender, EventArgs e)
        {
            labelDroneStatusMessage.Text = "";
        }
    }
}
