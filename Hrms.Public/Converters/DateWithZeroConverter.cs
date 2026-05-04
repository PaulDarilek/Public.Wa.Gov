using FileHelpers;
using System;
using System.Globalization;

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

        /// <summary>Parse date string in format yyyyMMdd, but may have 00000000 instead to represent a nullable DateTime</summary>
        public override object StringToField(string from)
        {
            return
                string.IsNullOrEmpty(from) || from == ZerosDate ?
                (DateTime?) null :
                DateTime.ParseExact(from, "yyyyMMdd", CultureInfo.InvariantCulture);
        }
    }
}
