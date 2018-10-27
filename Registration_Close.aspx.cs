using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rail_QR
{
    public partial class Registration_Close : System.Web.UI.Page
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
        protected void LinkButton5_Click(object sender, EventArgs e)
        {

            Response.Redirect("AdminWelcome.aspx");

        }

    }



}