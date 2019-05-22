using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Shapes;
using TestProject3.Converters;
using TestProject3.Model;
using TestProject3.ViewModel;

namespace TestProject3.View
{
    /// <summary>
    /// Interaction logic for ArrowLoad.xaml
    /// </summary>
    public partial class ArrowLoad : UserControl
    {
        public static readonly DependencyProperty ValueProperty;
        public static readonly DependencyProperty MaxvalueProperty;
        public static readonly DependencyProperty MinvalueProperty;

        static ArrowLoad()
        {
            ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(ArrowLoad), new PropertyMetadata(default(double), OnValuePropertiesChange));
            MaxvalueProperty = DependencyProperty.Register("MaxValue", typeof(double), typeof(ArrowLoad), new PropertyMetadata(default(double), OnValuePropertiesChange));
            MinvalueProperty = DependencyProperty.Register("MinValue", typeof(double), typeof(ArrowLoad), new PropertyMetadata(default(double), OnValuePropertiesChange));
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

        public ArrowLoad()
        {
            InitializeComponent();
            DataContext = new ArrowViewModel(model);
            AddMark();
        }

        private void AddMark()
        {
            Binding bind = new Binding();
            bind.Path = new PropertyPath("ColorMark");
            bind.Mode = BindingMode.TwoWay;
            bind.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;
            bind.Converter = new ColorConvert();

            for (int i = -135; i <= 135; i += 10)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = 2;
                rectangle.Height = 10;
                rectangle.Fill = new SolidColorBrush(model.MarkColor);
                rectangle.RenderTransformOrigin = new Point(0.5, 0.5);
                TransformGroup transforms = new TransformGroup();
                transforms.Children.Add(new TranslateTransform() {Y = -95});
                transforms.Children.Add(new RotateTransform() {Angle = i});
                rectangle.RenderTransform = transforms;
                rectangle.SetBinding(Shape.FillProperty, bind);
                baseGrid.Children.Add(rectangle);
            }
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

        [DisplayName(@"ColorMark"), Description("Цвет рисок"), Category("Colors"), DefaultValue("Black")]
        public Color ColorMark
        {
            get { return model.MarkColor; }
            set { model.MarkColor = value; }
        }
    }
}

