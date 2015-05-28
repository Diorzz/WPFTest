using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using System.Collections.ObjectModel;

namespace CLRM_MIS.ViewModels.CBFViewModels
{
    class NewCBFWindowViewModel:IDocumentContent
    {
        public IDocumentOwner DocumentOwner { get; set; }
        public void OnClose(System.ComponentModel.CancelEventArgs e) 
        {
            
        }

        public void Close()
        {
            DocumentOwner.Close(this, false);
        }
        public void OnDestroy() { }

        public object Title
        {
            get { return "新建承包方"; }
        }
    }
}
