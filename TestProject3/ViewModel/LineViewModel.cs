using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using TestProject3.Model;

namespace TestProject3.ViewModel
{
    class LineViewModel : INotifyPropertyChanged
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private LoadPanelModel model;

        public LineViewModel(LoadPanelModel model)
        {
            this.model = model;
            InitTimer();
        }

        private void InitTimer()
        {
            timer.Interval = TimeSpan.FromMilliseconds(50);
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, object e)
        {
            if (Value < model.Maxvalue)
                Value++;
            else
                timer.Stop();
        }

        public long Value
        {
            get
            {
                return model.Value;
                
            }
            set
            {
                model.Value = value;
                OnPropertyChanged();
            }
        }

        public long MaxValue
        {
            get { return model.Maxvalue; }
        }

        public long MinValue
        {
            get { return model.MinValue; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
