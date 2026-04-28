using FileHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hrms.Public.Converters
{
    public class DateWithZeroConverter : ConverterBase
    {
        public override string FieldToString(object from)
        {
            var date = (DateTime) from;
            return date == DateTime.MinValue ? "00000000" : date.ToString("yyyyMMdd");
        }

        public override object StringToField(string from)
        {
            return
                string.IsNullOrEmpty(from) || from == "00000000" ?
                (DateTime?) null :
                DateTime.TryParse(from, out var date) ? 
                date :  
                (DateTime?) null;
        }
    }
}
