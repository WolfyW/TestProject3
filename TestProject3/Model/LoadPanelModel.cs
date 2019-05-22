using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TestProject3.Model
{
    public class LoadPanelModel
    {
        public event EventHandler ChangeLimitValue;
        public event EventHandler ChangeValue;

        private long maxValue;
        private long minValue;
        private double currentValue;

        public long Maxvalue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                ChangeLimitValue?.Invoke(this, new EventArgs());
            }
        }

        public long MinValue
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
