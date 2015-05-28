using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;
using DevExpress.Mvvm.DataAnnotations;
using CLRM_MIS.Views;
using System.Windows.Input;
using System.Windows;
namespace CLRM_MIS.Services.UIServices
{
    [POCOViewModel]
    class WindowDocumentService:ViewModelBase
    {
        protected virtual IDocumentManagerService DocumentManagerService { get { return GetService<IDocumentManagerService>(); } }

        public WindowDocumentService() 
        {
            Show = new DelegateCommand(ShowExecute);
            CreateNewWindow = new DelegateCommand<object>(CreateDocument);
        }

        private void ShowExecute() 
        {
            MessageBox.Show("a");
        }
        public ICommand Show { get; set; }
        public ICommand CreateNewWindow { get; set; }
        public void CreateDocument(object arg)
        {
            IDocument doc = DocumentManagerService.FindDocument(DocumentManagerService,arg);
            if (doc == null)
            {
                doc = DocumentManagerService.CreateDocument("NewCBFView", arg);
                doc.Id = DocumentManagerService.Documents.Count<IDocument>();
            }
            doc.Show();
        }
    }
}
