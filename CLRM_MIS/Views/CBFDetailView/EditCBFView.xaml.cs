using System;
using System.Collections.Generic;
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
using CLRM_MIS.Models;
using System.Collections.ObjectModel;
namespace CLRM_MIS.Views.CBFDetailView
{
    /// <summary>
    /// EditCBFView.xaml 的交互逻辑
    /// </summary>
    public partial class EditCBFView : UserControl
    {
        public EditCBFView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CBFModels model = new CBFModels();
            model = (CBFModels)this.DataContext;
            MessageBox.Show(model.Family[0].Name.ToString());
            
        }
    }
}
