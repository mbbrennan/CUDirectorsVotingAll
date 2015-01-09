using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CUDirectorsVoting1Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connString;
        SqlConnection connection;

       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack) 
            {
                connString = System.Configuration.ConfigurationManager.ConnectionStrings["CUDirConnectionString"].ConnectionString;

                using (connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("SELECT _YEAR FROM _Year", connection);

                    SqlDataReader reader = command.ExecuteReader();

                    DataTable tbl = new DataTable();
   
                    tbl.Load(reader);

                    DropDownList1.DataSource = tbl;
                    DropDownList1.DataTextField = "_Year";
                    DropDownList1.DataValueField = "_Year";

                    DataBind();

                    connection.Close();
                }



                using (connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand command2 = new SqlCommand("SELECT _YEAR FROM CONFIG", connection);

                    SqlDataReader reader2 = command2.ExecuteReader();

                    while (reader2.Read())

                    DropDownList1.Text = reader2["_YEAR"].ToString();
                    DataBind();

                    connection.Close();
                }

            }
        }

        protected void cmdSave_Click(object sender, EventArgs e)
        {
            connString = System.Configuration.ConfigurationManager.ConnectionStrings["CUDirConnectionString"].ConnectionString;

            using (connection = new SqlConnection(connString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand("UPDATE CONFIG SET [_YEAR] =  @YEAR", connection);

                command.Parameters.AddWithValue("@YEAR", DropDownList1.SelectedItem.Text);

                command.ExecuteNonQuery();

                connection.Close();
            }
        }
    }
}