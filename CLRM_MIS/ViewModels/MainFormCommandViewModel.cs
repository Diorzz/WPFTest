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
using System.Windows.Controls;

namespace CLRM_MIS.ViewModels
{
    class MainFormCommandViewModel
    {
        public static Map MainMap;
        public static Grid Maingrid;
        public static MainFormView mainform;
        private bool IsSwitch = true;
        private bool PreveViewBtn = false;
        private bool NextViewBtn = false;
        bool _newExtent = true;
        int _currentExtentIndex = 0;
        List<Envelope> _extentHistory = new List<Envelope>();
        public MainFormCommandViewModel() 
        {
            Switch = new DelegateCommand<NavigationFrame>(SwitchTo, CanSwitchTo);
            TreeItemClick = new DelegateCommand<string>(TreeItemClickExecute, CanTreeItemClick);
            ZoomInMap = new DelegateCommand<Map>(OnZoomInMap, CanZoomInMap);
            ZoomOutMap = new DelegateCommand<Map>(OnZoomOutMap, CanZoomOutMap);
            ZoomToFullMap = new DelegateCommand<Map>(OnZoomToFullMap, CanZoomToFullMap);
            MapLoaded = new DelegateCommand<Map>(MapLoadedExecuted, CanMapLoaded);
            MainGridLoaded = new DelegateCommand<Grid>(MainGridLoadeExecute, CanMainGridExecute);
            MainFormLoaded = new DelegateCommand<MainFormView>(MainFormExecute, CanMainFormExecute);
            RefreshMap = new DelegateCommand(RefreshMapExecute, CanRefreshMap);
            RibbonCBFTab = new DelegateCommand<NavigationFrame>(RibbonCBFTabExecute, CanRibbonCBFTab);
            RibbonHeadTab = new DelegateCommand<NavigationFrame>(RibbonHeadTabExecute, CanRibbonHeadTab);
            
        }
        
        public ICommand ZoomInMap { get; private set; }//放大地图命令
        public ICommand ZoomOutMap { get; private set; }//缩小地图命令
        public ICommand ZoomToFullMap { get; set; }//全图命令
        public ICommand MapLoaded { get; private set; }//地图加载命令
        public ICommand TreeItemClick { get; private set; }//TreeViewItem单击命令
        public ICommand Switch { get; private set; }//切换开关按钮命令

        public ICommand RefreshMap { get; private set; }//刷新地图
        public ICommand RibbonCBFTab { get; private set; }
        public ICommand RibbonHeadTab { get; private set; }
        public ICommand MainFormLoaded { get; private set; }
        public ICommand MainGridLoaded { get; private set; }

       

        private void MainGridLoadeExecute(Grid MainGrid) 
        {
            Maingrid = MainGrid;
        }
        private bool CanMainGridExecute(Grid MainGrid) 
        {
            return true;
        }
        private void MainFormExecute(MainFormView MainForm) 
        {
            mainform = MainForm;
        }
        public bool CanMainFormExecute(MainFormView MainForm) 
        {
            return true;
        }
        private void RibbonCBFTabExecute(NavigationFrame navigationframe)
        {
            navigationframe.Source = new CBFView();
        }

        private bool CanRibbonCBFTab(NavigationFrame navigationframe)
        {
            return true;
        }
        private void RibbonHeadTabExecute(NavigationFrame navigationframe)
        {
            navigationframe.Source = Maingrid;
        }

        private bool CanRibbonHeadTab(NavigationFrame navigationframe)
        {
            return true;
        }
        public void RefreshMapExecute() 
        {
            
        }
        public bool CanRefreshMap()
        {
            if (MainMap!=null)
                return true;
            else
                return false;
        }
        /// <summary>
        /// 地图加载事件触发命令，将view中的地图引用传递到ViewModel中
        /// </summary>
        /// <param name="Mymap"></param>
        private void MapLoadedExecuted(Map Mymap)
        {
            MainMap = Mymap;
        }
        private bool CanMapLoaded(Map MyMap) { return true; }
        //放大地图
        private void OnZoomInMap(Map myMap)
        {
            myMap.Zoom(1.6);
        }

        private bool CanZoomInMap(Map myMap)
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

        

        public void SwitchTo(NavigationFrame nav)
        {
            nav.Source = new UserControl2();
            IsSwitch = false;
        }
        public bool CanSwitchTo(NavigationFrame nav)
        {
            return IsSwitch;
        }
        /// <summary>
        /// TreeViewItem单击触发Map查询功能
        /// </summary>
        /// <param name="id"></param>
        private void TreeItemClickExecute(string id)
        {
            CBDKXXDatabaseServices dk = new CBDKXXDatabaseServices();
            string dkbm = dk.FindDkByCBF(id);
            QueryTask queryTask = new QueryTask("http://localhost:6080/arcgis/rest/services//fckj/MapServer/0");
            queryTask.ExecuteCompleted += QueryTask_ExecuteCompleted;
            queryTask.Failed += QueryTask_Failed;

            // 查询，返回地块信息
            Query query = new Query();
            query.ReturnGeometry = true;
            query.OutFields.AddRange(new string[] { "DKMC", "ZJRXM"});

            // 使用承包方编码查找地块编码，锁定地块 
            query.Where = string.Format("DKBM='{0}'", dkbm);

            queryTask.ExecuteAsync(query);
        }

        private bool CanTreeItemClick(string id)
        {
            return true;
        }

        /// <summary>
        /// 查询完成后触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void QueryTask_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            ResourceDictionary resourcedic=new ResourceDictionary();
            resourcedic.Source=new Uri("Resources/MapSymbolResources.xaml",UriKind.Relative);
            GraphicsLayer graphicsLayer = MainMap.Layers["MyGraphicsLayer"] as GraphicsLayer;
            graphicsLayer.ClearGraphics();

            // Check for new results. 
            FeatureSet featureSet = args.FeatureSet;
            if (featureSet.Features.Count > 0)
            {
                if (featureSet.Features.Count > 1)
                {
                    foreach (Graphic resultFeature in featureSet.Features)
                    {

                        resultFeature.Symbol = resourcedic["ResultsFillSymbol"] as ESRI.ArcGIS.Client.Symbols.Symbol;
                        graphicsLayer.Graphics.Add(resultFeature);
                    }
                }
                else 
                {
                    featureSet.Features[0].Symbol = resourcedic["ResultsFillSymbol"] as ESRI.ArcGIS.Client.Symbols.Symbol;
                    graphicsLayer.Graphics.Add(featureSet.Features[0]);
                    ESRI.ArcGIS.Client.Geometry.Envelope selectedFeatureExtent = featureSet.Features[0].Geometry.Extent;

                    double expandPercentage = 100;

                    double widthExtend = selectedFeatureExtent.Width * (expandPercentage / 100);
                    double heightExtend = selectedFeatureExtent.Height * (expandPercentage / 100);

                    ESRI.ArcGIS.Client.Geometry.Envelope displayExtent = new Envelope
                    (
                        selectedFeatureExtent.XMin,
                        selectedFeatureExtent.YMin,
                        selectedFeatureExtent.XMax,
                        selectedFeatureExtent.YMax

                    );
                    MainMap.ZoomTo(displayExtent);
                }
            }
            else
            {
                MessageBox.Show("没有对应的数据");
            }
            
        }

        /// <summary>
        /// 查询失败触发的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void QueryTask_Failed(object sender, TaskFailedEventArgs args)
        {
            MessageBox.Show("查询失败，请检查数据正确性: " + args.Error);
        }
    }
}
