using FileHelpers;
using System;

namespace Hrms.Public.Converters
{
    public class DateWithZeroConverter : ConverterBase
    {
        public const string ZerosDate = "00000000";

        public override string FieldToString(object from)
        {
            DateTime? date = from as DateTime?;
            return date == null || date == DateTime.MinValue ? ZerosDate : date.Value.ToString("yyyyMMdd");
        }

        public override object StringToField(string from)
        {
            return
                string.IsNullOrEmpty(from) || from == ZerosDate ?
                (DateTime?) null :
                DateTime.TryParse(from, out var date) ? 
                date :  
                (DateTime?) null;
        }
    }
}
