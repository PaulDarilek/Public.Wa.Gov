using Hrms.Public.Files;

namespace Hrms.Public.Tests.GapFileTests;

public class TestGap38 : TestBaseHeaderDetail<Gap01, Gap01Header, Gap01Detail>
{
    public override string DefaultFileName => $"Gap38.txt";

    // Tests are in base class...
}
