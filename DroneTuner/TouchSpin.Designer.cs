namespace DroneTuner
{
    partial class TouchSpin
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
            this.components = new System.ComponentModel.Container();
            this.buttonPlusPlus = new System.Windows.Forms.Button();
            this.buttonPlusPlusPlus = new System.Windows.Forms.Button();
            this.numericUpDown = new System.Windows.Forms.NumericUpDown();
            this.buttonMinusMinus = new System.Windows.Forms.Button();
            this.buttonMinusMinusMinus = new System.Windows.Forms.Button();
            this.timerWrite = new System.Windows.Forms.Timer(this.components);
            this.buttonMinus = new System.Windows.Forms.Button();
            this.buttonPlus = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonSetAsCh6 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPlusPlus
            // 
            this.buttonPlusPlus.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPlusPlus.Location = new System.Drawing.Point(0, 50);
            this.buttonPlusPlus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPlusPlus.Name = "buttonPlusPlus";
            this.buttonPlusPlus.Size = new System.Drawing.Size(111, 50);
            this.buttonPlusPlus.TabIndex = 7;
            this.buttonPlusPlus.Text = "+ 0.01";
            this.buttonPlusPlus.UseVisualStyleBackColor = true;
            this.buttonPlusPlus.Click += new System.EventHandler(this.buttonPlusPlus_Click);
            // 
            // buttonPlusPlusPlus
            // 
            this.buttonPlusPlusPlus.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPlusPlusPlus.Location = new System.Drawing.Point(0, 0);
            this.buttonPlusPlusPlus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPlusPlusPlus.Name = "buttonPlusPlusPlus";
            this.buttonPlusPlusPlus.Size = new System.Drawing.Size(111, 50);
            this.buttonPlusPlusPlus.TabIndex = 8;
            this.buttonPlusPlusPlus.Text = "+ 0.1";
            this.buttonPlusPlusPlus.UseVisualStyleBackColor = true;
            this.buttonPlusPlusPlus.Click += new System.EventHandler(this.buttonPlusPlusPlus_Click);
            // 
            // numericUpDown
            // 
            this.numericUpDown.DecimalPlaces = 4;
            this.numericUpDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown.Location = new System.Drawing.Point(0, 150);
            this.numericUpDown.Margin = new System.Windows.Forms.Padding(0);
            this.numericUpDown.Name = "numericUpDown";
            this.numericUpDown.Size = new System.Drawing.Size(111, 20);
            this.numericUpDown.TabIndex = 11;
            this.numericUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonMinusMinus
            // 
            this.buttonMinusMinus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonMinusMinus.Location = new System.Drawing.Point(0, 221);
            this.buttonMinusMinus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMinusMinus.Name = "buttonMinusMinus";
            this.buttonMinusMinus.Size = new System.Drawing.Size(111, 50);
            this.buttonMinusMinus.TabIndex = 9;
            this.buttonMinusMinus.Text = "- 0.01";
            this.buttonMinusMinus.UseVisualStyleBackColor = true;
            this.buttonMinusMinus.Click += new System.EventHandler(this.buttonMinusMinus_Click);
            // 
            // buttonMinusMinusMinus
            // 
            this.buttonMinusMinusMinus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonMinusMinusMinus.Location = new System.Drawing.Point(0, 271);
            this.buttonMinusMinusMinus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMinusMinusMinus.Name = "buttonMinusMinusMinus";
            this.buttonMinusMinusMinus.Size = new System.Drawing.Size(111, 50);
            this.buttonMinusMinusMinus.TabIndex = 10;
            this.buttonMinusMinusMinus.Text = "- 0.1";
            this.buttonMinusMinusMinus.UseVisualStyleBackColor = true;
            this.buttonMinusMinusMinus.Click += new System.EventHandler(this.buttonMinusMinusMinus_Click);
            // 
            // timerWrite
            // 
            this.timerWrite.Interval = 800;
            this.timerWrite.Tick += new System.EventHandler(this.timerWrite_Tick);
            // 
            // buttonMinus
            // 
            this.buttonMinus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonMinus.Location = new System.Drawing.Point(0, 171);
            this.buttonMinus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonMinus.Name = "buttonMinus";
            this.buttonMinus.Size = new System.Drawing.Size(111, 50);
            this.buttonMinus.TabIndex = 12;
            this.buttonMinus.Text = "- 0.001";
            this.buttonMinus.UseVisualStyleBackColor = true;
            this.buttonMinus.Click += new System.EventHandler(this.buttonMinus_Click);
            // 
            // buttonPlus
            // 
            this.buttonPlus.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPlus.Location = new System.Drawing.Point(0, 100);
            this.buttonPlus.Margin = new System.Windows.Forms.Padding(0);
            this.buttonPlus.Name = "buttonPlus";
            this.buttonPlus.Size = new System.Drawing.Size(111, 50);
            this.buttonPlus.TabIndex = 13;
            this.buttonPlus.Text = "+ 0.001";
            this.buttonPlus.UseVisualStyleBackColor = true;
            this.buttonPlus.Click += new System.EventHandler(this.buttonPlus_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonSetAsCh6);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 321);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(111, 71);
            this.panel1.TabIndex = 14;
            // 
            // buttonSetAsCh6
            // 
            this.buttonSetAsCh6.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonSetAsCh6.Location = new System.Drawing.Point(0, 21);
            this.buttonSetAsCh6.Margin = new System.Windows.Forms.Padding(0);
            this.buttonSetAsCh6.Name = "buttonSetAsCh6";
            this.buttonSetAsCh6.Size = new System.Drawing.Size(111, 50);
            this.buttonSetAsCh6.TabIndex = 11;
            this.buttonSetAsCh6.Text = "Set as Ch6";
            this.buttonSetAsCh6.UseVisualStyleBackColor = true;
            this.buttonSetAsCh6.Click += new System.EventHandler(this.buttonSetAsCh6_Click);
            // 
            // TouchSpin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.numericUpDown);
            this.Controls.Add(this.buttonPlus);
            this.Controls.Add(this.buttonMinus);
            this.Controls.Add(this.buttonPlusPlus);
            this.Controls.Add(this.buttonPlusPlusPlus);
            this.Controls.Add(this.buttonMinusMinus);
            this.Controls.Add(this.buttonMinusMinusMinus);
            this.Controls.Add(this.panel1);
            this.Name = "TouchSpin";
            this.Size = new System.Drawing.Size(111, 392);
            this.Load += new System.EventHandler(this.TouchSpin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonPlusPlus;
        private System.Windows.Forms.Button buttonPlusPlusPlus;
        private System.Windows.Forms.NumericUpDown numericUpDown;
        private System.Windows.Forms.Button buttonMinusMinus;
        private System.Windows.Forms.Button buttonMinusMinusMinus;
        private System.Windows.Forms.Timer timerWrite;
        private System.Windows.Forms.Button buttonMinus;
        private System.Windows.Forms.Button buttonPlus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSetAsCh6;
    }
}
