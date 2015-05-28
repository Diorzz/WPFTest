using System;
using System.Diagnostics;
using CLRM_MIS.Models;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.POCO;
using CLRM_MIS.Services;
using System.Collections.ObjectModel;
using System.Collections.Generic;

namespace CLRM_MIS.ViewModels.CBFViewModels
{
    public class CBFDetailInfoViewModel:ViewModelBase
    {
        public static CBFDetailInfoViewModel Create() 
        {
            return ViewModelSource.Create(() => new CBFDetailInfoViewModel());
        }
        //protected override void OnParameterChanged(object parameter)
        //{
        //    base.OnParameterChanged(parameter);

        //    CBFDatabaseServices db = new CBFDatabaseServices();
        //    CBFFamily = db.GetAllFamily(CBFEntity);

        //    CBDKXXDatabaseServices dk = new CBDKXXDatabaseServices();
        //    CBFDK = dk.GetDkByCBF(CBFEntity);
            
        //}

        protected CBFDetailInfoViewModel() { }

        public virtual  CBFModels CBFEntity { get; set; }
        public virtual IEnumerable<CBF_JTCYModels> CBFFamily { get; set; }
        public virtual IEnumerable<CBDKXXModels> CBFDK { get; set; }
        /// <summary>
        /// 承包方变化时候，及时获取其家庭信息以及地块信息
        /// </summary>
        protected void OnCBFEntityChanged() 
        {
            CBFDatabaseServices db=new CBFDatabaseServices();
            CBFFamily = db.GetAllFamily(CBFEntity);

            CBDKXXDatabaseServices dk = new CBDKXXDatabaseServices();
            CBFDK = dk.GetDkByCBF(CBFEntity);

        }


    }
}
