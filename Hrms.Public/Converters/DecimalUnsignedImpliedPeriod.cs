using FileHelpers;
using System;

namespace Hrms.Public.Converters
{
    public class DecimalUnsignedImpliedPeriod : ConverterBase
    {
        /// <summary>Multiplier for removing decimals (10= one implied decimal, 2= two implied like cents, etc</summary>
        private decimal Multiplier { get; } = 1m;


        public DecimalUnsignedImpliedPeriod(uint decimalLength = 2u)
        {
            Multiplier = 1m;
            for (byte i = 0; i < decimalLength; i++)
            {
                Multiplier *= decimal.Multiply(Multiplier, 10m);
            }
        }

        public override object StringToField(string from)
        {
            decimal res = Convert.ToDecimal(from);
            return res / Multiplier;
        }

        public override string FieldToString(object from)
        {
            decimal d = (decimal)from;
            return Math.Round(d * Multiplier).ToString();
        }


    }   