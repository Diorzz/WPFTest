using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRM_MIS.Models
{
    public class PropertyCodeEnumModels
    {
        /// <summary>
        /// 证件类型枚举
        /// </summary>
        public enum CertificateType
        {
            IDCard = 1,//身份证
            OfficerCard = 1,//军官证
            AdminCode = 1,//行政，企事业单位代码证
            ResidenceBooklet = 1,//户口簿
            Passport = 1,//护照
            OtherCard = 1//其他证件

        }
        /// <summary>
        /// 承包方类型枚举
        /// </summary>
        public enum CBFType 
        {
            PeasantHousehold=1,//农户
            Personal=1,//个人
            WorkUnit=1//单位
        }

    }
}
