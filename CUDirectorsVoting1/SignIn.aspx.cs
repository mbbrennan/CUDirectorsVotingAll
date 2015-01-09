using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;


namespace WebApplication3
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdLogin_Click(object sender, EventArgs e)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["CUDirWBConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("SELECT Memberid, MDPIN FROM CUST where Memberid = @Memberid and MDPIN = @MDPIN;", connection);
                command.Parameters.AddWithValue("@Memberid", txtMemberID.Text);
                command.Parameters.AddWithValue("@MDPIN", txtPIN.Text);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Session.Add("MemberID", txtMemberID.Text);
                    Response.Redirect("Vote.aspx");
                }
                connection.Close();
                return;
            }
        }

       
    }
}