using System;
using System.Data;
using System.Globalization;

namespace Hrms.Public.Converters
{
    internal class MasterIndexCsvHelper : CsvHelperBase
    {
        public readonly byte Biennium = 0;
        public readonly byte Agency = 1;
        public readonly byte SubAgency = 2;
        public readonly byte MasterIndex = 3;
        public readonly byte MasterIndexTitle = 4;
        public readonly byte CreateDate = 5;
        public readonly byte LastProcessDate = 6;
        public readonly byte ActiveSwitch = 7;

        public string LoadDate => "LoadDate";


        public MasterIndexCsvHelper(string tableName) : base(tableName, fieldCount: 8)
        {
        }

        protected override void ConfigureTable()
        {
            Table.Columns.Add("Biennium", typeof(string));
            Table.Columns.Add("Agency", typeof(string));
            Table.Columns.Add("MasterIndex", typeof(string));
            Table.Columns.Add("MasterIndexTitle", typeof(string));
            Table.Columns.Add(LoadDate, typeof(DateTime));
            Table.Columns.Add("CreateDate", typeof(DateTime));
            Table.Columns.Add("LastProcessDate", typeof(DateTime));
            Table.Columns.Add("ActiveSwitch", typeof(string));
        }

        protected override bool BuildRow(DataRow row, string[] fields)
        {
            row["Biennium"] = fields[Biennium];
            row["Agency"] = fields[Agency] + fields[SubAgency];
            row["MasterIndex"] = fields[MasterIndex];
            row["MasterIndexTitle"] = fields[MasterIndexTitle];
            row["CreateDate"] = DateTime.ParseExact(fields[CreateDate], "yyyymmdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            row["LastProcessDate"] = DateTime.ParseExact(fields[LastProcessDate], "yyyymmdd", CultureInfo.InvariantCulture, DateTimeStyles.None);
            row["ActiveSwitch"] = fields[ActiveSwitch];

            row[LoadDate] = DateTime.Now;
            return true;
        }
    }
}
