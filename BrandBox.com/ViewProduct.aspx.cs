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
        private void BindProductDetails()
        {
            Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductCode"]);
            DataTable DetProduct = new DataTable();
            SqlCommand cmd = new SqlCommand("	SELECT d.ProductName,d.ProductPrice,d.ProductDetails,d.ImageData,v.VendorName,c.ProductCatName FROM   PDetails d JOIN   Vendor v ON     d.VendorId = v.VendorId JOIN   ProductCategory c ON     c.PCID = d.CategoryId AND d.ProductCode = @ProductCode");
           // cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ProductCode", ProductID);
            DetProduct = access.SelectFromDatabase(cmd);
            
            DataTable sizeDet = new DataTable();
            SqlCommand cmd2 = new SqlCommand("SELECT ProductQnty,ProductSize,PID  FROM Product WHERE ProductCode = @ProductCode");
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
      /*  protected void sizeBinding(object sender, RepeaterItemEventArgs e)
        {

            foreach (RepeaterItem item in SizeRptr.Items)
            {
                CheckBox check = (CheckBox)item.FindControl("chkBox") as CheckBox;
                (check).Attributes.Add("onchange", "ShowHideDiv(this)");
                if (check.Checked)
                {
                    HtmlGenericControl div = e.Item.FindControl("productQntyDiv") as HtmlGenericControl;
                    div.Attributes.Add("style", "display: block;");
                }
                else
                {
                    HtmlGenericControl div = e.Item.FindControl("productQntyDiv") as HtmlGenericControl;
                    div.Attributes.Add("style", "display: none;");
                }

            }
        }*/
        protected void AddCart(object sender,System.EventArgs e)
        {
            //RepeaterItem item = e.Item;
            foreach (RepeaterItem item in SizeRptr.Items)
            {
               CheckBox chk = (CheckBox) item.FindControl("chkBox") as CheckBox;
                TextBox txt = (TextBox)item.FindControl("productQnty") as TextBox;
                //DataRow dr = ((DataRowView)item.DataItem).Row;
                if (chk != null)
                    if (chk.Checked)
                        if (txt.Enabled)
                        {
                                if (txt.Text == null)
                                {
                                    lblErr.Text = "Please enter quantity";
                                    lblErr.ForeColor = Color.Red;
                                }
                                else
                                {
                                    lblErr.Text = "la";
                                    lblErr.ForeColor = Color.Black;
                                }
                            
                        }

                        else
                        {
                            txt.Enabled = false;
                            txt.Text = "be";
                            txt.ForeColor = Color.Black;
                            lblErr.Text = "ka";
                            lblErr.ForeColor = Color.Black;
                        }


                    else
                        txt.Enabled = false;
                else
                {
                    lblErr.Text = "n";
                    lblErr.ForeColor = Color.Black;
                }
            }
        }
    }
}