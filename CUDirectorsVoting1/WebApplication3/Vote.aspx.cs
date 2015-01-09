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
    public partial class Vote : System.Web.UI.Page
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
            string sMemberID;
            connString = System.Configuration.ConfigurationManager.ConnectionStrings["CUDirConnectionString"].ConnectionString;

            GetConfigYearRunning();

            sMemberID = Session["MemberId"].ToString();
            if (!Page.IsPostBack) {

                if (cmdVote1.Text != "Update Vote")
                {
                    using (connection = new SqlConnection(connString))
                    {
                        SqlCommand command = new SqlCommand("SELECT [candidateid], [ID],[yearrunning], [LASTNAME],[FIRSTNAME],[BIO]  FROM CANDIDATES AS C LEFT OUTER JOIN VOTES AS V ON C.ID = V.CANDIDATEID AND V.MEMBERID = @MEMBERID WHERE YEARRUNNING = @YEARRUNNING", connection);

                        command.Parameters.AddWithValue("@MEMBERID", sMemberID);
                        command.Parameters.AddWithValue("@YEARRUNNING", YearRunning);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        GridView1.DataSource = reader;

                        DataBind();
                        bool hasRows = false;
                        foreach (GridViewRow row in GridView1.Rows)
                        {
                            if (((CheckBox)row.Cells[0].FindControl("chkRow")).Checked)

                            {
                                hasRows = true;
                            
                            }
                        }

                        if (hasRows == true)
                        {

                            cmdVote1.Text = "Update Vote";
                        }
                        else
                        {

                            cmdVote1.Text = "Vote";
                        }
                        connection.Close();
                    }
                }
            }
        }

        protected void cmdVote1_Click(object sender, EventArgs e)
        {
            bool bVoted;

            bVoted = false;

            using (connection = new SqlConnection(connString))
            {
                if (cmdVote1.Text == "Update Vote")
                {
                    connection.Open();

                    SqlCommand command = new SqlCommand("DELETE FROM VOTES WHERE MEMBERID = @MEMBERID", connection);

                    command.Parameters.AddWithValue("@MEMBERID", Session["MemberId"]);

                    command.ExecuteNonQuery();

                    connection.Close();
                }
            }

            using (connection = new SqlConnection(connString))
            {
                connection.Open();

                int x = 0;
                foreach (GridViewRow row in GridView1.Rows)
                {
                    if (((CheckBox) row.Cells[0].FindControl("chkRow")).Checked) 
                    {

                        
                        //CheckBox chk = row.Cells[0].FindControl("chkRow") as CheckBox;

                   

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
                    cmdVote1.Text = "Update Vote";

                }
            }
        }
    }
}