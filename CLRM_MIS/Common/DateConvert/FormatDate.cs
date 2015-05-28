using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLRM_MIS.Common.DateConvert
{
    class FormatDate
    {
        public string GetFormatedDate(string _date) 
        {
            string[] _dateChar=_date.Split('/');
            string _year = _dateChar[2].Substring(0, 4);
            StringBuilder sb = new StringBuilder();
            sb.Append(_year);
            if (_dateChar[0].Length == 1) 
            {
                sb.Append("0");
                sb.Append(_dateChar[0]);
            }
            sb.Append(_dateChar[1]);

            return sb.ToString();
        }
    }
}
