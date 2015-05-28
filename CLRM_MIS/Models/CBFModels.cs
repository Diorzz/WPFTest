using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using DevExpress.Mvvm;

namespace CLRM_MIS.Models
{
    public class CBFModels:ViewModelBase
    {
        public string ID { get; set; }
        public PropertyCodeEnumModels.CBFType Type { get; set; }

        public string Name 
        {
            get { return GetProperty(() => Name); }
            set { SetProperty(() => Name, value); }
        }
        public PropertyCodeEnumModels.CertificateType CertificateType { get; set; }

        public string CardNumber { get; set; }

        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Tel { get; set; }
        public string MemberCount { get; set; }
        public string SurveyDate { get; set; }
        public string Claimsman { get; set; }
        public string SurveyEvent { get; set; }
        public string PublicEvent { get; set; }
        public string PublicEventPerson { get; set; }
        public string PublicDate { get; set; }

        public string PublicCheckPerson { get; set; }

        public ObservableCollection<CBF_JTCYModels> Family { get; set; }
    }
}
