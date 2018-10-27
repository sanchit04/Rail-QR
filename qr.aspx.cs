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
    public partial class qr : System.Web.UI.Page
    {
        public string qr_code;
        protected void Page_Load(object sender, EventArgs e)
        {
            String last = Session["lastpart"].ToString();
            string decodedUrl = Uri.UnescapeDataString(last);
            Label1.Text = "Gnerate and E-mail QR code for R.F. No.=" + last;
        }

        protected void btnClickMe_Click(object sender, EventArgs e)
        {
            ImgQrCode.ImageUrl = "https://chart.googleapis.com/chart?cht=qr&chl=" + WebUtility.HtmlEncode(Session["URL"].ToString()) + "&choe=UTF-8&chs=" + ImgQrCode.Height.ToString().Replace("px", "") + "x" + ImgQrCode.Width.ToString().Replace("px", "");
            //Label1.Text = ImgQrCode.ImageUrl;
            qr_code = ImgQrCode.ImageUrl;
            string lastPart = Session["lastPart"].ToString();
            String mail = "select Email from Registration where PRN_No='" + lastPart + "'";
            SqlConnection con = new SqlConnection();
            SqlCommand cmd1 = new SqlCommand();
            con.ConnectionString = "Data Source=DESKTOP-L2T1FTP\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True ";
            con.Open();
            mail = mail.ToString();
            cmd1 = new SqlCommand(mail, con);
            SqlDataReader reader = cmd1.ExecuteReader();

            MailMessage message = new MailMessage();
            message.Subject = "QR code generated!";
            message.Body = "Hello,This is to inform you that we have sucessfully verified your registration-form.Congragulations your QR code is generated.Please take a ScreenShot of your QR code and on a safer side download it too.This is because this QR code is unique to you and it can be generated only once at the time of registration so be careful.You have to use this QR code throughout the year.Following is the link of your SYSTEM GENERATED QR CODE:\n" + qr_code + " \n Regards,\nRuparel College.";
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
            }
            while (reader.Read())
            {

                var to = new MailAddress(reader["Email"].ToString());
                message.To.Add(to);

            }

            // Passing values to smtp object        
            smtp.Send(message);

            reader.Close();

        }

        protected void btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminWork.aspx");
        }
    }
}