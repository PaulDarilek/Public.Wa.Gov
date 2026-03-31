using Hrms.Public.Files;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;

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

        [Fact]
        public void WriteGap01_ShouldWork()
        {
            // Arrange
            var details = MakeGap01Details(10).ToList();
            var gap01 = new Gap01(details);
            var dirInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Tests"));
            dirInfo.Create();
            var provider = new PhysicalFileProvider(dirInfo.FullName);
            var outFile = provider.GetFileInfo($"Gap01_{DateTime.Today:yyyyMMdd}.txt");
            gap01.WriteFile(outFile);

            Assert.True(File.Exists(outFile.PhysicalPath));    
        }

        [Fact]
        public void ReadGap01_ShouldWork()
        {
            // Arrange
            var details = MakeGap01Details(10).ToList();
            var first = new Gap01(details);
            var dirInfo = new DirectoryInfo(Path.Combine(Environment.CurrentDirectory, "Tests"));
            dirInfo.Create();
            var provider = new PhysicalFileProvider(dirInfo.FullName);
            var outFile = provider.GetFileInfo($"Gap01_{DateTime.Today:yyyyMMdd}.txt");
            first.WriteFile(outFile);

            var found = provider.GetDirectoryContents("").FirstOrDefault(f => f.Name == outFile.Name);
            if(found != null)
            {
                var second = new Gap01();
                var count = second.ReadFile(found);
                Assert.Equal(first.Details.Count, second.Details.Count); 
                Assert.Equal(first.Details.Count + 1, count);  
                Compare(first.Header, second.Header);
                Compare(first.Details, second.Details);  
            }

            Assert.True(File.Exists(outFile.PhysicalPath));

        }

        private static void Compare(Gap01Header first, Gap01Header second)
        {
            Assert.Equal(first.RecordType, second.RecordType);
            Assert.Equal(first.InterfaceIdentifier, second.InterfaceIdentifier);
            Assert.Equal(first.DateCreated, second.DateCreated);
            Assert.Equal(first.TimeCreated, second.TimeCreated);
            Assert.Equal(first.DetailTypeInd, second.DetailTypeInd);
            Assert.Equal(first.BeginDate, second.BeginDate);
            Assert.Equal(first.EndDate, second.EndDate);
            Assert.Equal(first.TotalDetailRecordCount, second.TotalDetailRecordCount);
            Assert.Equal(first.TotalDetailNumberOfHours, second.TotalDetailNumberOfHours);
            Assert.Equal(first.TotalDetailDollarAmount, second.TotalDetailDollarAmount);
            Assert.Equal(first.TotalDetailMileageAmount, second.TotalDetailMileageAmount);
        }

        private static void Compare(List<Gap01Detail> first, List<Gap01Detail> second)
        {
            Assert.Equal(first.Count, second.Count);
            for (int i = 0; i < first.Count && i < second.Count; i++)
            {
                var d1 = first[i];
                var d2 = second[i];
                Assert.Equal(d1.RecordType, d2.RecordType);
                Assert.Equal(d1.PersonnelArea, d2.PersonnelArea);
                Assert.Equal(d1.EmployeeNumber, d2.EmployeeNumber);
                Assert.Equal(d1.SSN, d2.SSN);
                Assert.Equal(d1.StartDate, d2.StartDate);
                Assert.Equal(d1.EndDate, d2.EndDate);
                Assert.Equal(d1.WageType, d2.WageType);
                Assert.Equal(d1.AbsenceType, d2.AbsenceType);
                Assert.Equal(d1.Hours, d2.Hours);
                Assert.Equal(d1.FunctionalArea, d2.FunctionalArea);
                Assert.Equal(d1.CostObject, d2.CostObject);
                Assert.Equal(d1.Fund, d2.Fund);
                Assert.Equal(d1.CostCenter, d2.CostCenter);
                Assert.Equal(d1.ProjectStructure, d2.ProjectStructure);
                Assert.Equal(d1.AllocationCode, d2.AllocationCode);
                Assert.Equal(d1.PositionNumber, d2.PositionNumber);
                Assert.Equal(d1.PayScaleGroup, d2.PayScaleGroup);
                Assert.Equal(d1.PayScaleLevel, d2.PayScaleLevel);
                Assert.Equal(d1.Mileage, d2.Mileage);
                Assert.Equal(d1.Amount, d2.Amount);
            }
        }


        private static Gap01Header MakeGap01Header()
        {
            var now = DateTime.Now;
            var today = now.Date;
            var time = $"{now:HHmmss}";
            var beginPrevMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
            var endPrevMonth = beginPrevMonth.AddMonths(1).AddDays(-1);

            return new Gap01Header
            {
                RecordType = "00",
                InterfaceIdentifier = Gap01Header.Interface_Identifier_Constant,
                DateCreated = DateTime.Today,
                TimeCreated = time,  //11:59:00 PM
                DetailTypeInd = 'D',
                BeginDate = beginPrevMonth,
                EndDate = endPrevMonth,
                TotalDetailRecordCount = 1,
                TotalDetailNumberOfHours = 123456.78m,
                TotalDetailDollarAmount = 1234567.89m,
                TotalDetailMileageAmount = 123456,
            };
        }

        private static IEnumerable<Gap01Detail> MakeGap01Details(int count)
        {
            var today = DateTime.Today.Date;
            var beginPrevMonth = new DateTime(today.Year, today.Month, 1).AddMonths(-1);
            var endPrevMonth = beginPrevMonth.AddMonths(1).AddDays(-1);
            
            const string bigstring = "12345678901234567890123456789012345678901234567890123456789012345678901234567890";

            for (int i = 1; i <= count; i++)
            {
                yield return new Gap01Detail
                {
                    RecordType = "01",
                    PersonnelArea = "1234",
                    EmployeeNumber = "12345678",
                    SSN = "987654321",
                    StartDate = beginPrevMonth,
                    EndDate = endPrevMonth,
                    WageType = "1234",
                    AbsenceType = "5678",
                    Hours = i,
                    FunctionalArea = bigstring[..16],
                    CostObject = bigstring[..12],
                    Fund = bigstring[..10],
                    CostCenter = bigstring[..10],
                    ProjectStructure = bigstring[..11],
                    AllocationCode = bigstring[..7],
                    PositionNumber = bigstring[..8],
                    PayScaleGroup = bigstring[..8],
                    PayScaleLevel = "12",
                    Mileage = i * 50,
                    Amount = i * 1000, 
                };
            }
        }


        private static string Format(Gap01Header header)
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
