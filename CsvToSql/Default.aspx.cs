using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CsvToSql
{
    public partial class _Default : Page
    {   
        public static DataTable datatableinfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void UploadButton_Click(object sender, EventArgs e)
        {
            string[] tableNames = new string[] { "GUID", "Date", "Double", "Int", "String" };
            string PrimaryKey = "GUID";
            string tableName = "[ExampleTable]";
            if (FileUploadControl.HasFile)
            {
                try
                {
                        if (FileUploadControl.PostedFile.ContentLength < 302400 && FileUploadControl.PostedFile.ContentType == "application/vnd.ms-excel")    
                        {
                        string filename = FileUploadControl.FileName;
                        FileUploadControl.SaveAs(Server.MapPath("~/") + filename);
                        StatusLabel.Text = "Upload status: File uploaded,Validating...";
                        ProcessFile processResult = new ProcessFile(Server.MapPath("~/ ") + filename,tableNames,tableName,PrimaryKey);
                        StatusLabel.Text = processResult.Process();
                        GridView1.DataBind();
                    }
                        else
                            StatusLabel.Text = "Upload status: The file must be a csv and less than 300 kb";
                            
                }
                catch (Exception ex)
                {
                    StatusLabel.Text = "Upload status: The file could not be uploaded. The following error occured: " + ex.Message;
                }
            }
        }
    }
}