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
using DevExpress.Mvvm.DataAnnotations;
using System.Collections.ObjectModel;

namespace CLRM_MIS.ViewModels
{
    class MainFormViewModel:ViewModelBase
    {
        private bool PreveViewBtn = false;
        private bool NextViewBtn = false;
        List<Envelope> _extentHistory = new List<Envelope>();
        int _currentExtentIndex = 0;
        bool _newExtent = true;
        private bool IsSwitch = true;

        public Map Mainmap;
        public int count { get; set; }
        public MainFormViewModel() 
        {
            ZoomInMap = new DelegateCommand<Map>(OnZoomInMap, CanZoomInMap);
            ZoomOutMap = new DelegateCommand<Map>(OnZoomOutMap, CanZoomOutMap);
            ZoomToFullMap = new DelegateCommand<Map>(OnZoomToFullMap, CanZoomToFullMap);
            MapLoaded = new DelegateCommand<Map>(MapLoadedExecuted, CanMapLoaded);
            CreateNewWindow = new DelegateCommand<object>(CreateDocument);
            DeleteCBF = new DelegateCommand<CBFModels>(OnDeleteCBF);
            TreeViewSelectedItem = new DelegateCommand(OnTreeViewSelectedItemExecuted);
            RefreshCBF = new DelegateCommand(OnRefreshCBFExecuted);
            CreateEditCBFWindow = new DelegateCommand<CBFModels>(OnCreateEditCBFWindow);
            
        }
        //新建窗体服务
        public IDocumentManagerService DocumentManagerService { get { return GetService<IDocumentManagerService>(); } }

        //承包方集合
        public ObservableCollection<CBFModels> CBFModel
        {
            get { return GetProperty(() => CBFModel); }
            set { SetProperty(() => CBFModel, value); }
        }
        public bool IsDeleteCanExecuted { get; set; }

        public ICommand RefreshCBF { get; private set; }
        public ICommand DeleteCBF { get; private set; }
        //新建窗体命令
        public ICommand CreateNewWindow { get; set; }
        public ICommand ZoomInMap { get; private set; }
        public ICommand ZoomOutMap { get; private set; }
        public ICommand ZoomToFullMap { get; set; }
        public ICommand MapLoaded { get; private set; }
        public ICommand CreateEditCBFWindow { get; private set; }

        public ICommand TreeViewSelectedItem { get; private set; }

        public void OnTreeViewSelectedItemExecuted() 
        {
            IsDeleteCanExecuted = true;
        }
        public void OnRefreshCBFExecuted() 
        {
            GetData();
        }
        public void OnDeleteCBF(CBFModels model)
        {
            if (MessageBox.Show("您确定要删除数据？", "删除承包方", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                CBFDatabaseServices db = new CBFDatabaseServices();
                db.DeleteCBF(model);
                CBFModel.Remove(model);

            }

        }
        private void MapLoadedExecuted(Map Mymap)
        {
            Mainmap = Mymap;
        }
        private bool CanMapLoaded(Map MyMap) { return true; }
        //放大地图
        private void OnZoomInMap(Map myMap) 
        {
            myMap.Zoom(1.6); 
        }
        
        private bool CanZoomInMap(Map myMap) 
        {
            if (myMap!=null) 
            {
                return true;
            }
            else 
            {
                return false;
            }
        }
        //缩小地图
        private void OnZoomOutMap(Map myMap)
        {
            myMap.Zoom(0.6);
        }
        private bool CanZoomOutMap(Map myMap)
        {
            if (myMap != null)
            {
                return true;
                
            }
            else
            {
                return false;
            }
        }

        //全图浏览
        private void OnZoomToFullMap(Map MyMap) 
        {
            MyMap.ZoomTo(MyMap.Layers.GetFullExtent());
        }
        private bool CanZoomToFullMap(Map MyMap) 
        {
            if (MyMap != null)
                return true;
            else
                return false;
        }

        private void MyMap_ExtentChanged(object sender, ExtentEventArgs e)
        {
            if (e.OldExtent == null)
            {
                _extentHistory.Add(e.NewExtent.Clone());
                return;
            }

            if (_newExtent)
            {
                _currentExtentIndex++;

                if (_extentHistory.Count - _currentExtentIndex > 0)
                    _extentHistory.RemoveRange(_currentExtentIndex, (_extentHistory.Count - _currentExtentIndex));

                if (PreveViewBtn == true)
                {
                    NextViewBtn = false;
                }

                _extentHistory.Add(e.NewExtent.Clone());

                if (PreveViewBtn == false)
                {
                    NextViewBtn = true;
                }
            }
            else
            {
                _newExtent = true;
            }
        }
       
        
        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();


            GetData();
        }

        private void GetData() 
        {
            CBFDatabaseServices db = new CBFDatabaseServices();
            ObservableCollection<CBFModels> CBF = db.GetAllCBF();
            foreach (var i in CBF)
            {
                i.Family = db.GetAllFamily(i);
            }
            CBFModel = CBF;

            InsertDbTest insert = new InsertDbTest();
            insert.CountNum();
            count = insert.Count;
        }

        
        
        /// <summary>
        /// 新建承包方窗口
        /// </summary>
        /// <param name="arg">窗口ViewModel参数</param>
        public void CreateDocument(object arg)
        {
            IDocument doc = DocumentManagerService.FindDocument(DocumentManagerService, arg);
            if (doc == null)
            {
                doc = DocumentManagerService.CreateDocument("NewCBFView", arg);
                doc.Id = DocumentManagerService.Documents.Count<IDocument>();
            }
            doc.Show();
        }
        /// <summary>
        /// 新建承包方编辑窗口
        /// </summary>
        /// <param name="model"></param>
        public void OnCreateEditCBFWindow(CBFModels model) 
        {
            IDocument doc = DocumentManagerService.FindDocument(DocumentManagerService, model);
            if (doc == null)
            {
                doc = DocumentManagerService.CreateDocument("EditCBFView", model);
                doc.Id = DocumentManagerService.Documents.Count<IDocument>();
            }
            doc.Show();
        }
    }
}
