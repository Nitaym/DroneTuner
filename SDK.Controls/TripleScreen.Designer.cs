namespace SDK.Controls
{
    partial class TripleScreen
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
            this.panelRightBottom = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panelClient = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panelRightTop = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panelRightBottom.SuspendLayout();
            this.panelClient.SuspendLayout();
            this.panelRightTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelRightBottom
            // 
            this.panelRightBottom.BackColor = System.Drawing.Color.DimGray;
            this.panelRightBottom.Controls.Add(this.label1);
            this.panelRightBottom.Controls.Add(this.splitter1);
            this.panelRightBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelRightBottom.Location = new System.Drawing.Point(382, 277);
            this.panelRightBottom.Margin = new System.Windows.Forms.Padding(2);
            this.panelRightBottom.Name = "panelRightBottom";
            this.panelRightBottom.Size = new System.Drawing.Size(275, 237);
            this.panelRightBottom.TabIndex = 0;
            this.panelRightBottom.DoubleClick += new System.EventHandler(this.panelRightBottm_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(126, 122);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Right Bottom";
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(273, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(2);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(2, 237);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter2.Location = new System.Drawing.Point(382, 514);
            this.splitter2.Margin = new System.Windows.Forms.Padding(2);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(275, 2);
            this.splitter2.TabIndex = 1;
            this.splitter2.TabStop = false;
            // 
            // panelClient
            // 
            this.panelClient.BackColor = System.Drawing.Color.DarkGray;
            this.panelClient.Controls.Add(this.label3);
            this.panelClient.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelClient.Location = new System.Drawing.Point(0, 0);
            this.panelClient.Margin = new System.Windows.Forms.Padding(2);
            this.panelClient.Name = "panelClient";
            this.panelClient.Size = new System.Drawing.Size(382, 516);
            this.panelClient.TabIndex = 2;
            this.panelClient.DoubleClick += new System.EventHandler(this.panelClient_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 208);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Client";
            // 
            // panelRightTop
            // 
            this.panelRightTop.BackColor = System.Drawing.Color.Gray;
            this.panelRightTop.Controls.Add(this.label2);
            this.panelRightTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRightTop.Location = new System.Drawing.Point(382, 0);
            this.panelRightTop.Margin = new System.Windows.Forms.Padding(2);
            this.panelRightTop.Name = "panelRightTop";
            this.panelRightTop.Size = new System.Drawing.Size(275, 277);
            this.panelRightTop.TabIndex = 3;
            this.panelRightTop.DoubleClick += new System.EventHandler(this.panelRightTop_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(126, 196);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Right Top";
            // 
            // TripleScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelRightTop);
            this.Controls.Add(this.panelRightBottom);
            this.Controls.Add(this.splitter2);
            this.Controls.Add(this.panelClient);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "TripleScreen";
            this.Size = new System.Drawing.Size(657, 516);
            this.Resize += new System.EventHandler(this.TripleScreen_Resize);
            this.panelRightBottom.ResumeLayout(false);
            this.panelRightBottom.PerformLayout();
            this.panelClient.ResumeLayout(false);
            this.panelClient.PerformLayout();
            this.panelRightTop.ResumeLayout(false);
            this.panelRightTop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelRightBottom;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelRightTop;
        private System.Windows.Forms.Label label2;
    }
}
