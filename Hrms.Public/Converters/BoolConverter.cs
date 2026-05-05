using FileHelpers;
using System;
using System.Diagnostics;

namespace Hrms.Public.Converters
{
    public class BoolConverter : ConverterBase
    {
        public string TrueValue { get; set; }
        public string FalseValue { get; set; }

        public BoolConverter(string trueValue = "1", string falseValue = "0")
        {
            TrueValue = string.IsNullOrEmpty(trueValue) ? "1" : trueValue;
            FalseValue = string.IsNullOrEmpty(falseValue) ? "0" : falseValue;
        }


        public override object StringToField(string from)
        {
            bool value = !string.IsNullOrEmpty(from) && TrueValue.Equals(from, StringComparison.OrdinalIgnoreCase);
            Debug.Assert(value == true);
            return value;
        }

        public override string FieldToString(object from)
        {
            string value = 
                from == null || !(bool)from ? 
                FalseValue : 
                TrueValue;
            Debug.Assert(!string.IsNullOrEmpty(value));
            return value;
        }
    }
}
