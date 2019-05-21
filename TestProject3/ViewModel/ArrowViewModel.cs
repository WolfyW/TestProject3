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
        { }

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

        private double angel;
        public double Angel
        {
            get { return angel; }
            set
            {
                angel = value;
                OnPropertyChanged();
            }
        }

        public override long Value { get; set; }

        protected override void MathStep(object sender, EventArgs e)
        {
            base.MathStep(sender, e);
        }
    }
}
