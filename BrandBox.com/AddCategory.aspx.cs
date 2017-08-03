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
            String MALE = "Male";
            String FEMALE = "Female";
            String BOTH = "Both";
            String SQL_Insert="";
            if (checkCategory(catName.Text))
            {
                lblError.Text = "Category Already exist";
                lblError.ForeColor = Color.Red;
            }
            else {
                lblError.Text = "";
                if (chkfemale.Checked && chkmale.Checked)
                {
                    SQL_Insert = "INSERT INTO ProductCategory(Gender,ProductCatName) Values('" + BOTH + "','" + catName.Text + "')"; 
                    successAdded(access.AddInDatabase(SQL_Insert));
                    ClearFields();
                }
                else if (chkfemale.Checked || chkmale.Checked)
                {
                    if (chkfemale.Checked)
                    {
                        SQL_Insert = "INSERT INTO ProductCategory(Gender,ProductCatName) Values('" + FEMALE + "','" + catName.Text + "')";
                        successAdded(access.AddInDatabase(SQL_Insert));
                    }
                    else
                    {
                        SQL_Insert = "INSERT INTO ProductCategory(Gender,ProductCatName) Values('" + MALE + "','" + catName.Text + "')";
                        successAdded(access.AddInDatabase(SQL_Insert));
                    }

                    ClearFields();
                }
                else
                {
                    lblError.Text = "Please select at least one checkbox.";
                    lblError.ForeColor = Color.Red;
                }

            }
            
            BindCategoriesRptr();
        }
        
        public void ClearFields()
        {
            catName.Text = String.Empty;
            chkfemale.Checked = false;
            chkmale.Checked = false;
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