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
    public partial class Vote : System.Web.UI.Page
    {
        string connString;
        SqlConnection connection;

        protected void Page_Load(object sender, EventArgs e)
        {
            string sMemberID;
            connString = System.Configuration.ConfigurationManager.ConnectionStrings["CUDirConnectionString"].ConnectionString;

            sMemberID = Session["MemberId"].ToString();
            cmdVote.Text = "Vote";

            using (connection = new SqlConnection(connString))
            {
                SqlCommand command = new SqlCommand("SELECT [candidateid], [ID],[yearrunning], [LASTNAME],[FIRSTNAME],[BIO]  FROM CANDIDATES AS C LEFT OUTER JOIN VOTES AS V ON C.ID = V.CANDIDATEID AND V.MEMBERID = @MEMBERID", connection);

                command.Parameters.AddWithValue("@MEMBERID", sMemberID);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                GridView1.DataSource = reader;

                DataBind();
                connection.Close();

            }
        }

        protected void cmdVote_Click(object sender, EventArgs e)
        {
            bool bVoted;

            bVoted = false;

            /*

            if (cmdVote.Text == "Update Vote")
            {
                using (connection = new SqlConnection(connString))
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM VOTES WHERE _YEAR = @YEAR AND MEMBERID = @MEMBERID", connection);

                    command.Parameters.AddWithValue("@YEAR", "2015");
                    command.Parameters.AddWithValue("@MEMBERID", Session["MemberId"]);

                    command.ExecuteNonQuery();

                    cmdVote.Text = "Vote";

                    connection.Close();
                }
            } */
            using (connection = new SqlConnection(connString))
            {
                connection.Open();

                foreach (GridViewRow row in GridView1.Rows)
                {
                    CheckBox chk = row.Cells[0].FindControl("chkRow") as CheckBox;

                    if (chk.Checked)
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO VOTES ([_YEAR],[CANDIDATEID], [MEMBERID], [WHEN]) VALUES ( @YEAR, @CANDIDATEID, @MEMBERID, @WHEN)", connection);

                        command.Parameters.AddWithValue("@YEAR", row.Cells[2].Text);
                        command.Parameters.AddWithValue("@CANDIDATEID", row.Cells[1].Text);
                        command.Parameters.AddWithValue("@MEMBERID", Session["MemberId"]);
                        command.Parameters.AddWithValue("@WHEN", DateTime.Now);

                        command.ExecuteNonQuery();

                        bVoted = true;
                    }

                }

                connection.Close();

                if (bVoted)
                {
                    Response.Write("\nSuccessfully voted!");
                }
            }
            }
    }
}