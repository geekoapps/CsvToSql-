using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using CsvHelper;

namespace CsvToSql
{
    class CsvToData
    {
        protected static DataTable DataResult;
        protected static string FileLocation;
        public string errors = string.Empty;
        public CsvToData (string filelocation)
        {
            FileLocation = filelocation;
            DataResult = new DataTable();
        }
        public virtual DataTable CsvToTable()
        {

            try
            {
                using (var reader = new StreamReader(FileLocation))
                using (var csv = new CsvReader(reader))
                {
                    
                    using (var dr = new CsvDataReader(csv))
                    {
                        var dataresult = new DataTable();
                        dataresult.Columns.Add("GUID", typeof(string));
                        dataresult.Columns.Add("Date", typeof(DateTime));
                        dataresult.Columns.Add("Double", typeof(double));
                        dataresult.Columns.Add("Int", typeof(int));
                        dataresult.Columns.Add("String", typeof(string));
                        dataresult.Load(dr);
                        DataResult = dataresult;
                    }

                    return DataResult;

                }
            }
            catch (Exception ex)
            {
                errors = ex.Message.ToString();
                return null;
            }
            
        }
    }
}
