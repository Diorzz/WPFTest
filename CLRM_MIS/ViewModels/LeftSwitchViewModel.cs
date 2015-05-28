using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using CLRM_MIS.Models;
using CLRM_MIS.Services;
using System.Windows.Input;
using System.Windows;
using CLRM_MIS.Views;
using DevExpress.Xpf.WindowsUI;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Geometry;
namespace CLRM_MIS.ViewModels
{
    class LeftSwitchViewModel:ViewModelBase
    {
        public ICommand TreeDoubleClick { get; private set; }

        public LeftSwitchViewModel() 
        {
            TreeDoubleClick = new DelegateCommand<Map>(TreeDoubleClickExecute,CanTreeDoubleClick);
        }

        private void TreeDoubleClickExecute(Map MyMap) 
        {
            MessageBox.Show("haha");
        }

        private bool CanTreeDoubleClick(Map MyMap) 
        {
            return true;
        }
    }
}
