using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SDK.Controls
{
    public static class CSafeInvoke
    {
        /// <summary>
        /// Execute a method on the control's owning thread. Taken from: 
        /// http://stackoverflow.com/questions/714666/is-it-appropriate-to-extend-control-to-provide-consistently-safe-invoke-begininvo
        /// </summary>
        /// <param name="uiElement">The control that is being updated.</param>
        /// <param name="updater">The method that updates uiElement.</param>
        /// <param name="forceSynchronous">True to force synchronous execution of 
        /// updater.  False to allow asynchronous execution if the call is marshalled
        /// from a non-GUI thread.  If the method is called on the GUI thread,
        /// execution is always synchronous.</param>
        /// 
        /// Usage:
        /// this.SafeInvoke((Action)delegate { SetFrame(doubles); }, false);
        /// or
        /// this.lblTimeDisplay.SafeInvoke(() => this.lblTimeDisplay.Text = this.task.Duration.ToString(), false);
        public static void SafeInvoke(this Control uiElement, Action updater, bool forceSynchronous)
        {
            if (uiElement == null)
            {
                throw new ArgumentNullException("uiElement");
            }

            if (uiElement.InvokeRequired)
            {
                if (forceSynchronous)
                {
                    uiElement.Invoke((Action)delegate { SafeInvoke(uiElement, updater, forceSynchronous); });
                }
                else
                {
                    uiElement.BeginInvoke((Action)delegate { SafeInvoke(uiElement, updater, forceSynchronous); });
                }
            }
            else
            {
                if (!uiElement.IsHandleCreated)
                {
                    // Do nothing if the handle isn't created already.  The user's responsible
                    // for ensuring that the handle they give us exists.
                    return;
                }

                if (uiElement.IsDisposed)
                {
                    // Do nothing.
                    //throw new ObjectDisposedException("Control is already disposed.");
                }

                updater();
            }
        }
    }
}
