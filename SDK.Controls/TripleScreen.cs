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
    public partial class TripleScreen : UserControl
    {
        enum ESplitWindowState
        {
            RightTop,
            RightBottom,
            Client,
            Split
        }

        private ESplitWindowState SplitState = ESplitWindowState.Split;

        public TripleScreen()
        {
            InitializeComponent();
        }

        private void SetSplitScreen(ESplitWindowState state)
        {
            SplitState = state;

            switch (state)
            {
                case ESplitWindowState.RightTop:
                    panelRightBottom.Width = 0;
                    panelRightBottom.Height = 0;

                    panelClient.Width = 0;
                    break;
                case ESplitWindowState.RightBottom:
                    panelRightBottom.Width = this.Width;
                    panelRightBottom.Height = this.Height;

                    panelClient.Width = 0;
                    break;
                case ESplitWindowState.Client:
                    panelRightBottom.Width = 0;
                    panelRightBottom.Height = 0;
                   
                    panelClient.Height = this.Height;
                    panelClient.Width = this.Width;
                    break;
                case ESplitWindowState.Split:
                    panelRightBottom.Width = panelRightTop.Width = this.Width / 3;
                    panelRightBottom.Height = this.Height / 2;
                    panelClient.Width = (int)(this.Width * (2.0 / 3.0));
                    //panelClient.Height = this.Height / 3;
                    break;
                default:
                    break;
            }
        }

        private void TripleScreen_Resize(object sender, EventArgs e)
        {
            if (SplitState == ESplitWindowState.Split)
            {
                this.SuspendLayout();
                panelRightBottom.Width = panelRightTop.Width = this.Width / 2;
                this.ResumeLayout();
            }
        }

        private void panelClient_DoubleClick(object sender, EventArgs e)
        {
            if (SplitState == ESplitWindowState.Split)
                SetSplitScreen(ESplitWindowState.Client);
            else
                SetSplitScreen(ESplitWindowState.Split);
        }

        private void panelRightTop_DoubleClick(object sender, EventArgs e)
        {
            if (SplitState == ESplitWindowState.Split)
                SetSplitScreen(ESplitWindowState.RightTop);
            else
                SetSplitScreen(ESplitWindowState.Split);
        }

        private void panelRightBottm_DoubleClick(object sender, EventArgs e)
        {
            if (SplitState == ESplitWindowState.Split)
                SetSplitScreen(ESplitWindowState.RightBottom);
            else
                SetSplitScreen(ESplitWindowState.Split);
        }
    }
}
