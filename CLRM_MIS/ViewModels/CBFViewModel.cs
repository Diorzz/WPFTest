using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using CLRM_MIS.Models;
using CLRM_MIS.Services;
using System.Collections.ObjectModel;
using CLRM_MIS.ViewModels.CBFViewModels;
using System.Windows;
using DevExpress.Mvvm.POCO;

namespace CLRM_MIS.ViewModels
{
    class CBFViewModel:ViewModelBase
    {
        public IEnumerable<CBFModels> CBFModel
        {
            get { return GetProperty(() => CBFModel); }
            set { SetProperty(() => CBFModel, value); }
        }

        public CBFModels CBFEntity 
        {
            get { return GetProperty(() => CBFEntity); }
            set { SetProperty(() => CBFEntity, value, OnCBFEntityChaned); }
        }
        public ObservableCollection<CBF_JTCYModels> CBFFamily
        {
            get { return GetProperty(() => CBFFamily); }
            set { SetProperty(() => CBFFamily, value); }
        }
        public ObservableCollection<CBDKXXModels> CBFDK 
        {
            get { return GetProperty(() => CBFDK); }
            set { SetProperty(() => CBFDK, value); }
        }
        CBFDetailInfoViewModel detailview;
        public CBFDetailInfoViewModel DetailView
        {
            get
            {
                if (detailview == null)
                    detailview = CBFDetailInfoViewModel.Create();
                return detailview;
            }
        }
        void OnCBFEntityChaned() 
        {
            CBFDatabaseServices db = new CBFDatabaseServices();
            CBFFamily = db.GetAllFamily(CBFEntity);

            CBDKXXDatabaseServices dk = new CBDKXXDatabaseServices();
            CBFDK = dk.GetDkByCBF(CBFEntity);
        }
        protected override void OnInitializeInRuntime()
        {
            base.OnInitializeInRuntime();

            CBFDatabaseServices db = new CBFDatabaseServices();
            IEnumerable<CBFModels> CBF = db.GetAllCBF();
            foreach (var i in CBF)
            {
                i.Family = db.GetAllFamily(i);
            }
            CBFModel = CBF;

        }
    }
}
