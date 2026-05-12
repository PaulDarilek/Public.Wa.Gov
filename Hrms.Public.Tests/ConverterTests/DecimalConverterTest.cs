using Hrms.Public.Converters;


namespace Hrms.Public.Tests.ConverterTests
{
    public class DecimalConverterTest
    {
        [Fact]
        public void ImpliedDecimalConverter_Unsigned_Should_Convert_Correctly()
        {
            // Arrange
            var converter = new ImpliedDecimalConverter(Sign.None, 3, 2); // 2 decimal places

            // Act & Assert
            TestConverter(converter, "12345", 123.45m);

            Assert.Equal(123.45m, converter.Parse("12345"));
            Assert.Equal(123.45m, converter.Parse("+12345"));
            Assert.Equal(123.45m, converter.Parse("-12345"));

            Assert.Equal("12345", converter.Format(123.45m));
            Assert.Equal("12345", converter.Format(-123.45m));
        }

        [Fact]
        public void ImpliedDecimalConverter_SignLeading_Should_Convert_Correctly()
        {
            // Arrange
            var converter = new ImpliedDecimalConverter(Sign.LeadingSeparate, 3, 2); // 2 decimal places

            // Act & Assert
            TestConverter(converter, " 12345", 123.45m);
            TestConverter(converter, "-12345", -123.45m);

            Assert.Equal(123.45m, converter.Parse("12345"));
            Assert.Equal(123.45m, converter.Parse(" 12345"));
            Assert.Equal(123.45m, converter.Parse("+12345"));
            Assert.Equal(-123.45m, converter.Parse("-12345"));

            Assert.Equal(" 12345", converter.Format(123.45m));
            Assert.Equal("-12345", converter.Format(-123.45m));

            converter.UsePlusSign = true;
            Assert.Equal("+12345", converter.Format(123.45m));
        }

        [Fact]
        public void ImpliedDecimalConverter_SignTrailing_Should_Convert_Correctly()
        {
            // Arrange
            var converter = new ImpliedDecimalConverter(Sign.TrailingSeparate, 3, 2); // 2 decimal places

            // Act & Assert
            TestConverter(converter, "12345 ", 123.45m);
            TestConverter(converter, "12345-", -123.45m);

            Assert.Equal(123.45m, converter.Parse("12345"));
            Assert.Equal(123.45m, converter.Parse("12345 "));
            Assert.Equal(-123.45m, converter.Parse("12345-"));

            Assert.Equal("12345 ", converter.Format(123.45m));
            Assert.Equal("12345-", converter.Format(-123.45m));

            converter.UsePlusSign = true;
            Assert.Equal("12345+", converter.Format(123.45m));
        }

        private static void TestConverter(ImpliedDecimalConverter converter, string stringValue, decimal decimalValue)
        {
            Xunit.Assert.Equal(decimalValue, (decimal)converter.StringToField(stringValue));
            Xunit.Assert.Equal(stringValue, converter.FieldToString(decimalValue));   
        }
    }
}