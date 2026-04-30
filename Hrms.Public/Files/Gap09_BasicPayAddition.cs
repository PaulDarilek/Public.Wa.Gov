using FileHelpers;
using Hrms.Public.Abstract;
using Hrms.Public.Converters;

namespace Hrms.Public.Files
{
    /// <summary>Repeated Field in Gap09 Basic Pay (RecordType=="0008")</summary>
    public class Gap09_BasicPayAddition
    {
        public const char SPACE = ' ';
        public const int Total_Length = 13;
        private static readonly ImpliedDecimalConverter ParseSalary = new ImpliedDecimalConverter(Sign.TrailingSeparate, 5, 2);

        /// <summary>Salary Component (Pay Code)</summary>
        [FieldFixedLength(4)]
        [FieldSpec(4, 1, "")]
        public string SalaryComponent { get; set; } 

        /// <summary>Salary Rate</summary>
        [FieldFixedLength(8)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 5, 2)]
        [FieldSpec(8, 5, "\"DEC 5.2 5 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)\"")]
        public decimal SalaryRate { get; set; }

        /// <summary>X = add to salary; blank = do not add to salary</summary>
        [FieldFixedLength(1)]
        [FieldSpec(1, 13, "X = add to salary; blank = do not add to salary")]
        public char AddToTotal { get; set; } 

        public Gap09_BasicPayAddition()
        {
            SalaryComponent = SalaryComponent ?? "    ";
            
            if(AddToTotal == 0x00)
            AddToTotal = SPACE;
        }

    }
}
