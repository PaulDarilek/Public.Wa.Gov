using Hrms.Public.Files;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Hrms.Public.Tests
{
    public class TestGap01
    {
        [Fact]
        public void Gap01Header_Should_Parse_Correctly()
        {
            // Arrange
            var header = MakeGap01Header();
            var expected = Format(header);

            // Act
            var engine = new FileHelpers.FileHelperEngine<Gap01Header>();
            var actual = engine.ReadString(expected).FirstOrDefault();

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(header.RecordType, actual.RecordType);
            Assert.Equal(header.InterfaceIdentifier, actual.InterfaceIdentifier);
            Assert.Equal(header.DateCreated, actual.DateCreated);
            Assert.Equal(header.TimeCreated, actual.TimeCreated);
            Assert.Equal(header.DetailTypeInd, actual.DetailTypeInd);
            Assert.Equal(header.BeginDate, actual.BeginDate);
            Assert.Equal(header.EndDate, actual.EndDate);
            Assert.Equal(header.TotalDetailRecordCount, actual.TotalDetailRecordCount);
            Assert.Equal(header.TotalDetailNumberOfHours, actual.TotalDetailNumberOfHours);
            Assert.Equal(header.TotalDetailDollarAmount, actual.TotalDetailDollarAmount);
            Assert.Equal(header.TotalDetailMileageAmount, actual.TotalDetailMileageAmount); 
        }

        [Fact]
        public void WriteHeader_Should_Format_Correctly()
        {

            // Arrange
            var header = MakeGap01Header();
            var expected = Format(header);

            // Act
            var engine = new FileHelpers.FileHelperEngine<Gap01Header>();
            var actual = engine.WriteString([header]).TrimEnd('\r', '\n');

            // Assert
            Debug.WriteLine(expected);
            Debug.WriteLine(actual);
            Assert.Equal(expected, actual);
        }

        private Gap01Header MakeGap01Header()
        {
            var time = new TimeOnly(23, 59, 00); //11:59:00 PM
            var today = DateTime.Today.Date;
            var beginPrevMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
            var endPrevMonth = beginPrevMonth.AddMonths(1).AddDays(-1);

            return new Gap01Header
            {
                RecordType = "00",
                InterfaceIdentifier = Gap01Header.Interface_Identifier_Constant,
                DateCreated = DateTime.Today,
                TimeCreated = $"{time:HHmmss}",  //11:59:00 PM
                DetailTypeInd = 'D',
                BeginDate = beginPrevMonth,
                EndDate = endPrevMonth,
                TotalDetailRecordCount = 1,
                TotalDetailNumberOfHours = 123456.78m,
                TotalDetailDollarAmount = 1234567.89m,
                TotalDetailMileageAmount = 123456,
            };
        }

        private string Format(Gap01Header header)
        {
            return
                header.RecordType
                + header.InterfaceIdentifier
                + $"{header.DateCreated:yyyyMMdd}"
                + header.TimeCreated
                + header.DetailTypeInd
                + $"{header.BeginDate:yyyyMMdd}"
                + $"{header.EndDate:yyyyMMdd}"
                + header.TotalDetailRecordCount.ToString().PadLeft(6, '0')
                + header.TotalDetailNumberOfHours.ToString().Replace(".", "")
                + header.TotalDetailDollarAmount.ToString().Replace(".", "")
                + header.TotalDetailMileageAmount.ToString();
        }

    }
}
