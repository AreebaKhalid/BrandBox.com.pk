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
                   if(Request.QueryString["type"]!=null)
                    {
                        BindAllCategoryRptr();
                        BindAllProductsRptr();
                    }
                   else
                    {
                        Response.Redirect("~/AllProducts.aspx?type=All");
                    }
                    
                }
            }
           
        }
        private void BindAllProductsRptr()
        {
            DataTable categoryData = new DataTable();
            if(Request.QueryString["type"].Trim().Equals("All"))
            {
                //h1noOfItems.InnerText = "My Products if";
                SqlCommand cmd = new SqlCommand("SELECT ProductPrice,ImageData,ProductName,ProductCode From PDetails");
                categoryData = access.SelectFromDatabase(cmd);
            }
            else
            {

                string gender = Request.QueryString["type"].Trim('#');
                h1noOfItems.InnerText = "My Products";
                SqlCommand cmd = new SqlCommand("SELECT ProductPrice,ImageData,ProductName,ProductCode From PDetails where Gender=@gender");
                cmd.Parameters.AddWithValue("@gender", gender);
                categoryData = access.SelectFromDatabase(cmd);
            }

            if (categoryData.Rows.Count > 0)
            {
                h1noOfItems.InnerText = "My Products";
                MyProductsRptr.DataSource = categoryData;
                MyProductsRptr.DataBind();
            }
            else
            {
                h1noOfItems.InnerText = "No products";
                MyProductsRptr.DataSource = null;
                MyProductsRptr.DataSourceID = null;
                MyProductsRptr.DataBind();
            }
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
            if (Request.QueryString["type"].Equals("All") || Request.QueryString["type"] == null)
            {
                SqlCommand cmd = new SqlCommand("SELECT ProductPrice,ImageData,ProductName,ProductCode From PDetails Where CategoryId = @CatId");
                cmd.Parameters.AddWithValue("@CatId", catId);
                categoryData = access.SelectFromDatabase(cmd);
            }
            else
            {
                SqlCommand cmd = new SqlCommand("SELECT ProductPrice,ImageData,ProductName,ProductCode From PDetails Where CategoryId = @CatId AND Gender=@gender");
                cmd.Parameters.AddWithValue("@gender", Request.QueryString["type"]);
                cmd.Parameters.AddWithValue("@CatId", catId);
                categoryData = access.SelectFromDatabase(cmd);
            }

            if (categoryData.Rows.Count > 0)
            {

                h1noOfItems.InnerText = "My Products";
                MyProductsRptr.DataSource = categoryData;
                MyProductsRptr.DataBind();
            }
            else
            {
                MyProductsRptr.DataSource = null;
                MyProductsRptr.DataSourceID = null;
                MyProductsRptr.DataBind();
                h1noOfItems.InnerText = "No products";
            }
        }

        protected void All_Click(object sender, EventArgs e)
        {
            BindAllProductsRptr();
        }
    }
}