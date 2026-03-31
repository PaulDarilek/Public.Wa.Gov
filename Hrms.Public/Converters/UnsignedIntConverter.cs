using FileHelpers;
using System;

namespace Hrms.Public.Converters
{
    /// <summary>Converts Unsigned Int to Left Padded string</summary>
    internal class UnsignedIntPadded : ConverterBase
    {
        public byte Length { get; }

        public UnsignedIntPadded(byte length)
        {
            Length = length;
        }
        
        public UnsignedIntPadded(int length)
        {
            Length = (byte) length;
        }

        public override object StringToField(string from) => uint.Parse(from);  

        public override string FieldToString(object from) => Format((uint)from, Length);

        public static string Format(uint from, byte length) 
        {
            var value = from.ToString();
            
            if (value.Length < length)
                return value.PadLeft(length, '0');
            
            if (value.Length == length)
                return value;
            
            return value.Substring(value.Length - length);
        }

    }
}
