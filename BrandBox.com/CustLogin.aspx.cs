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
    public partial class WebForm8 : System.Web.UI.Page
    {
        Accessible access = new Accessible();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customer"] != null)
                Response.Redirect("AboutUs.aspx");
        }
        protected void Signup_Now(object sender, EventArgs e)
        {
            Response.Redirect("CustSignUp.aspx");
        }
        protected void Signin_Click(object sender, EventArgs e)
        {
                //  int Cid;
                SqlCommand cmd = new SqlCommand("select * from CustomerDetails where CustomerEmailAddress='" + email.Text + "' and CustomerPassword='" + password.Text + "'");                
                DataTable dt = new DataTable();
                dt = access.SelectFromDatabase(cmd);
                if (dt.Rows.Count != 0)
                {
                   // Cid = Convert.ToInt32(dt.Rows[0]["CustomerID"]);
                    
                    Session["Customer"] = email.Text;



                    if (Request.QueryString["rurl"] != null)
                    {
                   // lblError.Text = "rurl " + Request.QueryString["rurl"];
                        if (Request.QueryString["rurl"]=="products")
                        {
                           Response.Redirect("~/ViewProduct.aspx");
                        }
                    }
                    else
                    {
                  //  lblError.Text = Request.QueryString["rurl"];
                         Response.Redirect("~/AboutUs.aspx"); 
                    }

                    Session.RemoveAll();
                }
                else
                {
                    lblError.Text = "Invalid Username or password";
                    lblError.ForeColor = Color.Red;
                }
            
        }
    }
}