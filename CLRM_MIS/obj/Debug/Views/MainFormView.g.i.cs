﻿#pragma checksum "..\..\..\Views\MainFormView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "380D1573D241811E3F4941AC08EE7F92"
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.18444
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

using CLRM_MIS.Properties;
using CLRM_MIS.Services.UIServices;
using CLRM_MIS.ViewModels;
using CLRM_MIS.ViewModels.CBFViewModels;
using DevExpress.Core;
using DevExpress.Mvvm;
using DevExpress.Mvvm.UI;
using DevExpress.Mvvm.UI.Interactivity;
using DevExpress.Xpf.Bars;
using DevExpress.Xpf.Core;
using DevExpress.Xpf.Core.DataSources;
using DevExpress.Xpf.Core.Serialization;
using DevExpress.Xpf.Core.ServerMode;
using DevExpress.Xpf.Ribbon;
using DevExpress.Xpf.WindowsUI;
using ESRI.ArcGIS.Client;
using ESRI.ArcGIS.Client.AdvancedSymbology;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Symbols;
using ESRI.ArcGIS.Client.Tasks;
using ESRI.ArcGIS.Client.Toolkit;
using ESRI.ArcGIS.Client.Toolkit.DataSources;
using ESRI.ArcGIS.Client.ValueConverters;
using Microsoft.Windows.Controls;
using Microsoft.Windows.Controls.Ribbon;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace CLRM_MIS.Views {
    
    
    /// <summary>
    /// MainFormView
    /// </summary>
    public partial class MainFormView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 40 "..\..\..\Views\MainFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\Views\MainFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.WindowsUI.NavigationFrame MainNavigationFrame;
        
        #line default
        #line hidden
        
        
        #line 105 "..\..\..\Views\MainFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid MainGrid;
        
        #line default
        #line hidden
        
        
        #line 124 "..\..\..\Views\MainFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ESRI.ArcGIS.Client.Map MyMap;
        
        #line default
        #line hidden
        
        
        #line 182 "..\..\..\Views\MainFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.WindowsUI.NavigationFrame nvaswitch;
        
        #line default
        #line hidden
        
        
        #line 183 "..\..\..\Views\MainFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView tr;
        
        #line default
        #line hidden
        
        
        #line 261 "..\..\..\Views\MainFormView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal DevExpress.Xpf.Bars.BarEditItem bey;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/CLRM_MIS;component/views/mainformview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Views\MainFormView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            
            #line 51 "..\..\..\Views\MainFormView.xaml"
            ((DevExpress.Xpf.Ribbon.RibbonControl)(target)).SelectedPageChanged += new DevExpress.Xpf.Ribbon.RibbonPropertyChangedEventHandler(this.RibbonControl_SelectedPageChanged);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 78 "..\..\..\Views\MainFormView.xaml"
            ((DevExpress.Xpf.Ribbon.RibbonPage)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.RibbonPage_MouseDown);
            
            #line default
            #line hidden
            return;
            case 4:
            this.MainNavigationFrame = ((DevExpress.Xpf.WindowsUI.NavigationFrame)(target));
            return;
            case 5:
            this.MainGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 6:
            this.MyMap = ((ESRI.ArcGIS.Client.Map)(target));
            
            #line 124 "..\..\..\Views\MainFormView.xaml"
            this.MyMap.MouseMove += new System.Windows.Input.MouseEventHandler(this.MyMap_MouseMove);
            
            #line default
            #line hidden
            return;
            case 7:
            this.nvaswitch = ((DevExpress.Xpf.WindowsUI.NavigationFrame)(target));
            return;
            case 8:
            this.tr = ((System.Windows.Controls.TreeView)(target));
            return;
            case 9:
            this.bey = ((DevExpress.Xpf.Bars.BarEditItem)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

