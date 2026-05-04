using FileHelpers;
using Hrms.Public.Files;

namespace Hrms.Public.Converters
{
    public class BasicPayAdditionConverter : ConverterBase
    {
        public const int Total_Length = Gap09_BasicPayAddition.Total_Length;
        private static readonly ImpliedDecimalConverter ParseSalary = new ImpliedDecimalConverter(Sign.TrailingSeparate, 5, 2);

        public override object StringToField(string from) => Parse(from);

        public override string FieldToString(object from) => Format(from as Gap09_BasicPayAddition);

        public static Gap09_BasicPayAddition Parse(string record)
        {
            record = (record ?? string.Empty);

            if (record.Length < Total_Length)
            {
                record = record.PadRight(Total_Length);
            }
            
            return new Gap09_BasicPayAddition
            {
                SalaryComponent = record.Substring(0, 4),
                SalaryRate = ParseSalary.Parse(record.Substring(4, 8)),
                AddToTotal = record.Substring(12, 1),
            };
        }

        public static string Format(Gap09_BasicPayAddition data)
        {
            if (data == null)
            {
                return new string(' ', Total_Length);
            }

            string salaryComponent =
                string.IsNullOrEmpty(data.SalaryComponent) ? "    " :
                data.SalaryComponent.Length < 4 ? data.SalaryComponent.PadRight(4) :
                data.SalaryComponent.Length == 4 ? data.SalaryComponent :
                data.SalaryComponent.Substring(0, 4);

            string salaryRate = ParseSalary.Format(data.SalaryRate);

            return (salaryComponent + salaryRate + data.AddToTotal);
        }

    }
}
