using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

using TestProject3.Model;
using TestProject3.ViewModel;

namespace TestProject3.View
{
    /// <summary>
    /// Interaction logic for LineLoad.xaml
    /// </summary>
    public partial class LineLoad : UserControl
    {
        public static readonly DependencyProperty ValueProperty;
        public static readonly DependencyProperty MaxvalueProperty;
        public static readonly DependencyProperty MinvalueProperty;

        static LineLoad()
        {
            ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(LineLoad), new PropertyMetadata(default(double), OnValuePropertiesChange));
            MaxvalueProperty = DependencyProperty.Register("MaxValue", typeof(double), typeof(LineLoad), new PropertyMetadata(default(double), OnValuePropertiesChange));
            MinvalueProperty = DependencyProperty.Register("MinValue", typeof(double), typeof(LineLoad), new PropertyMetadata(default(double), OnValuePropertiesChange));
        }

        private static void OnValuePropertiesChange(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            switch (e.Property.Name)
            {
                case "Value": model.Value = (double)e.NewValue; break;
                case "MaxValue": model.Maxvalue = (double)e.NewValue; break;
                case "MinValue": model.MinValue = (double)e.NewValue; break;
                default: break;
            }
        }

        private static LoadPanelModel model = new LoadPanelModel();

        public LineLoad()
        {
            InitializeComponent();
            DataContext = new LineViewModel(model);
        }

        [DisplayName(@"MaxValue"), Description("максимальное значение"), Category("Values"), DefaultValue(100)]
        public double MaxValue
        {
            get { return (double)GetValue(MaxvalueProperty); }
            set { SetValue(MaxvalueProperty, value); }
        }

        [DisplayName(@"MinValue"), Description("минимальное значение"), Category("Values"), DefaultValue(0)]
        public double MinValue
        {
            get { return (double)GetValue(MinvalueProperty); }
            set { SetValue(MinvalueProperty, value); }
        }

        [DisplayName(@"Value"), Description("текущее значение"), Category("Values"), DefaultValue(0)]
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        [DisplayName(@"ColorIndicator"), Description("Цвет указателя заполнения"), Category("Colors"), DefaultValue("Blcak")]
        public Color ColorIndicator
        {
            get { return model.IndicatorColor; }
            set { model.IndicatorColor = value; }
        }

        [DisplayName(@"ColorBack"), Description("Цвет фона"), Category("Colors"), DefaultValue("LightGray")]
        public Color ColorBack
        {
            get { return model.BackgroundColor; }
            set { model.BackgroundColor = value; }
        }
    }
}
