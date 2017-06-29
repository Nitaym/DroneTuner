using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDK.Controls
{
    public partial class StatusLabel : UserControl
    {
        public enum EStatus
        {
            True,
            Maybe,
            False
        }

        bool status;

        public string Label
        {
            set { labelLabel.Text = value; }
            get { return labelLabel.Text; }
        }
        public string Value
        {
            set { labelValue.Text = value; }
            get { return labelValue.Text; }
        }
        public bool Status
        {
            set { status = value;  SetConnectedLabel(Value, status); }
            get { return status; }
        }

        public StatusLabel()
        {
            InitializeComponent();
        }

        public void SetConnectedLabel(string text, EStatus value)
        {
            labelValue.SafeInvoke(() =>
            {
                labelValue.Text = text;

                switch (value)
                {
                    case EStatus.True:
                        labelValue.ForeColor = Color.White;
                        labelValue.BackColor = Color.FromArgb(255, 70, 136, 71);
                        break;
                    case EStatus.Maybe:
                        labelValue.ForeColor = Color.White;
                        labelValue.BackColor = Color.FromArgb(255, 0xf0, 0xad, 0x4e);
                        break;
                    case EStatus.False:
                        labelValue.ForeColor = Color.White;
                        labelValue.BackColor = Color.FromArgb(255, 185, 74, 72);
                        break;
                }
            },
            false);
        }
        public void SetConnectedLabel(string text, bool value)
        {
            SetConnectedLabel(text, value ? EStatus.True : EStatus.False);
        }

        private void labelLabel_Click(object sender, EventArgs e)
        {
            OnClick(e);
        }
    }
}
