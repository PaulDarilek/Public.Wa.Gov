using System.IO;

namespace Hrms.Public.Interfaces
{
    public interface IReadWriteFile
    {
        int TotalCount { get; }
        int ReadFile(FileInfo fileInfo, FileInfo errorFile = null);
        int WriteFile(FileInfo fileInfo);
    }
}