using System;
using System.Windows.Media;

namespace TestProject3.Model
{
    public class LoadPanelModel
    {
        public event EventHandler ChangeLimitValue;
        public event EventHandler ChangeValue;

        private double maxValue;
        private double minValue;
        private double currentValue;

        public double Maxvalue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                ChangeLimitValue?.Invoke(this, new EventArgs());
            }
        }

        public double MinValue
        {
            get { return minValue; }
            set
            {
                minValue = value;
                ChangeLimitValue?.Invoke(this, new EventArgs());
            }
        }

        public double Value
        {
            get
            {
                return currentValue;
                
            }
            set
            {
                currentValue = value;
                ChangeValue?.Invoke(this, new EventArgs());
            }
        }
        public Color MarkColor { get; set; }
        public Color IndicatorColor { get; set; } = Colors.Green;
        public Color BackgroundColor { get; set; } = Colors.LightGray;
    }
}
