using FluentAssertions;
using Hrms.Public.Files;

namespace Hrms.Public.Tests;

public class TestGap01 : TestBaseHeaderDetail<Gap01, Gap01Header, Gap01Detail>
{
    public override string DefaultFileName => $"Gap1.txt";
    public FileInfo InputFile { get; }
    public FileInfo OutputFile { get; }

    public TestGap01()
    {
        InputFile = GetInputFile();
        OutputFile = GetOutputFile();
    }

    [Fact]
    public override void ReadFile()  {

        var gapFile = ReadGap01();
        gapFile.Should().NotBeNull(); 
    }

    [Fact]
    public override void WriteFile()
    {
        var gapFile = ReadGap01();
        int expected = gapFile.Details.Count + 1;

        int written = gapFile.WriteFile(OutputFile);
        written.Should().Be(expected);

        CompareFiles(InputFile, OutputFile);
    }

    [Fact]
    public override void Import_Export_FilesCompare() => base.Import_Export_FilesCompare();


    private Gap01 ReadGap01()
    {
        CopyTestDataToInput(InputFile);

        int countExpected = File.ReadAllLines(InputFile.FullName).Length;

        var gapFile = new Gap01();
        var countActual = gapFile.ReadFile(InputFile);

        countActual.Should().Be(countExpected);
        return gapFile;
    }
}
