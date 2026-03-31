using FileHelpers;
using System;
using System.Diagnostics;

namespace Hrms.Public.Converters
{
    /// <summary>Represents Zero Padded Integers (Optionally Non-Negative) </summary>
    /// <remarks>Negative sign will replace leading zero if negatives are allowed and value less than zero.</remarks>
    [DebuggerStepThrough]
    internal class IntConverter : ConverterBase
    {
        public byte Length { get; }
        public bool AllowNegative { get; }

        public IntConverter(byte length, bool allowNegatives = true)
        {
            Length = length;
            AllowNegative = allowNegatives;
        }

        protected IntConverter(int length, bool allowNegatives = true)
        {
            Length = (byte)length;
            AllowNegative = allowNegatives;
        }

        public override object StringToField(string from) => AllowNegative ? int.Parse(from) : Math.Abs(int.Parse(from));

        public override string FieldToString(object from) => Format((int)from, Length, AllowNegative);

        public static string Format(int from, byte length, bool allowNegatives)
        {
            var value =  Math.Abs(from).ToString();

            if (value.Length < length)
                value = value.PadLeft(length, '0');

            if (value.Length > length)
                value = value.Substring(value.Length - length);

            if(allowNegatives && from < 0)
                value = "-" + value.Substring(1);

            return value;
        }

    }

}
