using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using TestProject3.Model;

namespace TestProject3.ViewModel
{
    class LineViewModel : INotifyPropertyChanged
    {
        protected LoadPanelModel Model;
        protected double MaxWidth;
        protected double Interval;
        private const int Max = 300;

        public LineViewModel(LoadPanelModel model)
        {
            this.Model = model;
            model.ChangeLimitValue += MathInterval;
            model.ChangeValue += ChangeValue;
            MaxWidth = Max;
        }

        private double _currentValue;
        public double Value
        {
            get
            {
                return _currentValue;
            }
            set
            {
                _currentValue = value;
                Console.WriteLine("Value: " + Value);
                OnPropertyChanged("Value");
            }
        }

        protected virtual void ChangeValue(object sender, EventArgs e)
        {
            double k = Math.Abs(Model.Value - Model.MinValue) / Interval;
            Value = k * MaxWidth;
        }

        private void MathInterval(object sender, EventArgs e)
        {
            Model.Value = Model.MinValue;
            Interval =  Model.Maxvalue - Model.MinValue;
        }

        public Color BackgroundColor
        {
            get
            {
                return Model.BackgroundColor;
            }
            set
            {
                Model.BackgroundColor = value; 
                OnPropertyChanged();
            }

        }
        public Color IndicatorColor
        {
            get
            {
                return Model.IndicatorColor;
            }
            set
            {
                Model.IndicatorColor = value;
                OnPropertyChanged();
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(/*[CallerMemberName]*/string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
