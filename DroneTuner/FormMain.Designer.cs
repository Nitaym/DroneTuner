namespace DroneTuner
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.comboBoxBaudrate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxCOM = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonShowMavlink = new System.Windows.Forms.Button();
            this.buttonClearCh6 = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.touchSpinAltD = new DroneTuner.TouchSpin();
            this.touchSpinAltI = new DroneTuner.TouchSpin();
            this.touchSpinAltP = new DroneTuner.TouchSpin();
            this.touchSpinYawImax = new DroneTuner.TouchSpin();
            this.touchSpinYawD = new DroneTuner.TouchSpin();
            this.touchSpinYawI = new DroneTuner.TouchSpin();
            this.touchSpinYawP = new DroneTuner.TouchSpin();
            this.touchSpinRollImax = new DroneTuner.TouchSpin();
            this.touchSpinRollD = new DroneTuner.TouchSpin();
            this.touchSpinRollI = new DroneTuner.TouchSpin();
            this.touchSpinRollP = new DroneTuner.TouchSpin();
            this.touchSpinPitchImax = new DroneTuner.TouchSpin();
            this.touchSpinPitchD = new DroneTuner.TouchSpin();
            this.touchSpinPitchI = new DroneTuner.TouchSpin();
            this.touchSpinPitchP = new DroneTuner.TouchSpin();
            this.droneStatus1 = new DroneTuner.DroneStatus();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelTop.SuspendLayout();
            this.panel6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonConnect);
            this.groupBox1.Controls.Add(this.comboBoxBaudrate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxCOM);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(1410, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(167, 117);
            this.groupBox1.TabIndex = 64;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Communication";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(6, 75);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(152, 36);
            this.buttonConnect.TabIndex = 65;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // comboBoxBaudrate
            // 
            this.comboBoxBaudrate.FormattingEnabled = true;
            this.comboBoxBaudrate.Items.AddRange(new object[] {
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200"});
            this.comboBoxBaudrate.Location = new System.Drawing.Point(60, 48);
            this.comboBoxBaudrate.Name = "comboBoxBaudrate";
            this.comboBoxBaudrate.Size = new System.Drawing.Size(98, 21);
            this.comboBoxBaudrate.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Baudrate";
            // 
            // comboBoxCOM
            // 
            this.comboBoxCOM.FormattingEnabled = true;
            this.comboBoxCOM.Location = new System.Drawing.Point(60, 23);
            this.comboBoxCOM.Name = "comboBoxCOM";
            this.comboBoxCOM.Size = new System.Drawing.Size(98, 21);
            this.comboBoxCOM.TabIndex = 5;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(31, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "COM";
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonRefresh.Location = new System.Drawing.Point(9, 68);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(152, 47);
            this.buttonRefresh.TabIndex = 65;
            this.buttonRefresh.Text = "Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // buttonShowMavlink
            // 
            this.buttonShowMavlink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonShowMavlink.Location = new System.Drawing.Point(167, 68);
            this.buttonShowMavlink.Name = "buttonShowMavlink";
            this.buttonShowMavlink.Size = new System.Drawing.Size(152, 47);
            this.buttonShowMavlink.TabIndex = 66;
            this.buttonShowMavlink.Text = "Show Mavlink";
            this.buttonShowMavlink.UseVisualStyleBackColor = true;
            this.buttonShowMavlink.Click += new System.EventHandler(this.buttonShowMavlink_Click);
            // 
            // buttonClearCh6
            // 
            this.buttonClearCh6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearCh6.Location = new System.Drawing.Point(9, 13);
            this.buttonClearCh6.Name = "buttonClearCh6";
            this.buttonClearCh6.Size = new System.Drawing.Size(152, 47);
            this.buttonClearCh6.TabIndex = 67;
            this.buttonClearCh6.Text = "Clear Ch 6";
            this.buttonClearCh6.UseVisualStyleBackColor = true;
            this.buttonClearCh6.Click += new System.EventHandler(this.buttonClearCh6_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.buttonClearCh6);
            this.panel2.Controls.Add(this.buttonShowMavlink);
            this.panel2.Controls.Add(this.buttonRefresh);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 551);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1580, 136);
            this.panel2.TabIndex = 71;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 19);
            this.label7.TabIndex = 41;
            this.label7.Text = "P";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(101, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 41;
            this.label2.Text = "I";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(26, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 19);
            this.label13.TabIndex = 41;
            this.label13.Text = "P";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(190, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 41;
            this.label3.Text = "D";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(112, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 19);
            this.label14.TabIndex = 41;
            this.label14.Text = "I";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(295, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 41;
            this.label4.Text = "IMAX";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(201, 32);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 19);
            this.label15.TabIndex = 41;
            this.label15.Text = "D";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(306, 32);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 19);
            this.label16.TabIndex = 41;
            this.label16.Text = "IMAX";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 19);
            this.label10.TabIndex = 62;
            this.label10.Text = "P";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(98, 32);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 19);
            this.label9.TabIndex = 61;
            this.label9.Text = "I";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(187, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(83, 19);
            this.label8.TabIndex = 60;
            this.label8.Text = "D";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(292, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 19);
            this.label6.TabIndex = 59;
            this.label6.Text = "IMAX";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(366, 23);
            this.label5.TabIndex = 63;
            this.label5.Text = "Yaw";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(15, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(366, 23);
            this.label11.TabIndex = 63;
            this.label11.Text = "Pitch";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(26, 9);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(366, 23);
            this.label17.TabIndex = 63;
            this.label17.Text = "Roll";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel6);
            this.panel1.Controls.Add(this.panel5);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1580, 488);
            this.panel1.TabIndex = 70;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label5);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.label9);
            this.panel5.Controls.Add(this.label10);
            this.panel5.Controls.Add(this.touchSpinYawImax);
            this.panel5.Controls.Add(this.touchSpinYawD);
            this.panel5.Controls.Add(this.touchSpinYawI);
            this.panel5.Controls.Add(this.touchSpinYawP);
            this.panel5.Location = new System.Drawing.Point(871, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(396, 461);
            this.panel5.TabIndex = 66;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label17);
            this.panel4.Controls.Add(this.touchSpinRollImax);
            this.panel4.Controls.Add(this.touchSpinRollD);
            this.panel4.Controls.Add(this.touchSpinRollI);
            this.panel4.Controls.Add(this.touchSpinRollP);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.label13);
            this.panel4.Location = new System.Drawing.Point(423, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(420, 461);
            this.panel4.TabIndex = 65;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.touchSpinPitchImax);
            this.panel3.Controls.Add(this.touchSpinPitchD);
            this.panel3.Controls.Add(this.touchSpinPitchI);
            this.panel3.Controls.Add(this.touchSpinPitchP);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(395, 461);
            this.panel3.TabIndex = 64;
            // 
            // panelTop
            // 
            this.panelTop.Controls.Add(this.droneStatus1);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1580, 63);
            this.panelTop.TabIndex = 72;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.label18);
            this.panel6.Controls.Add(this.label20);
            this.panel6.Controls.Add(this.label21);
            this.panel6.Controls.Add(this.label22);
            this.panel6.Controls.Add(this.touchSpinAltD);
            this.panel6.Controls.Add(this.touchSpinAltI);
            this.panel6.Controls.Add(this.touchSpinAltP);
            this.panel6.Location = new System.Drawing.Point(1292, 0);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(291, 461);
            this.panel6.TabIndex = 67;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(15, 9);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(261, 23);
            this.label18.TabIndex = 63;
            this.label18.Text = "Altitude";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(187, 32);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(83, 19);
            this.label20.TabIndex = 60;
            this.label20.Text = "D";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(98, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(83, 19);
            this.label21.TabIndex = 61;
            this.label21.Text = "I";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(12, 32);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(83, 19);
            this.label22.TabIndex = 62;
            this.label22.Text = "P";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // touchSpinAltD
            // 
            this.touchSpinAltD.Ch6MaxValue = 0.2D;
            this.touchSpinAltD.Ch6MinValue = 0D;
            this.touchSpinAltD.Ch6ParameterValue = "26";
            this.touchSpinAltD.Location = new System.Drawing.Point(193, 54);
            this.touchSpinAltD.Name = "touchSpinAltD";
            this.touchSpinAltD.ParameterName = "ACCEL_Z_D";
            this.touchSpinAltD.Size = new System.Drawing.Size(83, 391);
            this.touchSpinAltD.TabIndex = 58;
            this.touchSpinAltD.Value = 1.5D;
            this.touchSpinAltD.Verified = false;
            // 
            // touchSpinAltI
            // 
            this.touchSpinAltI.Ch6MaxValue = 0.5D;
            this.touchSpinAltI.Ch6MinValue = 0.001D;
            this.touchSpinAltI.Ch6ParameterValue = "";
            this.touchSpinAltI.Location = new System.Drawing.Point(104, 54);
            this.touchSpinAltI.Name = "touchSpinAltI";
            this.touchSpinAltI.ParameterName = "ACCEL_Z_I";
            this.touchSpinAltI.Size = new System.Drawing.Size(83, 391);
            this.touchSpinAltI.TabIndex = 58;
            this.touchSpinAltI.Value = 10D;
            this.touchSpinAltI.Verified = false;
            // 
            // touchSpinAltP
            // 
            this.touchSpinAltP.Ch6MaxValue = 0.5D;
            this.touchSpinAltP.Ch6MinValue = 0.05D;
            this.touchSpinAltP.Ch6ParameterValue = "6";
            this.touchSpinAltP.Location = new System.Drawing.Point(15, 54);
            this.touchSpinAltP.Name = "touchSpinAltP";
            this.touchSpinAltP.ParameterName = "ACCEL_Z_P";
            this.touchSpinAltP.Size = new System.Drawing.Size(83, 391);
            this.touchSpinAltP.TabIndex = 58;
            this.touchSpinAltP.Value = 1.5D;
            this.touchSpinAltP.Verified = false;
            // 
            // touchSpinYawImax
            // 
            this.touchSpinYawImax.Ch6MaxValue = 0D;
            this.touchSpinYawImax.Ch6MinValue = 0D;
            this.touchSpinYawImax.Ch6ParameterValue = "";
            this.touchSpinYawImax.Location = new System.Drawing.Point(298, 54);
            this.touchSpinYawImax.Name = "touchSpinYawImax";
            this.touchSpinYawImax.ParameterName = "ATC_RAT_YAW_IMAX";
            this.touchSpinYawImax.Size = new System.Drawing.Size(83, 391);
            this.touchSpinYawImax.TabIndex = 58;
            this.touchSpinYawImax.Value = 1.5D;
            this.touchSpinYawImax.Verified = false;
            // 
            // touchSpinYawD
            // 
            this.touchSpinYawD.Ch6MaxValue = 0.2D;
            this.touchSpinYawD.Ch6MinValue = 0D;
            this.touchSpinYawD.Ch6ParameterValue = "26";
            this.touchSpinYawD.Location = new System.Drawing.Point(193, 54);
            this.touchSpinYawD.Name = "touchSpinYawD";
            this.touchSpinYawD.ParameterName = "ATC_RAT_YAW_D";
            this.touchSpinYawD.Size = new System.Drawing.Size(83, 391);
            this.touchSpinYawD.TabIndex = 58;
            this.touchSpinYawD.Value = 1.5D;
            this.touchSpinYawD.Verified = false;
            // 
            // touchSpinYawI
            // 
            this.touchSpinYawI.Ch6MaxValue = 0.5D;
            this.touchSpinYawI.Ch6MinValue = 0.001D;
            this.touchSpinYawI.Ch6ParameterValue = "";
            this.touchSpinYawI.Location = new System.Drawing.Point(104, 54);
            this.touchSpinYawI.Name = "touchSpinYawI";
            this.touchSpinYawI.ParameterName = "ATC_RAT_YAW_I";
            this.touchSpinYawI.Size = new System.Drawing.Size(83, 391);
            this.touchSpinYawI.TabIndex = 58;
            this.touchSpinYawI.Value = 10D;
            this.touchSpinYawI.Verified = false;
            // 
            // touchSpinYawP
            // 
            this.touchSpinYawP.Ch6MaxValue = 0.5D;
            this.touchSpinYawP.Ch6MinValue = 0.05D;
            this.touchSpinYawP.Ch6ParameterValue = "6";
            this.touchSpinYawP.Location = new System.Drawing.Point(15, 54);
            this.touchSpinYawP.Name = "touchSpinYawP";
            this.touchSpinYawP.ParameterName = "ATC_RAT_YAW_P";
            this.touchSpinYawP.Size = new System.Drawing.Size(83, 391);
            this.touchSpinYawP.TabIndex = 58;
            this.touchSpinYawP.Value = 1.5D;
            this.touchSpinYawP.Verified = false;
            // 
            // touchSpinRollImax
            // 
            this.touchSpinRollImax.Ch6MaxValue = 0D;
            this.touchSpinRollImax.Ch6MinValue = 0D;
            this.touchSpinRollImax.Ch6ParameterValue = "";
            this.touchSpinRollImax.Location = new System.Drawing.Point(309, 54);
            this.touchSpinRollImax.Name = "touchSpinRollImax";
            this.touchSpinRollImax.ParameterName = "ATC_RAT_RLL_IMAX";
            this.touchSpinRollImax.Size = new System.Drawing.Size(83, 391);
            this.touchSpinRollImax.TabIndex = 58;
            this.touchSpinRollImax.Value = 1.5D;
            this.touchSpinRollImax.Verified = true;
            // 
            // touchSpinRollD
            // 
            this.touchSpinRollD.Ch6MaxValue = 0.2D;
            this.touchSpinRollD.Ch6MinValue = 0D;
            this.touchSpinRollD.Ch6ParameterValue = "51";
            this.touchSpinRollD.Location = new System.Drawing.Point(204, 54);
            this.touchSpinRollD.Name = "touchSpinRollD";
            this.touchSpinRollD.ParameterName = "ATC_RAT_RLL_D";
            this.touchSpinRollD.Size = new System.Drawing.Size(83, 391);
            this.touchSpinRollD.TabIndex = 58;
            this.touchSpinRollD.Value = 1.5D;
            this.touchSpinRollD.Verified = false;
            // 
            // touchSpinRollI
            // 
            this.touchSpinRollI.Ch6MaxValue = 0.5D;
            this.touchSpinRollI.Ch6MinValue = 0.01D;
            this.touchSpinRollI.Ch6ParameterValue = "50";
            this.touchSpinRollI.Location = new System.Drawing.Point(115, 54);
            this.touchSpinRollI.Name = "touchSpinRollI";
            this.touchSpinRollI.ParameterName = "ATC_RAT_RLL_I";
            this.touchSpinRollI.Size = new System.Drawing.Size(83, 391);
            this.touchSpinRollI.TabIndex = 58;
            this.touchSpinRollI.Value = 10D;
            this.touchSpinRollI.Verified = false;
            // 
            // touchSpinRollP
            // 
            this.touchSpinRollP.Ch6MaxValue = 0.4D;
            this.touchSpinRollP.Ch6MinValue = 0.04D;
            this.touchSpinRollP.Ch6ParameterValue = "49";
            this.touchSpinRollP.Location = new System.Drawing.Point(26, 54);
            this.touchSpinRollP.Name = "touchSpinRollP";
            this.touchSpinRollP.ParameterName = "ATC_RAT_RLL_P";
            this.touchSpinRollP.Size = new System.Drawing.Size(83, 391);
            this.touchSpinRollP.TabIndex = 58;
            this.touchSpinRollP.Value = 1.5D;
            this.touchSpinRollP.Verified = false;
            // 
            // touchSpinPitchImax
            // 
            this.touchSpinPitchImax.Ch6MaxValue = 0D;
            this.touchSpinPitchImax.Ch6MinValue = 0D;
            this.touchSpinPitchImax.Ch6ParameterValue = "";
            this.touchSpinPitchImax.Location = new System.Drawing.Point(298, 54);
            this.touchSpinPitchImax.Name = "touchSpinPitchImax";
            this.touchSpinPitchImax.ParameterName = "ATC_RAT_PIT_IMAX";
            this.touchSpinPitchImax.Size = new System.Drawing.Size(83, 391);
            this.touchSpinPitchImax.TabIndex = 58;
            this.touchSpinPitchImax.Value = 1.5D;
            this.touchSpinPitchImax.Verified = true;
            // 
            // touchSpinPitchD
            // 
            this.touchSpinPitchD.Ch6MaxValue = 0.2D;
            this.touchSpinPitchD.Ch6MinValue = 0D;
            this.touchSpinPitchD.Ch6ParameterValue = "48";
            this.touchSpinPitchD.Location = new System.Drawing.Point(193, 54);
            this.touchSpinPitchD.Name = "touchSpinPitchD";
            this.touchSpinPitchD.ParameterName = "ATC_RAT_PIT_D";
            this.touchSpinPitchD.Size = new System.Drawing.Size(83, 391);
            this.touchSpinPitchD.TabIndex = 58;
            this.touchSpinPitchD.Value = 1.5D;
            this.touchSpinPitchD.Verified = false;
            // 
            // touchSpinPitchI
            // 
            this.touchSpinPitchI.Ch6MaxValue = 0.5D;
            this.touchSpinPitchI.Ch6MinValue = 0.01D;
            this.touchSpinPitchI.Ch6ParameterValue = "47";
            this.touchSpinPitchI.Location = new System.Drawing.Point(104, 54);
            this.touchSpinPitchI.Name = "touchSpinPitchI";
            this.touchSpinPitchI.ParameterName = "ATC_RAT_PIT_I";
            this.touchSpinPitchI.Size = new System.Drawing.Size(83, 391);
            this.touchSpinPitchI.TabIndex = 58;
            this.touchSpinPitchI.Value = 10D;
            this.touchSpinPitchI.Verified = false;
            // 
            // touchSpinPitchP
            // 
            this.touchSpinPitchP.Ch6MaxValue = 0.4D;
            this.touchSpinPitchP.Ch6MinValue = 0.04D;
            this.touchSpinPitchP.Ch6ParameterValue = "46";
            this.touchSpinPitchP.Location = new System.Drawing.Point(15, 54);
            this.touchSpinPitchP.Name = "touchSpinPitchP";
            this.touchSpinPitchP.ParameterName = "ATC_RAT_PIT_P";
            this.touchSpinPitchP.Size = new System.Drawing.Size(83, 391);
            this.touchSpinPitchP.TabIndex = 58;
            this.touchSpinPitchP.Value = 1.5D;
            this.touchSpinPitchP.Verified = false;
            // 
            // droneStatus1
            // 
            this.droneStatus1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.droneStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.droneStatus1.Location = new System.Drawing.Point(0, 0);
            this.droneStatus1.Margin = new System.Windows.Forms.Padding(2);
            this.droneStatus1.Name = "droneStatus1";
            this.droneStatus1.Size = new System.Drawing.Size(1580, 63);
            this.droneStatus1.TabIndex = 69;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1580, 687);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelTop);
            this.Controls.Add(this.panel2);
            this.Name = "FormMain";
            this.Text = "Drone Tuner";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelTop.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBoxBaudrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxCOM;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Button buttonShowMavlink;
        private System.Windows.Forms.Button buttonClearCh6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label15;
        private TouchSpin touchSpinPitchP;
        private System.Windows.Forms.Label label16;
        private TouchSpin touchSpinYawP;
        private TouchSpin touchSpinRollP;
        private TouchSpin touchSpinPitchI;
        private TouchSpin touchSpinYawI;
        private TouchSpin touchSpinRollI;
        private TouchSpin touchSpinPitchD;
        private TouchSpin touchSpinYawD;
        private TouchSpin touchSpinRollD;
        private TouchSpin touchSpinPitchImax;
        private TouchSpin touchSpinYawImax;
        private TouchSpin touchSpinRollImax;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelTop;
        private DroneStatus droneStatus1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private TouchSpin touchSpinAltD;
        private TouchSpin touchSpinAltI;
        private TouchSpin touchSpinAltP;
    }
}

