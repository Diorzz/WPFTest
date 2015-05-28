using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Ribbon;
using CLRM_MIS.Services;
using CLRM_MIS.Models;
using System.Collections.ObjectModel;

namespace CLRM_MIS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : DevExpress.Xpf.Core.DXWindow
    {
        public MainWindow()
        {
            
            
            InitializeComponent();
            //InsertDbTest inser = new InsertDbTest();
            //for (int i = 20000; i < 25000; i++)
            //{
            //    inser.Insert(i);
            //}
            //list = odb.GetAllFBF();
            //lb.ItemsSource = list;
            

        }
        //private ObservableCollection<FBFModels> list;
        //private void btn_Click(object sender, RoutedEventArgs e)
        //{
        //    OracleDataBaseServices odb = new OracleDataBaseServices();
        //    //FBFModels fbf = (FBFModels)lb.SelectedItem;
        //    odb.RemoveFBFByID(fbf);
        //    list.Remove(fbf);
        //}
    }
}
