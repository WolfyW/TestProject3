using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
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
        public ArrowLoad()
        {
            InitializeComponent();
            DataContext = new ArrowViewModel(model);
            AddMark();
        }

        private LoadPanelModel model = new LoadPanelModel();

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

        [DisplayName(@"MaximumValue"), Description("максимальное значение"), Category("Values"), DefaultValue(100)]
        public long MaximumValue
        {
            get { return model.Maxvalue; }
            set { model.Maxvalue = value; }
        }

        [DisplayName(@"MinimumValue"), Description("минимальное значение"), Category("Values"), DefaultValue(0)]
        public long MinimumValue
        {
            get { return model.MinValue; }
            set { model.MinValue = value; }
        }

        [DisplayName(@"Value"), Description("текущее значение"), DefaultValue(0)]
        public double CurrentValue
        {
            get { return model.Value; }
            set { model.Value = value; }
        }

        [DisplayName(@"ColorMark"), Description("Цвет рисок"), DefaultValue("Black")]
        public Color ColorMark
        {
            get { return model.MarkColor; }
            set { model.MarkColor = value; }
        }

        [DisplayName(@"ColorIndicator"), Description("Цвет указателя заполнения"), DefaultValue("Blcak")]
        public Color ColorIndicator
        {
            get { return model.IndicatorColor; }
            set { model.IndicatorColor = value; }
        }

        [DisplayName(@"ColorBack"), Description("Цвет фона"), DefaultValue("LightGray")]
        public Color ColorBack
        {
            get { return model.BackgroundColor; }
            set { model.BackgroundColor = value; }
        }
    }
}

