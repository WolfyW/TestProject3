using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using TestProject3.Model;

namespace TestProject3.ViewModel
{
    class LineViewModel : INotifyPropertyChanged
    {
        protected LoadPanelModel model;
        protected double maxWidth;
        protected double interval;

        public LineViewModel(LoadPanelModel model)
        {
            this.model = model;
            model.ChangeLimitValue += MathInterval;
            model.ChangeValue += ChangeValue;
            maxWidth = 300;
        }

        private double currentValue;
        protected double Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
                Console.WriteLine("Value: " + Value);
                OnPropertyChanged();
            }
        }

        protected virtual void ChangeValue(object sender, EventArgs e)
        {
            double k = Math.Abs(model.Value - model.MinValue) / interval;
            Value = k * maxWidth;
        }

        private void MathInterval(object sender, EventArgs e)
        {
            model.Value = model.MinValue;
            interval =  model.Maxvalue - model.MinValue;
        }

        public Color BackgroundColor
        {
            get
            {
                return model.BackgroundColor;
            }
            set
            {
                model.BackgroundColor = value; 
                OnPropertyChanged();
            }

        }
        public Color IndicatorColor
        {
            get
            {
                return model.IndicatorColor;
            }
            set
            {
                model.IndicatorColor = value;
                OnPropertyChanged();
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
