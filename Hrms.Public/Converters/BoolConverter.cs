using FileHelpers;
using System;

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


        public override object StringToField(string from) => Parse(from, TrueValue, FalseValue) ?? false;
        public override string FieldToString(object from) => Format(from as bool?, TrueValue, FalseValue) ?? FalseValue;

        public static bool? Parse(string from, string TrueValue = "1", string FalseValue = "0")
        {
            if (string.IsNullOrEmpty(from))
                return null;

            return
                TrueValue.Equals(from, StringComparison.OrdinalIgnoreCase) ? true :
                FalseValue.Equals(from, StringComparison.OrdinalIgnoreCase) ? false :
                (bool?)null;
        }

        public static string Format(bool? value, string TrueValue = "1", string FalseValue = "0")
        {
            if (value == null)
                return null;

            return value.Value ? TrueValue : FalseValue;
        }

    }
}
