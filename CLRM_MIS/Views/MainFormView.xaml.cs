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
using CLRM_MIS.Services;
using CLRM_MIS.Models;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.Tasks;
using ESRI.ArcGIS.Client.Symbols;
using DevExpress.Xpf.Ribbon;
namespace CLRM_MIS.Views
{
    /// <summary>
    /// MainFormView.xaml 的交互逻辑
    /// </summary>
    public partial class MainFormView : UserControl
    {
        RibbonPage page;
        public MainFormView()
        {
            InitializeComponent();
            //QueryTask queryTask = new QueryTask("http://localhost:6080/arcgis/rest/services//fckj/MapServer/0");
            //queryTask.ExecuteCompleted += QueryTask_ExecuteCompleted;
            //queryTask.Failed += QueryTask_Failed;

            //// Query task parameters. Return geometry, state, and population density.
            //Query query = new Query();
            //query.ReturnGeometry = true;
            //query.OutFields.AddRange(new string[] { "DKMC", "BSM" });

            //// Use textbox text as query condition. 
            //query.Where = "DKMC='第一地块'";

            //queryTask.ExecuteAsync(query);

        }

        private void btn_Click(object sender, System.Windows.Input.MouseEventArgs args)
        {


        }

        private void MyMap_MouseMove(object sender, MouseEventArgs args)
        {

            if (MyMap.Extent != null)
            {
                System.Windows.Point screenPoint = args.GetPosition(MyMap);
                //bex.Content = string.Format("Screen Coords: X = {0}, Y = {1}",
                    //screenPoint.X, screenPoint.Y);

                ESRI.ArcGIS.Client.Geometry.MapPoint mapPoint = MyMap.ScreenToMap(screenPoint);
                if (MyMap.WrapAroundIsActive)
                    mapPoint = ESRI.ArcGIS.Client.Geometry.Geometry.NormalizeCentralMeridian(mapPoint) as ESRI.ArcGIS.Client.Geometry.MapPoint;
                bey.Content = string.Format("地图坐标: X = {0}, Y = {1}",
                    Math.Round(mapPoint.X, 1), Math.Round(mapPoint.Y, 4));

            }
        }
        private void QueryTask_ExecuteCompleted(object sender, ESRI.ArcGIS.Client.Tasks.QueryEventArgs args)
        {
            // Clear previous results.
            GraphicsLayer graphicsLayer = MyMap.Layers["MyGraphicsLayer"] as GraphicsLayer;
            graphicsLayer.ClearGraphics();

            // Check for new results. 
            FeatureSet featureSet = args.FeatureSet;
            if (featureSet.Features.Count > 0)
            {
                // Add results to the map.
                foreach (Graphic resultFeature in featureSet.Features)
                {
                    resultFeature.Symbol = LayoutRoot.Resources["ResultsFillSymbol"] as ESRI.ArcGIS.Client.Symbols.Symbol;
                    graphicsLayer.Graphics.Add(resultFeature);
                }
            }
            else
            {
                MessageBox.Show("No features found");
            }
        }
        private void QueryTask_Failed(object sender, TaskFailedEventArgs args)
        {
            MessageBox.Show("Query failed: " + args.Error);
        }

        private void RibbonPage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            MessageBox.Show("haha");
        }

        private void RibbonControl_SelectedPageChanged(object sender, DevExpress.Xpf.Ribbon.RibbonPropertyChangedEventArgs e)
        {
            
        }
  
    }
}
