using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrandBox.com
{
    public partial class WebForm7 : System.Web.UI.Page
    {
        Accessible access = new Accessible();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.QueryString["ProductCode"] != null)
            {
                if (!IsPostBack)
                {
                    
                    BindProductDetails();
                }
            }
            else
            {
                Response.Redirect("~/AboutUs.aspx");
            }
        }
        private void BindProductImages()
        {
           /* Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductID"]);
            DataTable categoryData = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT ImageData,ProductName,ProductCode From PDetails");
            categoryData = access.SelectFromDatabase(cmd);

            rptrImages.DataSource = categoryData;
            rptrImages.DataBind();*/
        }
        private void BindProductDetails()
        {
            Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductCode"]);
            DataTable DetProduct = new DataTable();
            SqlCommand cmd = new SqlCommand("	SELECT d.ProductName,d.ProductPrice,d.ProductDetails,d.ImageData,v.VendorName,c.ProductCatName FROM   PDetails d JOIN   Vendor v ON     d.VendorId = v.VendorId JOIN   ProductCategory c ON     c.PCID = d.CategoryId AND d.ProductCode = @ProductCode");
           // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductCode", ProductID);
            DetProduct = access.SelectFromDatabase(cmd);

            DataTable sizeDet = new DataTable();
            SqlCommand cmd2 = new SqlCommand("SELECT ProductQnty,ProductSize  FROM Product WHERE ProductCode = @ProductCode");
           // cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@ProductCode", ProductID);
            sizeDet = access.SelectFromDatabase(cmd2);

            SizeRptr.DataSource = sizeDet;
            SizeRptr.DataBind();

            rptrProductDetails.DataSource = DetProduct;
            rptrProductDetails.DataBind();
            rptrImages.DataSource = DetProduct;
            rptrImages.DataBind();


            BindProductImages();
        }
        /*protected void CheckedChanged(object sender, EventArgs e)
        {
            if (productQnty.Enabled)
            {
                productQnty.Enabled = false;
            }
            else
               productQnty.Enabled = true;

        }*/
    }
}