using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CLRM_MIS.Models;

namespace CLRM_MIS.Models
{
    class FBFModels
    {
        //发包方编码
        public string ID { get; set; }
        //发包方名称
        public string Name { get; set; }
        //发包方负责人名称
        public string ManagerName { get; set; }
        //负责人证件类型
        public PropertyCodeEnumModels.CertificateType CertificateType { get; set; }
        //负责人证件号码
        public string CertificateNumber { get; set; }
        //联系电话
        public string Tel { get; set; }
        //发包方地址
        public string Address { get; set; }
        //邮政编码
        public string PostCode { get; set; }
        //发包方调查员
        public string Claimsman { get; set; }
        //发包方调查日期
        public string Date { get; set; }
        //发包方调查记事
        public string Event { get; set; }

    }
}
    