using System;
using System.Windows.Media;
using TestProject3.Model;

namespace TestProject3.ViewModel
{
    class ArrowViewModel : LineViewModel
    {
        public ArrowViewModel(LoadPanelModel model) : base(model)
        {
            MaxWidth = Math.Abs(Min) + Max;
            Value = Min;
        }

        private const int Min = -135;
        private const int Max = 135;

        public Color ColorMark
        {
            get
            {
                return Model.MarkColor;
            }
            set
            {
                Model.MarkColor = value;
                OnPropertyChanged();
            }
        }

        protected override void ChangeValue(object sender, EventArgs e)
        {
            double k = Math.Abs(Model.Value - Model.MinValue) / Interval;
            Value = k * MaxWidth - Math.Abs(Min);
        }
    }
}
