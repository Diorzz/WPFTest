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
using ESRI.ArcGIS.Client.Tasks;
using ESRI.ArcGIS.Client.Symbols;
using CLRM_MIS.Views;
namespace CLRM_MIS.ViewModels
{
    class RibbonTabButtonCommandViewModel:ViewModelBase
    {
        public ICommand RibbonCBFTab { get; private set; }

        public RibbonTabButtonCommandViewModel() 
        {
            RibbonCBFTab = new DelegateCommand<NavigationFrame>(RibbonCBFTabExecute, CanRibbonCBFTab);
        }

        private void RibbonCBFTabExecute(NavigationFrame navigationframe) 
        {
            MessageBox.Show("");
            navigationframe.Source = new CBFView();
        }

        private bool CanRibbonCBFTab(NavigationFrame navigationframe) 
        {
            return true;
        }
    }
}
