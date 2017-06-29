namespace DroneTuner
{
    partial class DroneStatus
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelHeading = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labelDroneStatusMessage = new System.Windows.Forms.Label();
            this.labelAlt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelHDOP = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.labelEKF = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMode = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cBatteryView1 = new SDK.Controls.CBatteryView();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelHeading
            // 
            this.labelHeading.BackColor = System.Drawing.Color.Gray;
            this.labelHeading.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.labelHeading.ForeColor = System.Drawing.Color.White;
            this.labelHeading.Location = new System.Drawing.Point(501, 9);
            this.labelHeading.Name = "labelHeading";
            this.labelHeading.Size = new System.Drawing.Size(59, 20);
            this.labelHeading.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(416, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 19);
            this.label6.TabIndex = 23;
            this.label6.Text = "Heading:";
            // 
            // labelDroneStatusMessage
            // 
            this.labelDroneStatusMessage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelDroneStatusMessage.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.labelDroneStatusMessage.ForeColor = System.Drawing.Color.White;
            this.labelDroneStatusMessage.Location = new System.Drawing.Point(0, 39);
            this.labelDroneStatusMessage.Name = "labelDroneStatusMessage";
            this.labelDroneStatusMessage.Padding = new System.Windows.Forms.Padding(9, 0, 0, 0);
            this.labelDroneStatusMessage.Size = new System.Drawing.Size(789, 25);
            this.labelDroneStatusMessage.TabIndex = 22;
            this.labelDroneStatusMessage.Text = "Waiting...";
            this.labelDroneStatusMessage.Click += new System.EventHandler(this.labelDroneStatusMessage_Click);
            // 
            // labelAlt
            // 
            this.labelAlt.BackColor = System.Drawing.Color.Gray;
            this.labelAlt.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.labelAlt.ForeColor = System.Drawing.Color.White;
            this.labelAlt.Location = new System.Drawing.Point(49, 10);
            this.labelAlt.Name = "labelAlt";
            this.labelAlt.Size = new System.Drawing.Size(60, 19);
            this.labelAlt.TabIndex = 21;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(587, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "HDOP:";
            // 
            // labelHDOP
            // 
            this.labelHDOP.BackColor = System.Drawing.Color.Gray;
            this.labelHDOP.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.labelHDOP.ForeColor = System.Drawing.Color.White;
            this.labelHDOP.Location = new System.Drawing.Point(656, 9);
            this.labelHDOP.Name = "labelHDOP";
            this.labelHDOP.Size = new System.Drawing.Size(59, 20);
            this.labelHDOP.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(278, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 19);
            this.label8.TabIndex = 13;
            this.label8.Text = "EKF:";
            // 
            // labelEKF
            // 
            this.labelEKF.BackColor = System.Drawing.Color.Gray;
            this.labelEKF.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.labelEKF.ForeColor = System.Drawing.Color.White;
            this.labelEKF.Location = new System.Drawing.Point(332, 9);
            this.labelEKF.Name = "labelEKF";
            this.labelEKF.Size = new System.Drawing.Size(59, 20);
            this.labelEKF.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(132, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 17;
            this.label4.Text = "Mode: ";
            // 
            // labelMode
            // 
            this.labelMode.BackColor = System.Drawing.Color.Gray;
            this.labelMode.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.labelMode.ForeColor = System.Drawing.Color.White;
            this.labelMode.Location = new System.Drawing.Point(191, 10);
            this.labelMode.Name = "labelMode";
            this.labelMode.Size = new System.Drawing.Size(59, 20);
            this.labelMode.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(7, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 19);
            this.label3.TabIndex = 12;
            this.label3.Text = "Alt:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cBatteryView1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(789, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(328, 64);
            this.panel2.TabIndex = 49;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(40)))));
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 64);
            this.label2.TabIndex = 15;
            this.label2.Text = "Battery";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cBatteryView1
            // 
            this.cBatteryView1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(140)))), ((int)(((byte)(140)))), ((int)(((byte)(140)))));
            this.cBatteryView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cBatteryView1.Location = new System.Drawing.Point(81, 0);
            this.cBatteryView1.Margin = new System.Windows.Forms.Padding(4);
            this.cBatteryView1.Name = "cBatteryView1";
            this.cBatteryView1.Padding = new System.Windows.Forms.Padding(4);
            this.cBatteryView1.Size = new System.Drawing.Size(247, 64);
            this.cBatteryView1.TabIndex = 13;
            // 
            // DroneStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.Controls.Add(this.labelHeading);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.labelDroneStatusMessage);
            this.Controls.Add(this.labelAlt);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelHDOP);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.labelEKF);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelMode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel2);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DroneStatus";
            this.Size = new System.Drawing.Size(1117, 64);
            this.Resize += new System.EventHandler(this.DroneStatusBar_Resize);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelHeading;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label labelDroneStatusMessage;
        private System.Windows.Forms.Label labelAlt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelHDOP;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label labelEKF;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelMode;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private SDK.Controls.CBatteryView cBatteryView1;
        private System.Windows.Forms.Label label2;


    }
}
