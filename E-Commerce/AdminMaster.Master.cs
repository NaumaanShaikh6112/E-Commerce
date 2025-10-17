using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MyUser"] != null)
            {
                string conStr = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;
                SqlConnection con = new SqlConnection(conStr);
                con.Open();

                SqlCommand cmd = new SqlCommand("SELECT acc_user FROM user_account WHERE acc_email = @email", con);
                cmd.Parameters.AddWithValue("@email", Session["MyUser"].ToString());

                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    Label1.Text = "Hello " + rdr["acc_user"].ToString();
                }
                rdr.Close();
                con.Close();
            }
            else
            {
                Response.Write("<script>alert('You need to log in again'); window.location='Login.aspx';</script>");
            }
        }

        protected void btnAdminLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }
    }
}