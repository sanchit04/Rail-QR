using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Rail_QR
{
    public partial class Main_page1 : System.Web.UI.Page
    {

        String Aadhar;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                btn_verify.Visible = false;
            }

        }




        public class aadharcard
        {
            static int[,] d = new int[,]

        {
    {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
    {1, 2, 3, 4, 0, 6, 7, 8, 9, 5},
    {2, 3, 4, 0, 1, 7, 8, 9, 5, 6},
    {3, 4, 0, 1, 2, 8, 9, 5, 6, 7},
    {4, 0, 1, 2, 3, 9, 5, 6, 7, 8},
    {5, 9, 8, 7, 6, 0, 4, 3, 2, 1},
    {6, 5, 9, 8, 7, 1, 0, 4, 3, 2},
    {7, 6, 5, 9, 8, 2, 1, 0, 4, 3},
    {8, 7, 6, 5, 9, 3, 2, 1, 0, 4},
    {9, 8, 7, 6, 5, 4, 3, 2, 1, 0}
        };
            static int[,] p = new int[,]
             {
         {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
         {1, 5, 7, 6, 2, 8, 3, 0, 9, 4},
         {5, 8, 0, 3, 7, 9, 6, 1, 4, 2},
         {8, 9, 1, 6, 0, 4, 3, 5, 2, 7},
         {9, 4, 5, 3, 1, 2, 6, 8, 7, 0},
         {4, 2, 8, 6, 5, 7, 3, 9, 0, 1},
         {2, 7, 9, 3, 8, 0, 6, 4, 1, 5},
         {7, 0, 4, 6, 9, 1, 3, 2, 5, 8}
             };

            static int[] inv = { 0, 4, 3, 2, 1, 5, 6, 7, 8, 9 };

            public static bool validateVerhoeff(string num)
            {
                int c = 0; int[] myArray = StringToReversedIntArray(num);
                for (int i = 0; i < myArray.Length; i++)
                {
                    c = d[c, p[(i % 8), myArray[i]]];
                }
                return c == 0;

            }
            public static bool validateAadharNumber(String aadharNumber)
            {
                //Pattern aadharPattern = Pattern.compile("\\d{12}");

                //bool isValidAadhar = aadharPattern.matcher(aadharNumber).matches();

                //if (isValidAadhar)
                //{

                //    isValidAadhar = aadharcard.validateVerhoeff(aadharNumber);

                //}

                //return isValidAadhar;
                return true;
            }


            public static string generateVerhoeff(string num)
            {
                int c = 0; int[] myArray = StringToReversedIntArray(num);
                for (int i = 0; i < myArray.Length; i++)
                {
                    c = d[c, p[((i + 1) % 8), myArray[i]]];
                }
                return inv[c].ToString();
            }

            private static int[] StringToReversedIntArray(string num)
            {
                int[] myArray = new int[num.Length];
                for (int i = 0; i < num.Length; i++)
                {
                    myArray[i] = int.Parse(num.Substring(i, 1));
                }
                Array.Reverse(myArray); return myArray;
            }
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

        protected void txt_aadhar_TextChanged(object sender, EventArgs e)
        {

            ScriptManager.RegisterClientScriptBlock(this, GetType(), "none", "", false);


            ClientScript.RegisterStartupScript(this.GetType(), "Popup", "validate();", true);
            aadharcard aad = new aadharcard();
            bool isValidnumber = aadharcard.validateVerhoeff(txt_aadhar.Text);
            //aadharcard.validateVerhoeff("num");
            lbl_aadhar.Text = TextBox1.Text + "valid number";
            if (isValidnumber)
            {
                lbl_aadhar.ForeColor = System.Drawing.Color.Green;
                lbl_aadhar.Text = " &#x2705; VALID NUMBER";
                Session["Aadhar"] = txt_aadhar.Text;
            }
            else
            {
                lbl_aadhar.ForeColor = System.Drawing.Color.Red;
                lbl_aadhar.Text = "&#x274C; INVALID NUMBER";
            }
        }




        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd1 = new SqlCommand();
            con.ConnectionString = "Data Source=DESKTOP-L2T1FTP\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True ";
            con.Open();
            String name = "select Aadhar from College where PRN_No='" + prn.Text + "'";

            cmd1 = new SqlCommand(name, con);

            SqlDataReader reader = cmd1.ExecuteReader();

            while (reader.Read())
            {

                Aadhar = reader["Aadhar"].ToString();
            }
            if (Aadhar == txt_aadhar.Text)
            {
                if (RadioButtonList2.SelectedValue.ToString() == "I agree")
                {
                    if (lbl_aadhar.Text == " &#x2705; VALID NUMBER")
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Verify your Email-ID');", true);

                    }
                    else
                    {
                        ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You have entered wrong aadhar number');", true);

                    }
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('You have to agree terms and conditions!');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Aadhar id entered not matches the RF-number of College Database');", true);
            }
        }

        protected void btn_verify_Click(object sender, EventArgs e)
        {
            var url = "http://localhost:52066/Main_Page2?id=" + prn.Text;
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = "Data Source=DESKTOP-L2T1FTP\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True ";
            con.Open();
            string strnew = "select count(*) from college where PRN_No='" + prn.Text + "'";
            cmd = new SqlCommand(strnew, con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count > 0)
            {
                SqlConnection con4 = new SqlConnection();
                SqlCommand cmd4 = new SqlCommand();
                con4.ConnectionString = "Data Source=DESKTOP-L2T1FTP\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True ";
                con4.Open();
                string strnew4 = "select count(*) from Registration where Email='" + email.Text + "'";
                cmd4 = new SqlCommand(strnew4, con4);
                int count4 = Convert.ToInt32(cmd4.ExecuteScalar());
                if (count4 == 0)
                {
                    String mail = email.Text;
                    SqlConnection con1 = new SqlConnection();
                    SqlCommand cmd1 = new SqlCommand();
                    con1.ConnectionString = "Data Source=DESKTOP-L2T1FTP\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True ";
                    con1.Open();


                    cmd1.CommandText = "Insert into Email_Verify(PRN_No,Email,Journey_From,Via,Aadhar_No)values('" + prn.Text + "','" + email.Text + "','" + journeyFrom.Text + "','" + via.Text + "','" + txt_aadhar.Text + "');";

                    cmd1.Connection = con1;
                    cmd1.ExecuteNonQuery();
                    MailMessage message = new MailMessage();
                    message.Subject = "Ruparel Email Verification ";
                    message.Body = "Hello,Click the below link to verify your Email-Address\n" + url + "\nRegards,\nRuparel College.";
                    message.From = new MailAddress("email@gmail.com");

                    // Email Address from where you send the mail
                    var fromAddress = "ruparel1097@gmail.com";

                    //Password of your mail address
                    const string fromPassword = "mdgwygoznmeqyoqf";
                    var smtp = new System.Net.Mail.SmtpClient();
                    {
                        smtp.Host = "smtp.gmail.com";
                        smtp.EnableSsl = true;
                        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        smtp.Credentials = new NetworkCredential(fromAddress, fromPassword);
                        smtp.Timeout = 20000;
                        smtp.Port = 587;
                    }
                    message.To.Add(mail);
                    smtp.Send(message);
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Mail has been sent! Check your mail for the further process');", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This E-Mail is already registered!');", true);
                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('R.F. No. is not valid!!Type as it is on the ID without any spaces');", true);
            }
        }

        protected void prn_TextChanged(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            con.ConnectionString = "Data Source=DESKTOP-L2T1FTP\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True ";
            con.Open();
            string strnew = "select count(*) from Registration where PRN_No='" + prn.Text.Trim() + "'";
            cmd = new SqlCommand(strnew, con);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            if (count == 0)
            {

                SqlConnection con1 = new SqlConnection();
                SqlCommand cmd1 = new SqlCommand();
                con1.ConnectionString = "Data Source=DESKTOP-L2T1FTP\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True ";
                con1.Open();
                string strnew1 = "select count(*) from College where PRN_No='" + prn.Text.Trim() + "'";
                cmd1 = new SqlCommand(strnew1, con1);
                int count1 = Convert.ToInt32(cmd1.ExecuteScalar());
                if (count1 > 0)
                {

                    SqlConnection con2 = new SqlConnection();
                    SqlCommand cmd2 = new SqlCommand();
                    con2.ConnectionString = "Data Source=DESKTOP-L2T1FTP\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True ";
                    con2.Open();
                    String name = "select F_Name,L_Name,Class,Department,Address,City,District,Pincode,Category,DOB from college where PRN_No='" + prn.Text + "'";
                    cmd2 = new SqlCommand(name, con2);

                    SqlDataReader reader = cmd2.ExecuteReader();

                    while (reader.Read())
                    {

                        var firstname = reader["F_Name"].ToString();
                        f_name.Text = firstname;


                        var lastname = reader["L_Name"].ToString();
                        l_name.Text = lastname;


                        var class1 = reader["Class"].ToString();
                        m_class.Text = class1;

                        var dept = reader["Department"].ToString();
                        department.Text = dept;

                        var address1 = reader["Address"].ToString();
                        address.Text = address1;

                        var city1 = reader["City"].ToString();
                        city.Text = city1;

                        var dist = reader["District"].ToString();
                        district.Text = dist;

                        var pin = reader["Pincode"].ToString();
                        pincode.Text = pin;

                        var category = reader["Category"].ToString();
                        txt_category1.Text = category;

                        DateTime dob1 = Convert.ToDateTime(reader["DOB"]);
                        dob.Text = dob1.Date.ToString("dd-MM-yyyy");

                    }
                    reader.Close();
                    con.Close();

                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('R.F. No. is not valid!!Type as it is on the ID without any spaces');", true);
                    f_name.Text = "";
                    l_name.Text = "";
                    m_class.Text = "";
                    department.Text = "";
                    address.Text = "";
                    city.Text = "";
                    district.Text = "";
                    pincode.Text = "";
                    txt_category1.Text = "";
                    dob.Text = "";

                }
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('This R.F. No. is already registered!');", true);
                prn.Text = "";
                f_name.Text = "";
                l_name.Text = "";
                m_class.Text = "";
                department.Text = "";
                address.Text = "";
                city.Text = "";
                district.Text = "";
                pincode.Text = "";
                txt_category1.Text = "";
                dob.Text = "";

            }

        }

        protected void email_TextChanged(object sender, EventArgs e)
        {
            btn_verify.Visible = true;
        }
    }
}
