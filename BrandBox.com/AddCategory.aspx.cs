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
        int currentVendorId;
        int cat_id;
        Accessible access = new Accessible();
        protected void Page_Load(object sender, EventArgs e)
        {
            //getting current vendor id from tabe
            if (Session["id"] != null)
            {
                currentVendorId = Convert.ToInt32(Session["id"]);
            }
            if (!IsPostBack)
            {
                if (Session["vendor"] == null)
                {
                    Response.Redirect("~/AboutUs.aspx");
                }
                else
                {

                    BindCategoriesRptr();
                }
            }
        }

        protected void Add_Cat_in_Asso(int catId, int currentVendorId)
        {
            
           String SQL_Insert = "INSERT INTO VendorCatAssociation(VendorId,CategoryId) Values('" + currentVendorId + "','"+ catId +"')";
            successAdded(access.AddInDatabase(SQL_Insert));
            ClearFields();
        }

        protected void Add_Category(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            int key;
            
            // checking if the category already exist
            dt = checkCategory(catName.Text);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    cat_id = Convert.ToInt32(row["PCID"]);
                }
               // checkCatAssociation(cat_id, currentVendorId);
           if (checkCatAssociation(cat_id, currentVendorId))
                   {
                       lblError.Text = "Category Already exist";
                       lblError.ForeColor = Color.Red;
                   }
               else { Add_Cat_in_Asso(cat_id, currentVendorId); }
            }
            else
            {
                lblError.Text = "";
                String CS = ConfigurationManager.ConnectionStrings["BrandBoxDatabaseConnectionString"].ConnectionString.ToString();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO ProductCategory(ProductCatName) Values(@Catname); SELECT SCOPE_IDENTITY()", con);
                    cmd.Parameters.AddWithValue("@CatName", catName.Text);
                    key= Convert.ToInt32(cmd.ExecuteScalar());
                    
                }
                
                Add_Cat_in_Asso(key, currentVendorId);
                ClearFields();
            }

           /* if ()
            {
                lblError.Text = "Category Already exist";
                lblError.ForeColor = Color.Red;
            }
            else {
               

            }*/
            
            BindCategoriesRptr();
        }
        
        public void ClearFields()
        {
            catName.Text = String.Empty;
        }

        public DataTable checkCategory(string cat)
        {
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ProductCategory WHERE ProductCatName='"+cat+"'");
            dt = access.SelectFromDatabase(cmd);
            return dt;
                
        }

        public bool checkCatAssociation(int Cat_Id,int VId)
        {
            bool retval=false;
            DataTable dt = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT * FROM VendorCatAssociation WHERE CategoryId=@CId");
            cmd.Parameters.AddWithValue("@CId", Cat_Id);
            dt = access.SelectFromDatabase(cmd);

            if (dt.Rows.Count > 0)
            {
                //lblError.Text = Cat_Id + "Hey";

                 foreach (DataRow row in dt.Rows)
                 {
                    if (VId == Convert.ToInt32(row["VendorId"]))
                     {
                        retval = true;
                       //lblError.Text = Cat_Id + " Ba Hey";
                        break;
                     }
                  //  lblError.Text = Cat_Id + " Ba Hey" + VId + "  " + row["VendorId"];
                }
            }


          return retval;
        }


        private void BindCategoriesRptr()
        {
            DataTable categoryData = new DataTable();
            SqlCommand cmd = new SqlCommand(" SELECT p.PCID, p.ProductCatName FROM ProductCategory p JOIN VendorCatAssociation v ON(p.PCID = v.CategoryId) AND v.VendorId = @VId");
            cmd.Parameters.AddWithValue("@VId", currentVendorId);
            categoryData = access.SelectFromDatabase(cmd);
                
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