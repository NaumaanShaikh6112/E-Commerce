using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace E_Commerce
{
    public partial class Login : System.Web.UI.Page
    {
        private SqlConnection con;

        protected void Page_Load(object sender, EventArgs e)
        {
            // ✅ Sir-style connection setup
            string cnf = ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString;
            con = new SqlConnection(cnf);
            con.Open();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UserLoginProc", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@acc_email", txtUserEmail.Text);
            cmd.Parameters.AddWithValue("@acc_pass", txtPassword.Text);

            SqlDataReader dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                string role = dr["acc_role"].ToString();
                Session["MyUser"] = txtUserEmail.Text;

                if (role == "admin")
                {
                    Response.Redirect("Products.aspx");
                }
                else if (role == "user")
                {
                    Response.Redirect("AllProducts.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Email or Password');</script>");
            }

            dr.Close();
        }

        // Signup using stored procedure
        protected void btnSignup_Click(object sender, EventArgs e)
        {
            string fileName = "";
            if (FileUpload1.HasFile)
            {
                fileName = "Profiles/" + FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath(fileName));
            }

            SqlCommand cmdCheck = new SqlCommand("UserExistProcedures", con);
            cmdCheck.CommandType = CommandType.StoredProcedure;
            cmdCheck.Parameters.AddWithValue("@AccountUser", txtNewUsername.Text);
            cmdCheck.Parameters.AddWithValue("@AccountEmail", txtEmail.Text);

            SqlDataReader rdr = cmdCheck.ExecuteReader();
            if (rdr.HasRows)
            {
                rdr.Close();
                Response.Write("<script>alert('User Name or Email ID already exists');</script>");
            }
            else
            {
                rdr.Close();

                SqlCommand cmd = new SqlCommand("NewUserAccountProc", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@acc_pass", txtNewPassword.Text);
                cmd.Parameters.AddWithValue("@acc_user", txtNewUsername.Text);
                cmd.Parameters.AddWithValue("@acc_email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@acc_role", "user");
                cmd.Parameters.AddWithValue("@acc_photo", fileName);

                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Account created successfully!');</script>");
                Clear();
            }
        }

        protected void Clear()
        {
            txtNewPassword.Text = "";
            txtNewUsername.Text = "";
            txtEmail.Text = "";
        }
    }
}