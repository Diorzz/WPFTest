using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace CLRM_MIS.Models
{
    public class CBDKModels
    {
        public string ID { get; set; }

        public string CBFID { get; set; }

        public string FBFID { get; set; }

        public string GetWay { get; set; }
        public double Area { get; set; }
        public string ContrctID { get; set; }
        public string TransContractID { get; set; }
        public string RightID { get; set; }
    }
}
