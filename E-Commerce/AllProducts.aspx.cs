using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace E_Commerce
{
    public partial class AllProducts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["MyUser"] == null)
            {
                Response.Write("<script>alert('You need to log in again');window.location.href='Login.aspx';</script>");
            }
        }
    }
}