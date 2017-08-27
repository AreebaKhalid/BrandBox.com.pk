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
            BindNewProducts();


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
            
            SqlCommand cmd = new SqlCommand("Select TOP 3 ImageData from Vendor ORDER BY VendorId DESC");
            brandData = access.SelectFromDatabase(cmd);

            BrandRptr.DataSource = brandData;
            BrandRptr.DataBind();
        }
        private void BindNewProducts()
        {
            Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductCode"]);
            DataTable newProducts = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT TOP 6  ProductName,ProductPrice,ImageData,ProductCode FROM   PDetails ORDER BY ProductCode DESC");

            newProducts = access.SelectFromDatabase(cmd);

            newproductsRptr.DataSource = newProducts;
            newproductsRptr.DataBind();
        }

    }
}