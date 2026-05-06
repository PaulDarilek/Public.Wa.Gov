using FileHelpers;
using Hrms.Public.Converters;
using Hrms.Public.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hrms.Public.Files
{
    public class Gap10 : IReadWriteFile
    {
        public List<Gap10Common> Data { get; }
        public int RecordCount => Data.Count;
        public List<string> Errors { get; }

        public IEnumerable<Gap10Position> GetPositions() => Data.Where(x => x is Gap10Position).Select(x => (Gap10Position)x);
        public IEnumerable<Gap10CostDistributions> GetCostDistributions() => Data.Where(x => x is Gap10CostDistributions).Select(x => (Gap10CostDistributions)x);


        [DebuggerStepThrough]
        public Gap10()
        {
            Data = new List<Gap10Common>();
            Errors = new List<string>();
        }

        public int ReadFile(FileInfo fileInfo, FileInfo errorFile = null)
        {
            var engine = CreateEngine();

            engine.BeginReadFile(fileInfo.FullName);
            foreach (var rec in engine)
            {
                if (rec is Gap10Common common)
                {
                    Data.Add(common); continue;
                }
                else
                {
                    Errors.Add(rec.ToString());
                }
            }

            if (engine.ErrorManager.HasErrors && errorFile != null)
            {
                engine.ErrorManager.SaveErrors(errorFile.FullName);
            }
            //Debug.Assert(engine.TotalRecords == RecordCount);
            return RecordCount;
        }

        /// <summary>Split Gap10 into Files per record type</summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public Task<Dictionary<string, FileInfo>> SplitFileAsync(FileInfo file) => file.SplitFileAsync(GetRecordType);

        public static Type RecordSelector(MultiRecordEngine engine, string record)
        {
            Debug.Assert(engine != null);
            string recordType = GetRecordType(record);
            var type = GetTypeOfRecord(recordType);

            return type;
        }

        public static string GetRecordType(string record)
            => string.IsNullOrEmpty(record) || record.Length < 68 ? null : record.Substring(64, 4);

        /// <summary>Get correct class type to hold data for the RecordType field</summary>
        /// <param name="recordType">Four digit RecordType field</param>
        /// <returns>Type or null if <paramref name="recordType"/> is invalid</returns>
        public static Type GetTypeOfRecord(string recordType)
        {
            switch (recordType)
            {
                case Gap10Position.RecordTypeDefault:          // Record type 1000
                    return typeof(Gap10Position);

                case Gap10CostDistributions.RecordTypeDefault:    // Record type 1018
                    return typeof(Gap10CostDistributions);


                default: return null;
            }
        }

        public int WriteFile(FileInfo file)
        {
            var engine = CreateEngine();
            engine.WriteFile(file.FullName, Data);
            Debug.Assert(engine.TotalRecords == RecordCount);

            return engine.TotalRecords;
        }

        private MultiRecordEngine CreateEngine()
        {
            var engine = new MultiRecordEngine(typeof(Gap10Position), typeof(Gap10CostDistributions))
            {
                RecordSelector = RecordSelector
            };

            // Switch error mode on
            engine.ErrorManager.ErrorMode = ErrorMode.SaveAndContinue;
            return engine;
        }

    }

}
