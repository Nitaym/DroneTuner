using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SDK.Drone;

namespace DroneTuner
{
    public partial class TouchSpin : UserControl
    {
        private Color colorVerifed = Color.LightGreen;
        private Color colorUnverified = Color.Yellow;
        private Color colorError = Color.Pink;

        public double PlusPlusPlus = 0.1;
        public double PlusPlus = 0.01;
        public double Plus = 0.001;
        public double Minus = 0.001;
        public double MinusMinus = 0.01;
        public double MinusMinusMinus = 0.1;

        private string parameterName = "";
        public string ParameterName
        {
            get { return parameterName; }
            set { parameterName = value; }
        }

        private string ch6ParameterValue = "";
        public string Ch6ParameterValue
        {
            get { return ch6ParameterValue; }
            set { ch6ParameterValue = value; }
        }

        private double ch6MinValue;
        public double Ch6MinValue
        {
            get { return ch6MinValue; }
            set { ch6MinValue = value; }
        }
        private double ch6MaxValue;
        public double Ch6MaxValue
        {
            get { return ch6MaxValue; }
            set { ch6MaxValue = value; }
        }

        private double ch6Min = 0;
        private double ch6Max = 0;

        private bool ch6Set = false;

        public event Action<TouchSpin, double> OnValueChanged;


        public bool Verified
        {
            get { return numericUpDown.BackColor == colorVerifed; }
            set { numericUpDown.BackColor = value ? colorVerifed : colorUnverified; }
        }

        public double Value
        {
            get { return (double)numericUpDown.Value; }
            set { numericUpDown.Value = (decimal)value; }
        }

        public TouchSpin()
        {
            InitializeComponent();

        }

        private void RefreshCh6Button()
        {
            this.SafeInvoke(() =>
            {
                buttonSetAsCh6.BackColor = ch6Set ? Color.LightGreen : SystemColors.Control;

                if (ch6Set)
                    buttonSetAsCh6.Text = String.Format("Set as Ch6\r\n(min: {0:0.000} max {1:0.000})", ch6Min, ch6Max);
                else
                    buttonSetAsCh6.Text = "Set as Ch6";
            }, true);
        }


        private void TouchSpin_Load(object sender, EventArgs e)
        {
            CDroneManager.OnParamUpdate += CDroneManager_OnParamUpdate;

            buttonSetAsCh6.Enabled = ch6ParameterValue != "";
        }


        private void CDroneManager_OnParamUpdate(string parameterName, double parameterValue, int arg3)
        {
            if (parameterName == ParameterName)
            {
                this.SafeInvoke(() =>
                {
                    if (Math.Abs(parameterValue - Value) < 0.00001)
                    {
                        Verified = true;
                    }
                    else
                    {
                        numericUpDown.BackColor = colorError;
                    }
                    Value = parameterValue;
                }, true);
            }
            else if (parameterName == "TUNE")
            {
                if (ch6ParameterValue != "")
                {
                    ch6Set = (Math.Abs(parameterValue - double.Parse(ch6ParameterValue)) < 0.001);
                    RefreshCh6Button();
                }
            }

            // All of this could be replaced by using the data center
            else if (parameterName == "TUNE_LOW")
            {
                if (ch6Set)
                {
                    ch6Min = parameterValue;
                    RefreshCh6Button();
                }
            }
            else if (parameterName == "TUNE_HIGH")
            {
                if (ch6Set)
                {
                    ch6Max = parameterValue;
                    RefreshCh6Button();
                }
            }
        }

        private void NotifyValueChanged()
        {
            // Reset the timer
            timerWrite.Stop();
            timerWrite.Start();

            OnValueChanged?.Invoke(this, (double)numericUpDown.Value);

            if (ParameterName != "")
            {
                Verified = false;
            }
        }

        private void buttonPlusPlusPlus_Click(object sender, EventArgs e)
        {
            numericUpDown.Value += (decimal)PlusPlusPlus;
            NotifyValueChanged();
        }

        private void buttonPlusPlus_Click(object sender, EventArgs e)
        {
            numericUpDown.Value += (decimal)PlusPlus;
            NotifyValueChanged();
        }

        private void buttonPlus_Click(object sender, EventArgs e)
        {
            numericUpDown.Value += (decimal)Plus;
            NotifyValueChanged();
        }

        private void buttonMinus_Click(object sender, EventArgs e)
        {
            numericUpDown.Value = Math.Max(0, numericUpDown.Value - (decimal)Minus);
            NotifyValueChanged();
        }

        private void buttonMinusMinus_Click(object sender, EventArgs e)
        {
            numericUpDown.Value = Math.Max(0, numericUpDown.Value - (decimal)MinusMinus);
            NotifyValueChanged();
        }
        private void buttonMinusMinusMinus_Click(object sender, EventArgs e)
        {
            numericUpDown.Value = Math.Max(0, numericUpDown.Value - (decimal)MinusMinusMinus);
            NotifyValueChanged();
        }

        private void timerWrite_Tick(object sender, EventArgs e)
        {
            CDroneManager.WriteParameter(ParameterName, Value);
            CDroneManager.ReadParameter(ParameterName);

            timerWrite.Stop();
        }

        public void RefreshParameter()
        {
            CDroneManager.ReadParameter(ParameterName, false);
        }

        private void buttonSetAsCh6_Click(object sender, EventArgs e)
        {
            CDroneManager.WriteParameter("TUNE", double.Parse(ch6ParameterValue));
            CDroneManager.ReadParameter("TUNE", false);

            CDroneManager.WriteParameter("TUNE_LOW", Ch6MinValue);
            CDroneManager.WriteParameter("TUNE_HIGH", Ch6MaxValue);

            CDroneManager.ReadParameter("TUNE_LOW", true);
            CDroneManager.ReadParameter("TUNE_HIGH", true);
        }
    }
}
