using Hrms.Public.Files;

namespace Hrms.Public.Tests.GapFileTests;

public class TestGap01 : TestBaseHeaderDetail<Gap01, Gap01Header, Gap01Detail>
{
    public override string DefaultFileName => $"Gap1.txt";

    // Tests are in base class...
}
