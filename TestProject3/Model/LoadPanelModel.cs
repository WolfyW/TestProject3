using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace TestProject3.Model
{
    public class LoadPanelModel
    {
        public event EventHandler ChangeValue;

        private long maxValue;
        private long minValue;

        public long Maxvalue
        {
            get { return maxValue; }
            set
            {
                maxValue = value;
                ChangeValue?.Invoke(this, new EventArgs());
            }
        }

        public long MinValue
        {
            get { return minValue; }
            set
            {
                minValue = value;
                ChangeValue?.Invoke(this, new EventArgs());
            }
        }

        public double Value{get;set;}
        public Color MarkColor { get; set; }
        public Color IndicatorColor { get; set; } = Colors.Green;
        public Color BackgroundColor { get; set; } = Colors.LightGray;
    }
}
