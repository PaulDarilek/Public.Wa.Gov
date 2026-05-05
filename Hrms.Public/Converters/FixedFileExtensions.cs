using FileHelpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Hrms.Public.Converters
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

        /// <summary>Split Gap9 into Files per record type</summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public static async Task<Dictionary<string, FileInfo>> SplitFileAsync(this FileInfo file, Func<string, string> getRecordType)
        {
            var dict = new Dictionary<string, FileInfo>(StringComparer.OrdinalIgnoreCase);
            if (!file.Exists)
                return dict;

            var streams = new Dictionary<string, StreamWriter>(StringComparer.OrdinalIgnoreCase);
            using (var reader = file.OpenText())
            {
                StreamWriter writer;
                var record = await reader.ReadLineAsync();
                while (record != null)
                {
                    var key = getRecordType(record);
                    if (dict.ContainsKey(key))
                    {
                        writer = streams[key];
                    }
                    else
                    {
                        var fileName = $"{Path.GetFileNameWithoutExtension(file.Name)}_{key}{file.Extension}";
                        var newFile = new FileInfo(Path.Combine(file.Directory.FullName, fileName));
                        dict.Add(key, newFile);
                        writer = newFile.CreateText();
                        streams.Add(key, writer);
                    }
                    await writer.WriteLineAsync(record);

                    record = await reader.ReadLineAsync();
                }
            }

            foreach (var stream in streams.Values)
            {
                await stream.FlushAsync();
                stream.Close();
            }

            return dict;
        }


    }
}
