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
using BrandBox.com;

namespace BrandBox.com
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        Accessible access = new Accessible();
        DataTable brandData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            
          
                if (Request.Cookies["VEMAIL"] != null && Request.Cookies["VPWD"] != null)
                {
                    email.Text = Request.Cookies["VEMAIL"].Value;
                    password.Attributes["value"] = Request.Cookies["VPWD"].Value;
                    RememberMeCheckBox.Checked = true;
                    Response.Redirect("~/AboutUs.aspx#signup");
                }

            BrandRepeater();
            
        }

        protected void Signup_Now(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void Signin_Click(object sender, EventArgs e)
        {
            int vid;
            String CS = ConfigurationManager.ConnectionStrings["BrandBoxDatabaseConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from Vendor where VendorEmail='" + email.Text + "' and VendorPassword='" + password.Text + "'", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                if (dt.Rows.Count != 0)
                {
                    vid = Convert.ToInt32(dt.Rows[0]["VendorId"]);
                    if (RememberMeCheckBox.Checked)
                    {
                        Response.Cookies["VEMAIL"].Value = email.Text;
                        Response.Cookies["VPWD"].Value = password.Text;


                        Response.Cookies["VEMAIL"].Expires = DateTime.Now.AddDays(3);
                        Response.Cookies["VPWD"].Expires = DateTime.Now.AddDays(3);
                    }
                    else
                    {
                        Response.Cookies["VEMAIL"].Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies["VPWD"].Expires = DateTime.Now.AddDays(-1);
                    }
                    Session["vendor"] = email.Text;
                    Session["id"] = vid;
                   // lblError.Text = "";
                    Response.Redirect("~/SignUp.aspx");
                    Session.RemoveAll();
                }
                else
                {
                    lblError.Text = "Invalid Username or password";
                    Response.Redirect("~/AboutUs.aspx#signup");
                }
            }

        }
        private void BrandRepeater()
        {
            
            SqlCommand cmd = new SqlCommand("select * from Vendor");
            brandData = access.SelectFromDatabase(cmd);

            BrandRptr.DataSource = brandData;
            BrandRptr.DataBind();
        }

       
    }
}