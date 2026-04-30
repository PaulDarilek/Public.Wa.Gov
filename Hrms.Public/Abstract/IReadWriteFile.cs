using System.IO;

namespace Hrms.Public.Abstract
{
    public interface IReadWriteFile
    {
        int ReadFile(FileInfo fileInfo, FileInfo errorFile = null);
        int WriteFile(FileInfo fileInfo);
    }
}