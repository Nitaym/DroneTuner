using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDK.Controls
{
    public static class ControlExtensions
    {
        public static void DoubleBuffering(this Control control, bool enable)
        {
            var doubleBufferPropertyInfo = control.GetType().GetProperty("DoubleBuffered", BindingFlags.Instance | BindingFlags.NonPublic);
            doubleBufferPropertyInfo.SetValue(control, enable, null);
        }

        public static void SetValueFormatted(this Label label, string text, bool value)
        {
            label.SafeInvoke(() =>
            {
                label.Text = text;

                if (value)
                {
                    label.ForeColor = Color.White;
                    label.BackColor = Color.FromArgb(255, 70, 136, 71);
                }
                else
                {
                    label.ForeColor = Color.White;
                    label.BackColor = Color.FromArgb(255, 185, 74, 72);
                }
            },
            false);
        }


    }
}
