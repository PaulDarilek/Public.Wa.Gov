using System;
using System.Data;
using System.Diagnostics;

namespace Hrms.Public.Converters
{
    /// <summary>Order of Columns for Master Index</summary>
    internal class MasterIndexDetailCsvHelper : CsvHelperBase
    {
        public readonly byte Bienium = 0;
        public readonly byte Agency = 1;
        public readonly byte SubAgency = 2;
        public readonly byte MasterIndex = 3;
        public readonly byte Counter = 4;
        public readonly byte Account = 5;
        public readonly byte FundDetail = 6;
        public readonly byte ExpenditureAuthorityIndex = 7;
        public readonly byte ProgramIndex = 8;
        public readonly byte Project = 9;
        public readonly byte SubProject = 10;
        public readonly byte ProjectPhase = 11;
        public readonly byte OrgIndex = 12;
        public readonly byte BudgetUnit = 13;
        public readonly byte MasterIndexPct = 14;

        public MasterIndexDetailCsvHelper() : base("MasterIndexDetail", fieldCount: 15)
        {
        }

        protected override void ConfigureTable()
        {
            Table.Columns.Add("Bien", typeof(string));
            Table.Columns.Add("Agency", typeof(string));
            Table.Columns.Add("MstrIndx", typeof(string));
            Table.Columns.Add("Counter", typeof(string));
            Table.Columns.Add("Fund", typeof(string));
            Table.Columns.Add("FundDetail", typeof(string));
            Table.Columns.Add("AppnIndx", typeof(string));
            Table.Columns.Add("ProgIndx", typeof(string));
            Table.Columns.Add("ProjStructure", typeof(string));
            Table.Columns.Add("OrgIndx", typeof(string));
            Table.Columns.Add("MIDetails", typeof(string));
            Table.Columns.Add("LoadDate", typeof(string));
        }

        protected override bool BuildRow(DataRow row, string[] fields)
        {
            Debug.Assert(fields.Length == 15);

            row["Bien"] = fields[Bienium];
            row["Agency"] = fields[Agency] + fields[SubAgency];
            row["MstrIndx"] = fields[MasterIndex];
            row["Counter"] = fields[Counter];
            row["Fund"] = fields[Account];
            row["FundDetail"] = fields[FundDetail];
            row["AppnIndx"] = fields[ExpenditureAuthorityIndex];
            row["ProgIndx"] = fields[ProgramIndex];
            row["ProjStructure"] = fields[Project] + fields[SubProject] + fields[ProjectPhase];
            row["OrgIndx"] = fields[OrgIndex];
            row["MIDetails"] = fields[BudgetUnit] + " " + fields[MasterIndexPct];
            row["LoadDate"] = DateTime.Now;
            
            return true;
        }
    }

} // End Namespace
