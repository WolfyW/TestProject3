using System;
using System.Windows.Media;

namespace TestProject3.Model
{
    public class LoadPanelModel
    {
        public event EventHandler ChangeLimitValue;
        public event EventHandler ChangeValue;

        private double _maxValue;
        private double _minValue;
        private double _currentValue;

        public double Maxvalue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                ChangeLimitValue?.Invoke(this, new EventArgs());
            }
        }

        public double MinValue
        {
            get { return _minValue; }
            set
            {
                _minValue = value;
                ChangeLimitValue?.Invoke(this, new EventArgs());
            }
        }

        public double Value
        {
            get
            {
                return _currentValue;
                
            }
            set
            {
                _currentValue = value;
                ChangeValue?.Invoke(this, new EventArgs());
            }
        }
        public Color MarkColor { get; set; }
        public Color IndicatorColor { get; set; } = Colors.Green;
        public Color BackgroundColor { get; set; } = Colors.LightGray;
    }
}
