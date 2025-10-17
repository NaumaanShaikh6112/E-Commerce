using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce
{
    public partial class DeleteAccount : System.Web.UI.Page
    {
        private SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MyUser"] == null)
            {
                Response.Write("<script>alert('You need to log in again'); window.location='Login.aspx';</script>");
            }
            else if (!IsPostBack)
            {
                con.Open(); // ✅ Open once, sir-style
                FetchProfile();
            }
        }

        private void FetchProfile()
        {
            SqlCommand cmd = new SqlCommand("FindProfileByID", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@email_id", Session["MyUser"].ToString());

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            DataList1.DataSource = ds;
            DataList1.DataBind();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open(); // ✅ open manually if closed
                }

                SqlCommand cmd = new SqlCommand("DeleteAccount", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(e.CommandArgument));
                cmd.ExecuteNonQuery();

                Response.Write("<script>alert('Account Deleted Successfully'); window.location='Login.aspx';</script>");
            }
        }
    }
}