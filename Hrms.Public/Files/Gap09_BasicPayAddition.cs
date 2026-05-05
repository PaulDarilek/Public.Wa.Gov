using FileHelpers;
using Hrms.Public.Converters;

namespace Hrms.Public.Files
{
    /// <summary>Repeated Field in Gap09 Basic Pay (RecordType=="0008")</summary>
    public class Gap09_BasicPayAddition
    {
        public const string SPACE = " ";
        public const int Total_Length = 13;

        /// <summary>Salary Component (Pay Code)</summary>
        [FieldFixedLength(4)]
        [StartPosition(1)]
        public string SalaryComponent { get; set; } 

        /// <summary>Salary Rate</summary>
        [FieldFixedLength(8)]
        [FieldConverter(typeof(ImpliedDecimalConverter), Sign.TrailingSeparate, 5, 2)]
        [StartPosition(5, "DEC 5.2 5 whole numbers plus 2 decimal positions (implied decimal point), zero filled from the left, rightmost position reserved for sign ('-' for negative amount, ' ' for positive amount)")]
        public decimal SalaryRate { get; set; }

        /// <summary>X = add to salary; blank = do not add to salary</summary>
        [FieldFixedLength(1)]
        [StartPosition(13, "X = add to salary; blank = do not add to salary")]
        public string AddToTotal { get; set; } 

        public Gap09_BasicPayAddition()
        {
            SalaryComponent = SalaryComponent ?? "    ";
            AddToTotal = AddToTotal ?? SPACE;
        }

    }
}
