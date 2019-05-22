using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Threading;
using TestProject3.Model;

namespace TestProject3.ViewModel
{
    class LineViewModel : INotifyPropertyChanged
    {
        private DispatcherTimer timer = new DispatcherTimer();
        protected LoadPanelModel model;
        protected double oneStep;
        protected double maxWidth;
        protected double interval;
        protected double step;

        public LineViewModel(LoadPanelModel model)
        {
            this.model = model;
            model.ChangeLimitValue += MathInterval;
            model.ChangeValue += ChangeValue;
            maxWidth = 300;
            InitTimer();
        }

        private void InitTimer()
        {
            timer.Interval = TimeSpan.FromMilliseconds(20);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, object e)
        {
            if (model.Value < model.Maxvalue)
            {
                model.Value++;
                Console.WriteLine("model: " + model.Value);
                Console.WriteLine("Value: " + Value);
            }
            else
            {
                timer.Stop();
            }
        }

        protected double currentValue;
        public double Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                currentValue = value;
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
