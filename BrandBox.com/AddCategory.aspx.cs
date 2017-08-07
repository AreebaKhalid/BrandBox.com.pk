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
    public partial class WebForm3 : System.Web.UI.Page
    {
        Accessible access = new Accessible();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["vendor"] == null)
            {
                Response.Redirect("~/AboutUs.aspx");
            }
            else
            {
                //nothing
             BindCategoriesRptr();


            }
        }

        protected void Add_Category(object sender, EventArgs e)
        {
            
            String SQL_Insert="";
            if (checkCategory(catName.Text))
            {
                lblError.Text = "Category Already exist";
                lblError.ForeColor = Color.Red;
            }
            else {
                lblError.Text = "";
                SQL_Insert = "INSERT INTO ProductCategory(ProductCatName) Values('" + catName.Text + "')";
                successAdded(access.AddInDatabase(SQL_Insert));
                ClearFields();

            }
            
            BindCategoriesRptr();
        }
        
        public void ClearFields()
        {
            catName.Text = String.Empty;
        }
        public bool checkCategory(string cat)
        {
            bool retval;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT ProductCatName FROM ProductCategory WHERE ProductCatName='"+cat+"'");
            dt = access.SelectFromDatabase(cmd);  
            
                if (dt.Rows.Count  > 0)
                {
                    retval = true;
                }
                else
                {
                    retval = false;
                }

                return retval;
            }


        private void BindCategoriesRptr()
        {
            DataTable categoryData = new DataTable();
            SqlCommand cmd = new SqlCommand("select * from ProductCategory");
            categoryData  = access.SelectFromDatabase(cmd);
                
             CatRptr.DataSource = categoryData;
             CatRptr.DataBind();
                    
         }

        protected void successAdded(bool isAdded)
        {
            if (isAdded)
            {
                lblError.Text = "Successfully added";
                lblError.ForeColor = Color.Green;

            }
            else
            {
                lblError.Text = "Unable to add category";
                lblError.ForeColor = Color.Green;

            }
        }


    }
}