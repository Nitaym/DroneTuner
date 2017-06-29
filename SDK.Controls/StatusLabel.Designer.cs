namespace SDK.Controls
{
    partial class StatusLabel
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
            this.labelValue = new System.Windows.Forms.Label();
            this.labelLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // labelValue
            // 
            this.labelValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(74)))), ((int)(((byte)(72)))));
            this.labelValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelValue.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelValue.ForeColor = System.Drawing.Color.White;
            this.labelValue.Location = new System.Drawing.Point(107, 0);
            this.labelValue.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelValue.Name = "labelValue";
            this.labelValue.Size = new System.Drawing.Size(127, 40);
            this.labelValue.TabIndex = 45;
            this.labelValue.Text = "Offline";
            this.labelValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelValue.Click += new System.EventHandler(this.labelLabel_Click);
            // 
            // labelLabel
            // 
            this.labelLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.labelLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.labelLabel.Font = new System.Drawing.Font("Arial", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLabel.ForeColor = System.Drawing.Color.White;
            this.labelLabel.Location = new System.Drawing.Point(0, 0);
            this.labelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelLabel.Name = "labelLabel";
            this.labelLabel.Padding = new System.Windows.Forms.Padding(6, 0, 4, 0);
            this.labelLabel.Size = new System.Drawing.Size(107, 40);
            this.labelLabel.TabIndex = 44;
            this.labelLabel.Text = "Drone";
            this.labelLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelLabel.Click += new System.EventHandler(this.labelLabel_Click);
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(107, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 40);
            this.panel1.TabIndex = 46;
            // 
            // StatusLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelValue);
            this.Controls.Add(this.labelLabel);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "StatusLabel";
            this.Size = new System.Drawing.Size(234, 40);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelValue;
        private System.Windows.Forms.Label labelLabel;
        private System.Windows.Forms.Panel panel1;
    }
}
