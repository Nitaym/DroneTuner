using SDK.Comm;
using SDK.Drone;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DroneTuner
{
    public partial class FormMain : Form
    {
        private CSerialComm comm = new CSerialComm();

        public FormMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] portNames = SerialPort.GetPortNames();
            foreach (string port in portNames)
            {
                comboBoxCOM.Items.Add(port);
            }

            comboBoxCOM.SelectedIndex = comboBoxCOM.FindStringExact(Properties.Settings.Default.Comport);
            comboBoxBaudrate.SelectedIndex = comboBoxBaudrate.FindStringExact(Properties.Settings.Default.Baud);

            CManager.Initialize();
            CDroneManager.OnPacketReceived += CDroneManager_OnPacketReceived;

            Connect();

            //(new FormMavlink()).Show();
        }

        private void CDroneManager_OnPacketReceived(object packet, int sysId, int compId)
        {
        }

        private void Connect()
        {
            comm = new CSerialComm();
            comm.Comport = Properties.Settings.Default.Comport;
            comm.Baudrate = Properties.Settings.Default.Baud;
            if (comm.Connect())
            {
                CDroneManager.Initialize(comm);
                buttonConnect.Text = "Disconnect";

                RefreshAll();
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (!comm.Connected)
            {
                Properties.Settings.Default.Comport = comboBoxCOM.Text;
                Properties.Settings.Default.Baud = comboBoxBaudrate.Text;
                Properties.Settings.Default.Save();

                Connect();
            }
            else
            {
                comm.Disconnect();
                buttonConnect.Text = "Connect";
            }

        }

        private void RefreshAll()
        {
            CDroneManager.ReadParameter("TUNE", false);
            CDroneManager.ReadParameter("TUNE_LOW", false);
            CDroneManager.ReadParameter("TUNE_HIGh", false);

            touchSpinPitchP.RefreshParameter();
            touchSpinPitchI.RefreshParameter();
            touchSpinPitchD.RefreshParameter();
            touchSpinPitchImax.RefreshParameter();
            touchSpinRollP.RefreshParameter();
            touchSpinRollI.RefreshParameter();
            touchSpinRollD.RefreshParameter();
            touchSpinRollImax.RefreshParameter();
            touchSpinYawP.RefreshParameter();
            touchSpinYawI.RefreshParameter();
            touchSpinYawD.RefreshParameter();
            touchSpinYawImax.RefreshParameter();
            touchSpinAltP.RefreshParameter();
            touchSpinAltI.RefreshParameter();
            touchSpinAltD.RefreshParameter();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void buttonShowMavlink_Click(object sender, EventArgs e)
        {
            (new FormMavlink()).Show();
        }

        private void buttonClearCh6_Click(object sender, EventArgs e)
        {
            CDroneManager.WriteParameter("TUNE", 0);
        }
    }
}
