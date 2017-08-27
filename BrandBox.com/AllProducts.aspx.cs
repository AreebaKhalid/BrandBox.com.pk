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
    public partial class WebForm6 : System.Web.UI.Page
    {
        Accessible access = new Accessible();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["vendor"] != null)
                {
                    Response.Redirect("~/MyProducts.aspx");
                }
                else
                {

                    BindAllCategoryRptr();
                    BindAllProductsRptr();
                }
            }
           
        }
        private void BindAllProductsRptr()
        {
            DataTable categoryData = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT ProductPrice,ImageData,ProductName,ProductCode From PDetails");
            categoryData = access.SelectFromDatabase(cmd);

            MyProductsRptr.DataSource = categoryData;
            MyProductsRptr.DataBind();
        }
        private void BindAllCategoryRptr()
        {
            DataTable productsTable = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ProductCategory");
            productsTable = access.SelectFromDatabase(cmd);

            AllProductsRptr.DataSource = productsTable;
            AllProductsRptr.DataBind();
        }

        protected void AllProductsRptr_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string CatId = Convert.ToString(e.CommandArgument);
            BindMyProductsRptr(CatId);
        }

        private void BindMyProductsRptr(String catId)
        {
            DataTable categoryData = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT ProductPrice,ImageData,ProductName,ProductCode From PDetails Where CategoryId = @CatId");
            cmd.Parameters.AddWithValue("@CatId", catId);
            categoryData = access.SelectFromDatabase(cmd);

            MyProductsRptr.DataSource = categoryData;
            MyProductsRptr.DataBind();
        }
        
    }
}