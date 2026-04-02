using FluentAssertions;
using Hrms.Public.Files;

namespace Hrms.Public.Tests
{
    public class TestGap08 : TestBase
    {
        public override string DefaultFileName => "Gap08.txt";

        [Fact]
        public void CreateFile()
        {
            var names = new string[] {
            "Builder, Bob",
            "Nobody, Joe",
            "Whatabout, Fred",
            "Realee, Harry",
            "Contrary, Mary",
            };
            int empNumber = 1000;
            int ssn = 999999999;

            var list = new List<Gap08Header>();
            foreach (var name in names)
            {
                empNumber++;
                ssn--;
                var employeeName = name.PadRight(30, ' ');
                var personnelNumber = empNumber.ToString().PadLeft(8, '0');

                var detail = new Gap08Header()
                {
                    PersonnelArea = "1234",
                    PersonnelSubArea = "ABCD",
                    EmployeeGroup = 'P',
                    EmployeeSubGroup = "MM",
                    OrgUnit = "ITSDITSD",
                    OrgCode = "123456789012",
                    OrgTitle = "Org Title",
                    EffectiveDate = DateTime.Today,
                    PersonnelNumber = personnelNumber,
                    SSN = ssn.ToString().PadLeft(9,'0'),
                    EmployeeName = employeeName,
                    Salary = 1234.56m,
                    Position = 12345678,
                    PositionCode = "Code56789012",
                    PositionTitle = "Expert Developer",
                    Job = 12345678,
                    JobClassCode = "JobClassCode",
                    JobTitle = "JobTitle",
                    LeaveType = "SL",
                    BeginDate = DateTime.Today.AddDays(1 - DateTime.Today.Day).AddMonths(-1),
                    EndDate = DateTime.Today.AddDays(1 - DateTime.Today.Day),
                    BeginingBalance = 100.25m,
                    LeaveEarned = 16.25m,
                    LeaveTaken = 8.26m,
                    LeavePaid = 4.0m,
                    LeaveAdjustment = 1.5m,
                    LeaveDonated = 0.5m,
                    LeaveReturned = 2m,
                    LeaveReceived = 3m,
                    EndingBalance = 100m,
                };
                list.Add(detail);
            }

            var gapFile = new Gap08(list);

            var outFile = GetOutputFile();
            gapFile.WriteFile(outFile);
        }

        [Fact]
        public void ReadFile()
        {
            var inFile = GetInputFile();

            int countExpected = File.ReadAllLines(inFile.FullName).Length;

            var gapFile = new Gap08();
            var countActual = gapFile.ReadFile(inFile);
            
            countActual.Should().Be(countExpected);
        }

        [Fact]
        public void WriteFile()
        {
            var inFile = GetInputFile();
            var gapFile = new Gap08();
            
            int countExpected = gapFile.ReadFile(inFile);

            var outFile = GetOutputFile();
            var countActual = gapFile.WriteFile(outFile);
            
            countActual.Should().Be(countExpected);
        }

        [Fact]
        public void Import_Export_FilesCompare()
        {
            WriteFile();
            var inFile = GetInputFile();
            var outFile = GetOutputFile();
            
            CompareFiles(inFile, outFile);
        }

    }
}
