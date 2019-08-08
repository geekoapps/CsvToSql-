using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CsvToSql
{
    public class DataTableValidate
    {
        protected DataTable ProvidedTable;
        protected int ExpectedColumns;
        protected string[] Names;
        protected string value = string.Empty;
        protected string TableName;
        protected string PrimaryKey;

        public DataTableValidate(DataTable providedTable, string[] names,string exsistingerrors,string tableName)  
        {
            ProvidedTable = providedTable;
            ExpectedColumns = names.Length;
            Names = names;
            value = exsistingerrors;
            TableName = tableName;
            PrimaryKey = "";
        }
        public DataTableValidate(DataTable providedTable, string[] names, string exsistingerrors, string tableName,string primaryKey)
        {
            ProvidedTable = providedTable;
            ExpectedColumns = names.Length;
            Names = names;
            value = exsistingerrors;
            TableName = tableName;
            PrimaryKey = primaryKey;
        }
        public virtual string Validate()
        {
            if (value.Length > 0)
            {
                return value;
            }
            string[] col = ProvidedTable.Columns.Cast<DataColumn>()
                                 .Select(x => x.ColumnName)
                                 .ToArray();

            if (ProvidedTable.Columns.Count != ExpectedColumns)
            {
                value = String.Format("Incorrect Column amount, Expected {0} Passed {1} ", ExpectedColumns, ProvidedTable.Columns.Count);
            }
            foreach (string column in col)
            {
                if (!Names.Contains(column))
                {
                    value = value + column.ToString() + " Is not an accepted Column ";
                }
            }
            
            if (value.Length == 0 && PrimaryKey.Length > 0) // Only check sql if there are no other errors and a primary key is specified
            {
                List<string> Guids = new List<string>();
                foreach (DataRow row in ProvidedTable.Rows)
                {
                    Guids.Add((string)row[PrimaryKey]);
                }
                foreach (string guids in Guids)
                {
                    try
                    {
                        Guid.Parse(guids.ToString());
                    }
                    catch (FormatException)
                    {
                        value = value + PrimaryKey +" is invalid " + guids.ToString();
                    }
                }
                ListFromSql lfs = new ListFromSql(TableName, PrimaryKey);
                List<string> CurrentGuids = lfs.AddTolist();
                if (CurrentGuids.Any(x => Guids.Contains(x)))
                {
                    value = String.Format("Primary Key {0} Violation. {0} does not accept duplicates ", PrimaryKey);
                }
            }
            
            if (value == "") value = "Validated";
            return value;
        }

    }
}
