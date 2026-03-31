using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Hrms.Public.Abstract
{
    public interface IReadFixedLengthFile
    {
        int ReadFile(IFileInfo fileInfo);
        int ReadFromStream(TextReader reader);
    }

}
