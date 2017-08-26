using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrandBox.com
{
    public partial class WebForm12 : System.Web.UI.Page
    {
        Accessible access = new Accessible();
        String CS = ConfigurationManager.ConnectionStrings["BrandBoxDatabaseConnectionString"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["rurl"]!=null)
            {
                ErrorMessage.Text= "Please verify your email address to login";
                ErrorMessage.ForeColor = Color.Red;
            }

            if (Session["Vendor"] != null)
                Response.Redirect("~/MyProducts.aspx");
        }
        protected void btnVerify_Click(object sender, EventArgs e)
        {
            if (access.checkEmail(email.Text, 'v'))
            {
                if (!(access.checkifAlreadyVerified(email.Text)))
                {
                    if (code.Text != "")
                    {

                        if (CheckCode(code.Text, email.Text))
                        {
                            updateTable(email.Text);
                            Response.Redirect("~/Login.aspx");
                        }
                        else
                        {
                            ErrorMessage.ForeColor = Color.Red;
                            ErrorMessage.Text = "Code do not match";


                        }
                    }
                    else
                    {
                        ErrorMessage.ForeColor = Color.Red;
                        ErrorMessage.Text = "Please Enter the code";
                    }
                }
                else
                {
                    ErrorMessage.ForeColor = Color.Red;
                    ErrorMessage.Text = "You have already verified";
                }
              
            }

            else
            {
                ErrorMessage.ForeColor = Color.Red;
                ErrorMessage.Text = "Incorrect Email";
            }

        }

        

        public void updateTable(string email)
        {
            
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("updateVendorVerification",con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@VendorEmail", email);
                cmd.Parameters.AddWithValue("@VerifiedEmail", 1);
                cmd.ExecuteNonQuery();
            }
        }
        public bool CheckCode(string code, string email)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT VerificationCode FROM Vendor WHERE VendorEmail=@Email");
            cmd.Parameters.AddWithValue("@Email", email);
            dt = access.SelectFromDatabase(cmd);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    if (code.Equals(dr["VerificationCode"]))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                
            }
            else
            {
                return false;
            }
            return false;
        }

    }
}