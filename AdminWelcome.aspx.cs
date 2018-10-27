using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rail_QR
{
    public partial class AdminWelcome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Welcome Page.aspx");
        }

        protected void lb_home_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome Page.aspx");
        }

        protected void lb_courses_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.ruparel.edu/pages/courses");
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.ruparel.edu/pages/about-us");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.ruparel.edu/pages/admission");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.ruparel.edu/pages/examination");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.ruparel.edu/pages/other");
        }

        protected void btn_submit_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "admin" && txtPwd.Text == "ruparel123")
            {
                Response.Redirect("Admin_Start.aspx");
            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "anything", "alert('Login Failed');", true);
            }



        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome Page.aspx");
        }
    }
}

