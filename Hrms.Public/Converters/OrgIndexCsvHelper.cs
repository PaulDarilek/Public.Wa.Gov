using System;
using System.Data;
using System.Diagnostics;

namespace Hrms.Public.Converters
{
    internal class OrgIndexCsvHelper : CsvHelperBase
    {
        public readonly byte Biennium = 0;
        public readonly byte Agency = 1;
        public readonly byte SubAgency = 2;
        public readonly byte OrgIndex = 3;
        public readonly byte OrgTitle = 4;

        public string DateCreated => "DateCreated";


        public OrgIndexCsvHelper(string tableName = "OrgIndex") : base(tableName, fieldCount: 5)
        {
        }

        protected override void ConfigureTable()
        {
            Table.Columns.Add(nameof(Biennium), typeof(string));
            Table.Columns.Add(nameof(Agency), typeof(string));
            Table.Columns.Add(nameof(OrgIndex), typeof(string));
            Table.Columns.Add(nameof(OrgTitle), typeof(string));
            Table.Columns.Add(nameof(DateCreated), typeof(DateTime));
        }

        protected override bool BuildRow(DataRow row, string[] fields)
        {
            Debug.Assert(fields.Length == 5);

            row[nameof(Biennium)] = fields[Biennium];
            row[nameof(Agency)] = fields[Agency] + fields[SubAgency];
            
            var orgIndex = fields[OrgIndex];
            row[nameof(OrgIndex)] = orgIndex;
            
            row[nameof(OrgTitle)] = fields[OrgTitle].Trim().Replace("\"", "");
            row[nameof(DateCreated)] = DateTime.Now;

            return !string.IsNullOrWhiteSpace(orgIndex);   
        }

    }

} // End Namespace
