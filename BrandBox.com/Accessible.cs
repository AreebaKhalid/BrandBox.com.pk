using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;
using System.Net.Mail;

namespace BrandBox.com
{
    public class Accessible
    {
        public static string GetImage(object img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
        }
        //Send Mail
        public static void sendMsg(string Email, string User, string Pass, string random)
        {

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("brandbox.com.pk@gmail.com", "passYamnaAreeba");
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "Account Verification";
            msg.Body = "Hello " + User + "Thanks for Registering in BrandBox...\n Your Account Details are given below:";
            msg.Body += "<tr>";
            msg.Body += "<td>User Name :" + User + "</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>Password :" + Pass + "</td>";
            msg.Body += "</tr>";
            msg.Body += "<tr>";
            msg.Body += "<td>Activation Number :" + random + "</td>";
            msg.Body += "</tr>";

            msg.Body += "<tr>";
            msg.Body += "<td>Thanking</td><td>Team BrandBox</td>";
            msg.Body += "</tr>";

            string toAddress = Email; // Add Recepient address
            msg.To.Add(toAddress);

            string fromAddress = "\"BrandBox.com.pk \" <brandbox.com.pk@gmail.com>";
            msg.From = new MailAddress(fromAddress);
            msg.IsBodyHtml = true;

            try
            {
                smtp.Send(msg);

            }
            catch
            {
                throw;
            }
        }
        public static void sendOrderToCustomer(string Email, string OrderId,string Name)
        {

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("brandbox.com.pk@gmail.com", "passYamnaAreeba");
            smtp.EnableSsl = true;

            MailMessage msg = new MailMessage();
            msg.Subject = "Order Details";
            msg.Body = "Hello "+Name + " Thanks for buying from BrandBox...\n Your Order Id is given below:";
            msg.Body += "<tr>";
            msg.Body += "<td>Order ID :" + OrderId + "</td>";

            msg.Body += "<tr>";
            msg.Body += "<td>Thanking</td><td>Team BrandBox</td>";
            msg.Body += "</tr>";

            string toAddress = Email; // Add Recepient address
            msg.To.Add(toAddress);

            string fromAddress = "\"BrandBox.com.pk \" <brandbox.com.pk@gmail.com>";
            msg.From = new MailAddress(fromAddress);
            msg.IsBodyHtml = true;

            try
            {
                smtp.Send(msg);

            }
            catch
            {
                throw;
            }
        }


        public String genCode()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            var finalString = new String(stringChars);
            return finalString;
        }
        public bool AddAndDelInDatabase(String SQL_Insert)
        {
            int x;
            String CS = ConfigurationManager.ConnectionStrings["BrandBoxDatabaseConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(SQL_Insert, con);

                x = cmd.ExecuteNonQuery();
                
            }
            if (x > 0)
                return true;
            else
                return false;

        }
        public bool checkifAlreadyVerified(string email,char t)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd;
            if (t == 'v')
            {
                cmd = new SqlCommand("SELECT VerifiedEmail FROM Vendor WHERE VendorEmail=@Email");
                cmd.Parameters.AddWithValue("@Email", email);
                dt = SelectFromDatabase(cmd);
            }
            else if(t=='c')
            {
                cmd = new SqlCommand("SELECT VerifiedEmail FROM CustomerDetails WHERE CustomerEmailAddress=@Email");
                cmd.Parameters.AddWithValue("@Email", email);
                dt = SelectFromDatabase(cmd);
            }
           
            
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    return (bool)dr["VerifiedEmail"];
                }

            }
            else
            {
                return false;
            }
            return false;
        }

        public DataTable SelectFromDatabase(SqlCommand SQL_Select_Qury)
        {
            String CS = ConfigurationManager.ConnectionStrings["BrandBoxDatabaseConnectionString"].ConnectionString.ToString();
            SQL_Select_Qury.CommandType = CommandType.Text;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SQL_Select_Qury.Connection = con;
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(SQL_Select_Qury))
                {
                    DataTable toReturn = new DataTable();
                    sda.Fill(toReturn);
                    return toReturn;
                }
            }
        }
        public bool checkEmail(string email,char t)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd;
            bool retval;
            if(t=='c')
            {
                cmd = new SqlCommand("SELECT CustomerEmailAddress FROM CustomerDetails WHERE CustomerEmailAddress=@Email");
                cmd.Parameters.AddWithValue("@Email", email);
                dt = SelectFromDatabase(cmd);
            }
            else if(t=='v')
            {
                cmd = new SqlCommand("SELECT VendorEmail FROM Vendor WHERE VendorEmail=@Email");
                cmd.Parameters.AddWithValue("@Email", email);
                dt = SelectFromDatabase(cmd);
            }
           
            if (dt.Rows.Count > 0)
            {
                retval = true;
            }
            else
            {
                retval = false;
            }
            return retval;
        }
        public bool checkBrandName(string brandName)
        {
            bool retval;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT VendorName FROM Vendor WHERE VendorName=@brandName");
            cmd.Parameters.AddWithValue("@brandName", brandName);
            dt = SelectFromDatabase(cmd);
            if (dt.Rows.Count > 0)
            {
                retval = true;
            }
            else
            {
                retval = false;
            }
            return retval;
        }
    }
}