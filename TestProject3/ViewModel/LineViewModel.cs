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
            model.ChangeValue += MathStep;
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
                Value = model.Value;
            }
            else
            {
                timer.Stop();
            }
        }

        private double lastValue;
        protected double currentValue;
        public double Value
        {
            get
            {
                return currentValue;
            }
            set
            {
                model.Value = value;
                if (model.Value - lastValue >= oneStep)
                {
                    lastValue = model.Value;
                    currentValue += step;
                    OnPropertyChanged();
                }
            }
        }

        private void T()
        {
            double a = Value - model.MinValue;
            a = Math.Abs(a) / interval;
        }

        protected virtual void MathStep(object sender, EventArgs e)
        {
            interval =  model.Maxvalue - model.MinValue;
            oneStep = Math.Abs(interval) * 1.0 / maxWidth * 1.0;
            if (oneStep < 1)
            {
                step = (int)(1 / oneStep);
            }
            else
            {
                step = 1;
            }
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
