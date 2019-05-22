using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using TestProject3.Model;

namespace TestProject3.ViewModel
{
    class ArrowViewModel : LineViewModel
    {
        public ArrowViewModel(LoadPanelModel model) : base(model)
        {
            maxWidth = Math.Abs(min) + max;
            Value = min;
        }

        private const int min = -135;
        private const int max = 135;

        public Color ColorMark
        {
            get
            {
                return model.MarkColor;
            }
            set
            {
                model.MarkColor = value;
                OnPropertyChanged();
            }
        }

        protected override void ChangeValue(object sender, EventArgs e)
        {
            double k = Math.Abs(model.Value - model.MinValue) / interval;
            Value = k * maxWidth - Math.Abs(min);
        }
    }
}
