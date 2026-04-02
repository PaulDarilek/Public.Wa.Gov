using FileHelpers;
using System.Collections.Generic;
using System.IO;

namespace Hrms.Public.Abstract
{
    public static class FixedFileExtensions
    {
        public static List<T> ReadData<T>(this FileInfo fileInfo) where T : class
            => new FileHelperEngine<T>().ReadFileAsList(fileInfo.FullName);

        public static int WriteData<T>(this FileInfo fileInfo, IEnumerable<T> records) where T : class
        {
            var engine = new FileHelperEngine<T>();
            engine.WriteFile(fileInfo.FullName, records);
            return engine.TotalRecords;
        }

    }
}
