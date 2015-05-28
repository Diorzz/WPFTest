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

namespace CLRM_MIS.Views.CBFDetailView
{
    /// <summary>
    /// CBFDetailInfo.xaml 的交互逻辑
    /// </summary>
    public partial class CBFDetailInfo : UserControl
    {
        public object SelectedModel
        {
            get { return (object)GetValue(SelectedModelProperty); }
            set { SetValue(SelectedModelProperty, value); }
        }

        public static readonly DependencyProperty SelectedModelProperty =
            DependencyProperty.Register("SelectedModel", typeof(object), typeof(CBFDetailInfo), new PropertyMetadata(null, (d, e) =>
            {
                var cv = d as CBFDetailInfo;
                if (cv == null)
                {
                    return;
                }

                cv.DataContext = e.NewValue;
            }));
        public CBFDetailInfo()
        {
            InitializeComponent();
        }
    }
}
