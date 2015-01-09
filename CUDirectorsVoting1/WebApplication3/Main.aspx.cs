using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;
namespace WebApplication3
{
    public partial class Main : System.Web.UI.Page
    {
        string connString;
        SqlConnection connection;
        int YearRunning;

        protected void GetConfigYearRunning()
        {
            using (connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("SELECT [_YEAR]  FROM CONFIG", connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    ReadSingleRow((IDataRecord)reader);
                }
                connection.Close();
            }
        }

        private void ReadSingleRow(IDataRecord record)
        {
            YearRunning = Convert.ToInt32(record[0]);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                connString = System.Configuration.ConfigurationManager.ConnectionStrings["CUDirConnectionString"].ConnectionString;

                GetConfigYearRunning();

                DropDownList1.Text = YearRunning.ToString();
            }
          
        }

        protected void Insert(object sender, EventArgs e)
        {
            if (txtLastname.Text == string.Empty)
            {
                Response.Write("\n Last name must be entered");
                return;
            }
            SqlDataSource1.Insert();
            txtLastname.Text = string.Empty;
            txtFirstname.Text = string.Empty;
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}