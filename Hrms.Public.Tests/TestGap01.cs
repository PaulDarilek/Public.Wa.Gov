using Hrms.Public.Files;
using Microsoft.Extensions.FileProviders;
using System.Diagnostics;
using FluentAssertions;

namespace Hrms.Public.Tests;

public class TestGap01 : TestBaseHeaderDetail<Gap01, Gap01Header, Gap01Detail>
{
    public override string DefaultFileName => $"{Gap01Header.Interface_Identifier_Constant}.txt";

    [Fact]
    public override void ReadFile()  => base.ReadFile();

    [Fact]
    public override void WriteFile() => base.WriteFile();

    [Fact]
    public override void Import_Export_FilesCompare() => base.Import_Export_FilesCompare();

}
