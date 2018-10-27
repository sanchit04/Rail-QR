using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rail_QR
{
    public partial class Welcome_Page : System.Web.UI.Page
    {
        String date1;
        String date2;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Welcome Page.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

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
        protected void myclick(Object sender, EventArgs e)
        {
            SqlConnection con3 = new SqlConnection();
            SqlCommand cmd3 = new SqlCommand();
            con3.ConnectionString = "Data Source=DESKTOP-L2T1FTP\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True ";
            con3.Open();
            String name = "select Start_Date,End_Date from Open_Registration";

            cmd3 = new SqlCommand(name, con3);

            SqlDataReader reader = cmd3.ExecuteReader();

            while (reader.Read())
            {

                date1 = reader["Start_Date"].ToString();
                date2 = reader["End_Date"].ToString();


            }
            reader.Close();
            if (date1 == null)
            {
                Response.Redirect("Registration_No.aspx");
            }
            if (date1 != null)
            {

                //  String date1 = "20-05-2018";
                //String date2 = "22-05-2018";
                DateTime fromdate = Convert.ToDateTime(date1);
                DateTime todate = Convert.ToDateTime(date2);
                DateTime current = DateTime.Now;
                if (current >= fromdate && current <= todate)
                {
                    //is between the 2 dates
                    Response.Redirect("Main_page1.aspx");
                }
                else
                {
                    Response.Redirect("Registration_Close.aspx");
                }
            }
        }
    }
}