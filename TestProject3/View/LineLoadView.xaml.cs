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
        public long CurrentValue
        {
            get { return model.Value; }
            set { model.Value = value; }
        }
    }
}
