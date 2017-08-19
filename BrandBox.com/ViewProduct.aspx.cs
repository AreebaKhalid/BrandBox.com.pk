using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
        protected void rptrProductDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductCode"]);

                RadioButtonList rblSize = e.Item.FindControl("rblSize") as RadioButtonList;

                DataTable sizeDet = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand cmd2 = new SqlCommand("SELECT ProductQnty,ProductSize,PID  FROM Product WHERE ProductCode = @ProductCode");
                // cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@ProductCode", ProductID);
                sizeDet = access.SelectFromDatabase(cmd2);
                foreach(DataRow rows in sizeDet.Rows)
                {
                    if(Convert.ToUInt32(rows["ProductQnty"])==0)
                        rows.Delete();
                }

                rblSize.DataSource = sizeDet;
                rblSize.DataTextField = "ProductSize";
                rblSize.DataValueField = "ProductSize";
                rblSize.DataBind();

                if (rblSize.Items.Count == 0)
                {
                    TextBox txt = (TextBox)e.Item.FindControl("productQnty") as TextBox;
                    lblErr.Text = "Item not in stock";
                    lblErr.ForeColor = Color.Red;
                    btnAddToCart.Enabled = false;
                    txt.Enabled = false;
                }




            }
        }
        private void BindProductDetails()
        {
            Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductCode"]);
            DataTable DetProduct = new DataTable();
            SqlCommand cmd = new SqlCommand("	SELECT d.ProductName,d.ProductPrice,d.ProductDetails,d.ImageData,v.VendorName,c.ProductCatName FROM   PDetails d JOIN   Vendor v ON     d.VendorId = v.VendorId JOIN   ProductCategory c ON     c.PCID = d.CategoryId AND d.ProductCode = @ProductCode");
           // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductCode", ProductID);
            DetProduct = access.SelectFromDatabase(cmd);
            
           /* DataTable sizeDet = new DataTable();
            SqlCommand cmd2 = new SqlCommand("SELECT ProductQnty,ProductSize,PID  FROM Product WHERE ProductCode = @ProductCode");
           // cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@ProductCode", ProductID);
            sizeDet = access.SelectFromDatabase(cmd2);

            SizeRptr.DataSource = sizeDet;
            SizeRptr.DataBind();
            */
            rptrProductDetails.DataSource = DetProduct;
            rptrProductDetails.DataBind();
            rptrImages.DataSource = DetProduct;
            rptrImages.DataBind();


            BindProductImages();
        }
        
        protected void AddCart(object sender,System.EventArgs e)
        {
            //RepeaterItem item = e.Item;
            string x=string.Empty;
            string qnty =string.Empty;
            foreach (RepeaterItem item in rptrProductDetails.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var sizelst = item.FindControl("rblSize") as RadioButtonList;
                    TextBox txt = (TextBox)item.FindControl("productQnty") as TextBox;
                    x = sizelst.SelectedValue;
                    
                }         
            }

            if(x=="")
            {
                lblErr.Text = "Please select size for your product";
                lblErr.ForeColor = Color.Red;
            }
            else
            {
                
                if (qnty == "")
                {
                    lblErr.Text = "Please add quantity for your product";
                    lblErr.ForeColor = Color.Red;
                }
            }
        }
    }
}