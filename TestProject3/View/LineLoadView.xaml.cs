using System.ComponentModel;
using System.Windows.Controls;
using System.Windows.Media;

using TestProject3.Model;
using TestProject3.ViewModel;

namespace TestProject3.View
{
    /// <summary>
    /// Interaction logic for LineLoad.xaml
    /// </summary>
    public partial class LineLoadView : UserControl
    {
        LoadPanelModel model = new LoadPanelModel();
        public LineLoadView()
        {
            InitializeComponent();
            DataContext = new LineViewModel(model);
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

        [DisplayName(@"ColorIndicator"), Description("Цвет указателя заполнения"), DefaultValue("Green")]
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
