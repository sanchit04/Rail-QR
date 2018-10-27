using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rail_QR
{
    public partial class Admin_Start : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Image1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("AdminWelcome.aspx");
        }

        protected void btn_registrations_Click(object sender, EventArgs e)
        {
            Response.Redirect("Start_Registration.aspx");
        }

        protected void btn_work_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminWork.aspx");
        }
    }
}