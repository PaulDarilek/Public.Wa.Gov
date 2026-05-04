using FluentAssertions;

namespace Hrms.Public.Tests
{
    public static class TestExtensions
    {
        public static int GetLineCount(this FileInfo file) => GetLineCountAsync(file).GetAwaiter().GetResult();

        public static async Task<int> GetLineCountAsync(this FileInfo file)
        {
            if (!file.Exists)
            {
                throw new FileNotFoundException($"File not found: {file}");
            }

            if (file.Length == 0) return 0;

            int count = 0;
            await foreach (var line in File.ReadLinesAsync(file.FullName))
            {
                Interlocked.Increment(ref count);
            }
            return count;
        }

        /// <summary>Compare two files line by Line</summary>
        public static void CompareFileContents(this FileInfo firstFile, FileInfo secondFile)
        {
            firstFile.Refresh();
            firstFile.Exists.Should().BeTrue();

            secondFile.Refresh();
            secondFile.Exists.Should().BeTrue();

            //secondFile.Length.Should().Be(firstFile.Length, $"{firstFile.Name} and {secondFile.Name} should be equal length");

            using (var reader1 = firstFile.OpenText())
            using (var reader2 = secondFile.OpenText())
            {
                var line1 = reader1.ReadLine();
                var line2 = reader2.ReadLine();
                int count = 0;

                while (line1 != null || line2 != null)
                {
                    count++;
                    line1.Should().BeEquivalentTo(line2, $"{firstFile.Name} and {secondFile.Name} Line #{count} should match");

                    line1 = reader1.ReadLine();
                    line2 = reader2.ReadLine();
                }
            }

        }


    }
}
