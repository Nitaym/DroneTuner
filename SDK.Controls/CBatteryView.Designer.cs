namespace SDK.Controls
{
	partial class CBatteryView
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
            this.labelBatteryPercentage = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelCurrent = new System.Windows.Forms.Label();
            this.labelVoltage = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelBatteryPercentage
            // 
            this.labelBatteryPercentage.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelBatteryPercentage.Font = new System.Drawing.Font("Tahoma", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBatteryPercentage.ForeColor = System.Drawing.Color.White;
            this.labelBatteryPercentage.Location = new System.Drawing.Point(4, 4);
            this.labelBatteryPercentage.Name = "labelBatteryPercentage";
            this.labelBatteryPercentage.Size = new System.Drawing.Size(137, 32);
            this.labelBatteryPercentage.TabIndex = 1;
            this.labelBatteryPercentage.Tag = "";
            this.labelBatteryPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelCurrent);
            this.panel1.Controls.Add(this.labelVoltage);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(141, 12);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(178, 24);
            this.panel1.TabIndex = 2;
            // 
            // labelCurrent
            // 
            this.labelCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelCurrent.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCurrent.ForeColor = System.Drawing.Color.White;
            this.labelCurrent.Location = new System.Drawing.Point(0, 0);
            this.labelCurrent.Name = "labelCurrent";
            this.labelCurrent.Size = new System.Drawing.Size(107, 24);
            this.labelCurrent.TabIndex = 2;
            this.labelCurrent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelVoltage
            // 
            this.labelVoltage.Dock = System.Windows.Forms.DockStyle.Right;
            this.labelVoltage.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVoltage.ForeColor = System.Drawing.Color.White;
            this.labelVoltage.Location = new System.Drawing.Point(107, 0);
            this.labelVoltage.Name = "labelVoltage";
            this.labelVoltage.Size = new System.Drawing.Size(71, 24);
            this.labelVoltage.TabIndex = 1;
            this.labelVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CBatteryView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelBatteryPercentage);
            this.Name = "CBatteryView";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(323, 40);
            this.Load += new System.EventHandler(this.CBatteryView_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.Label labelBatteryPercentage;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label labelCurrent;
        private System.Windows.Forms.Label labelVoltage;
	}
}
