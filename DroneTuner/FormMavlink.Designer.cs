namespace DroneTuner
{
    partial class FormMavlink
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "111",
            "222"}, -1);
            this.listViewMessages = new System.Windows.Forms.ListView();
            this.colName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripMessagesRight = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBoxOutgoing = new System.Windows.Forms.CheckBox();
            this.checkBoxIngoing = new System.Windows.Forms.CheckBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.listViewFilter = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonRemoveJunk = new System.Windows.Forms.Button();
            this.buttonNone = new System.Windows.Forms.Button();
            this.buttonAll = new System.Windows.Forms.Button();
            this.columnSysId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnCompId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripMessagesRight.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewMessages
            // 
            this.listViewMessages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnSysId,
            this.columnCompId,
            this.colName,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.listViewMessages.ContextMenuStrip = this.contextMenuStripMessagesRight;
            this.listViewMessages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewMessages.FullRowSelect = true;
            this.listViewMessages.GridLines = true;
            this.listViewMessages.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listViewMessages.Location = new System.Drawing.Point(0, 0);
            this.listViewMessages.Name = "listViewMessages";
            this.listViewMessages.Size = new System.Drawing.Size(568, 577);
            this.listViewMessages.TabIndex = 0;
            this.listViewMessages.UseCompatibleStateImageBehavior = false;
            this.listViewMessages.View = System.Windows.Forms.View.Details;
            this.listViewMessages.SelectedIndexChanged += new System.EventHandler(this.listViewMessages_SelectedIndexChanged);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Param1";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Param2";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Param3";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Param4";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Param5";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Param6";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Param7";
            // 
            // contextMenuStripMessagesRight
            // 
            this.contextMenuStripMessagesRight.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.contextMenuStripMessagesRight.Name = "contextMenuStripMessagesRight";
            this.contextMenuStripMessagesRight.Size = new System.Drawing.Size(102, 26);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxOutgoing);
            this.panel1.Controls.Add(this.checkBoxIngoing);
            this.panel1.Controls.Add(this.buttonClear);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 577);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 68);
            this.panel1.TabIndex = 1;
            // 
            // checkBoxOutgoing
            // 
            this.checkBoxOutgoing.AutoSize = true;
            this.checkBoxOutgoing.Checked = true;
            this.checkBoxOutgoing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOutgoing.Location = new System.Drawing.Point(710, 35);
            this.checkBoxOutgoing.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxOutgoing.Name = "checkBoxOutgoing";
            this.checkBoxOutgoing.Size = new System.Drawing.Size(69, 17);
            this.checkBoxOutgoing.TabIndex = 3;
            this.checkBoxOutgoing.Text = "Outgoing";
            this.checkBoxOutgoing.UseVisualStyleBackColor = true;
            // 
            // checkBoxIngoing
            // 
            this.checkBoxIngoing.AutoSize = true;
            this.checkBoxIngoing.Checked = true;
            this.checkBoxIngoing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIngoing.Location = new System.Drawing.Point(710, 14);
            this.checkBoxIngoing.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.checkBoxIngoing.Name = "checkBoxIngoing";
            this.checkBoxIngoing.Size = new System.Drawing.Size(61, 17);
            this.checkBoxIngoing.TabIndex = 2;
            this.checkBoxIngoing.Text = "Ingoing";
            this.checkBoxIngoing.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(3, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(106, 61);
            this.buttonClear.TabIndex = 1;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.listViewFilter);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(568, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(218, 577);
            this.panel2.TabIndex = 3;
            // 
            // listViewFilter
            // 
            this.listViewFilter.CheckBoxes = true;
            this.listViewFilter.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.listViewFilter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewFilter.Location = new System.Drawing.Point(0, 0);
            this.listViewFilter.Name = "listViewFilter";
            this.listViewFilter.Size = new System.Drawing.Size(218, 513);
            this.listViewFilter.TabIndex = 3;
            this.listViewFilter.UseCompatibleStateImageBehavior = false;
            this.listViewFilter.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 201;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonRemoveJunk);
            this.panel3.Controls.Add(this.buttonNone);
            this.panel3.Controls.Add(this.buttonAll);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 513);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(218, 64);
            this.panel3.TabIndex = 4;
            // 
            // buttonRemoveJunk
            // 
            this.buttonRemoveJunk.Location = new System.Drawing.Point(2, 32);
            this.buttonRemoveJunk.Name = "buttonRemoveJunk";
            this.buttonRemoveJunk.Size = new System.Drawing.Size(106, 28);
            this.buttonRemoveJunk.TabIndex = 1;
            this.buttonRemoveJunk.Text = "Remove Junk";
            this.buttonRemoveJunk.UseVisualStyleBackColor = true;
            this.buttonRemoveJunk.Click += new System.EventHandler(this.buttonRemoveJunk_Click);
            // 
            // buttonNone
            // 
            this.buttonNone.Location = new System.Drawing.Point(109, 2);
            this.buttonNone.Name = "buttonNone";
            this.buttonNone.Size = new System.Drawing.Size(106, 28);
            this.buttonNone.TabIndex = 0;
            this.buttonNone.Text = "None";
            this.buttonNone.UseVisualStyleBackColor = true;
            this.buttonNone.Click += new System.EventHandler(this.buttonNone_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.Location = new System.Drawing.Point(2, 2);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(106, 28);
            this.buttonAll.TabIndex = 0;
            this.buttonAll.Text = "All";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.buttonAll_Click);
            // 
            // columnSysId
            // 
            this.columnSysId.Text = "SID";
            this.columnSysId.Width = 35;
            // 
            // columnCompId
            // 
            this.columnCompId.Text = "CID";
            this.columnCompId.Width = 32;
            // 
            // FormMavlink
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 645);
            this.Controls.Add(this.listViewMessages);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "FormMavlink";
            this.Text = "FormMavlink";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMavlink_FormClosing);
            this.Load += new System.EventHandler(this.FormMavlink_Load);
            this.contextMenuStripMessagesRight.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewMessages;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView listViewFilter;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonNone;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripMessagesRight;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonRemoveJunk;
        private System.Windows.Forms.CheckBox checkBoxOutgoing;
        private System.Windows.Forms.CheckBox checkBoxIngoing;
        private System.Windows.Forms.ColumnHeader columnSysId;
        private System.Windows.Forms.ColumnHeader columnCompId;
    }
}