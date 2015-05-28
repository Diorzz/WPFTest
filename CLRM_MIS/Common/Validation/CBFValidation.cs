using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CLRM_MIS.Common.Validation
{
    class CBFValidation:ValidationRule
    {
        private int min = 0;
        private int max18 = 18;

        public int Min { get; set; }
        public int Max { get; set; }

        public override ValidationResult Validate(object value, CultureInfo cultrueinfo) 
        {
            string CBFBM = "";
            CBFBM = value.ToString();
            if (CBFBM.Length > Max || CBFBM.Length < Min)
            {
                return new ValidationResult(false, string.Format("超出范围，最大长度为{0}", Max));
            }
            else 
            {
                return new ValidationResult(true, null);
            }
        }
    }
}
