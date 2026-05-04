using Hrms.Public.Files;

namespace Hrms.Public.Tests.GapFileTests;

public class TestGap07 : TestBaseHeaderDetail<Gap07, Gap07Header, Gap07Detail>
{
    public override string DefaultFileName => "Gap7.txt";  // $"{Gap07Header.Interface_Identifier_Constant}.txt";

    // Tests are in base class...

}
