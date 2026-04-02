using Hrms.Public.Files;
using System.Reflection.Metadata.Ecma335;

namespace Hrms.Public.Tests;

public class TestGap07 : TestBaseHeaderDetail<Gap07, Gap07Header, Gap07Detail>
{
    public override string DefaultFileName => $"{Gap07Header.Interface_Identifier_Constant}.txt";

    [Fact]
    public void CreateFile()
    {
        var detail = new Gap07Detail()
        {
            RecordType = "01",
            Agency = "0123",
            BargainingUnit = "U123",
            EmployeeGroup = 'P',
            EmployeeSubGroup = "MM",
            PayrollArea = "12",
            OrgUnit = "ITSDITSD",
            OrgCode = "123456789012",
            OrgTitle = "Org Title",
            WarrantRegisterNumber = "12345",
            WarrantEftNumber = "1234567",
            WarrantCancellationIndicator = 'C',
            EmployeeNumber = "01234567",
            SSN = "         ",
            EmployeeName = "Builder, Bob",
            EmployeeStatus = 'A',
            Salary = 1234.56m,
            SalaryRange = "HI",
            SalaryStep = "M",
            SalaryLevel = "99",
            PayDate = DateTime.Today.AddDays(-DateTime.Today.Day),
            Position = "12345678",
            PositionCode = "Code56789012",
            PositionTitle = "Expert Developer",
            JobClass = "12345678",
            JobClassCode = "JobClassCode",
            JobTitle = "JobTitle",
            WageType = "0199",
            WageTypeText = "WageText",
            FTE = 160.00m,
            CurrentHours = 160m,
            CurrentAmount = 5000.00m,
            BusinessArea = "ITSD",
            FunctionalArea = "1234567890123456",
            CostObject= "123456789012",
            Fund = "1234567890",
            CostCenter = "1234567890",
            ProjectStructure = "12345678901",
            AllocationCode = "1234567",
            SubObject = "SO",
            SubSubObject = "SUBS",
            GeneralLedgers = "1234",
            InPeriod = "202604",
            ForPeriod = "202603",
            FTE_8 = 160.00m,
            FTE_8_Sign = '+',
        };

        var gapFile = new Gap07([detail]);
        gapFile.WriteFile(GetOutputFile());
    }

    [Fact]
    public override void ReadFile()  => base.ReadFile();

    [Fact]
    public override void WriteFile() => base.WriteFile();

    [Fact]
    public override void Import_Export_FilesCompare() => base.Import_Export_FilesCompare();

}
