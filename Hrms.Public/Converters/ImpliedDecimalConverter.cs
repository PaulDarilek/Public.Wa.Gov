using FileHelpers;
using System;
using System.Diagnostics;

namespace Hrms.Public.Converters
{

    /// <summary>Summary description Convert string to decimal</summary>
    [DebuggerStepThrough]
    public class ImpliedDecimalConverter : ConverterBase
    {
        public bool UsePlusSign { get; set; } 

        public Sign Sign { get; }
        
        /// <summary>Whole Number Digits to Left of the implied decimal</summary>
        public byte LeftDigits { get; }

        /// <summary>Digits to Right of the implied decimal</summary>
        public byte RightDigits { get; }

        /// <summary>Multiplier for removing decimals (10= one implied decimal, 2= two implied like cents, etc</summary>
        private decimal Multiplier { get; } = 1m;

        /// <summary>Constructor</summary>
        /// <param name="sign">Sign None, Leading Separate, Trailing Separate</param>
        /// <param name="leftDigits">Integer portion to left of implied decimal point</param>
        /// <param name="rightDigits">Fractional portion to the right of the implied decimal point</param>
        public ImpliedDecimalConverter(Sign sign, byte leftDigits, byte rightDigits = 0)
        {
            Sign = sign;
            LeftDigits = leftDigits;
            RightDigits = rightDigits;
            Multiplier = TenToThePower(rightDigits);
        }

        /// <summary>For ConverterBase</summary>
        protected ImpliedDecimalConverter(Sign sign, int leftDigits, int rightDigits = 0)
        {
            Sign = sign;
            LeftDigits = (byte) leftDigits;
            RightDigits = (byte) rightDigits;
            Multiplier = TenToThePower((byte) rightDigits);
        }

        public static decimal TenToThePower(byte power)
        {
            if (power > 28)
                throw new ArgumentOutOfRangeException(nameof(power), power, "Too many implied decimal digits. Max is 28 because decimal type has 28-29 significant digits total.");

            decimal multiplier = decimal.One;
            for (int i = 0; i < power; i++)
            {
                multiplier *= 10m;
            }
            return multiplier;
        }

        public override object StringToField(string from) => Parse(from);

        public override string FieldToString(object from) => Format((decimal)from);

        public decimal Parse(string from)
        {
            if (string.IsNullOrWhiteSpace(from))
                return decimal.Zero;

            decimal parsed;
            switch (Sign)
            {
                case Sign.None:
                    parsed = Math.Abs(Convert.ToDecimal(from));
                    break;

                case Sign.LeadingSeparate:
                    parsed =
                        from[0] == '-' ?
                        -Convert.ToDecimal(from.Substring(1)) :
                        (from[0] == '+' || from[0] == ' ') ?
                        Convert.ToDecimal(from.Substring(1)) :
                        Math.Abs(Convert.ToDecimal(from));
                    break;

                case Sign.TrailingSeparate:
                    parsed =
                        from[from.Length - 1] == '-' ?
                        -Convert.ToDecimal(from.Substring(0, from.Length - 1)) :
                        (from[from.Length - 1] == '+' || from[from.Length - 1] == ' ') ?
                        Convert.ToDecimal(from.Substring(0, from.Length - 1)) :
                        Math.Abs(Convert.ToDecimal(from));
                    break;

                default:
                    throw new ArgumentOutOfRangeException(nameof(Sign), Sign, "Invalid enum value");
            }

            return Math.Round(decimal.Divide(parsed, Multiplier), RightDigits);
        }

        public string Format(decimal value) 
        {
            char sign = value < decimal.Zero ? '-' : UsePlusSign ? '+' : ' ';
            value = Math.Abs(value);

            string digits = Math.Round(decimal.Multiply(value , Multiplier)).ToString();

            if (digits.Length > (LeftDigits + RightDigits))
                digits = digits.Substring(digits.Length - (LeftDigits + RightDigits));

            else if (digits.Length < (LeftDigits + RightDigits))
                digits = digits.PadLeft(LeftDigits + RightDigits, '0');

            switch (Sign)
            {
                case Sign.None:
                    return digits;

                case Sign.LeadingSeparate:
                    return sign + digits;

                case Sign.TrailingSeparate:
                    return digits + sign;

                default:
                    throw new ArgumentOutOfRangeException(nameof(Sign), Sign, "Invalid enum value");    
            }
        }

    }
}
