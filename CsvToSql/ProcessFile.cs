using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CsvToSql
{

    public class ProcessFile
    {
        protected string FileLocation;
        protected string[] TableColumns;
        protected string TableName;
        protected DataTable datatableinfo;
        protected string PrimaryKey;
        public ProcessFile (string fileLocation,string[] tableColumns,string tableName,string primaryKey)
        {
            FileLocation = fileLocation;
            TableColumns = tableColumns;
            TableName = tableName;
            PrimaryKey = primaryKey;
        }
        public virtual string Process()
        {
            CsvToData csv = new CsvToData(FileLocation);
            datatableinfo = csv.CsvToTable();
            DataTableValidate validator = new DataTableValidate(datatableinfo, TableColumns,csv.errors,TableName,PrimaryKey);
            string validationResult = validator.Validate();
            if (validationResult.Equals("Validated"))
            {
                WriteToSql wr = new WriteToSql(datatableinfo, TableName);
                string writestatus = wr.Write();
                return writestatus;
            }
            else
            {
                return validationResult;
            }
        }
    }
}