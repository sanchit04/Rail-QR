using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rail_QR
{
    public partial class registrationSuccess : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Text = Session["F_Name"].ToString();
            Label2.Text = Session["L_Name"].ToString();
        }

        protected void btn_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome Page.aspx");
        }
    }
}