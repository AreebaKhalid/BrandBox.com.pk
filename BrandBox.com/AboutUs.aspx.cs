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
            
            BrandRepeater();
            
        }

        protected void Signup_Now(object sender, EventArgs e)
        {
            Response.Redirect("SignUp.aspx");
        }

        protected void Shop_Now(object sender, EventArgs e)
        {
            Response.Redirect("AllProducts.aspx");
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