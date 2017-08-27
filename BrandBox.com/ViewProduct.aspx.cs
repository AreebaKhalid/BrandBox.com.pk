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
                Response.Redirect("~/AllProducts.aspx");
            }
        }
        private void AddToCart(string quantity,string size)
        {
            Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductCode"]);
            Int64 cId=0;
            
            if (Session["Customer"] != null)
            {
                DataTable idTab = new DataTable();
                SqlCommand cmd2 = new SqlCommand("SELECT CustomerID  FROM CustomerDetails WHERE CustomerEmailAddress = @email");
                cmd2.Parameters.AddWithValue("@email", Session["Customer"].ToString());
                idTab = access.SelectFromDatabase(cmd2);
                foreach (DataRow rows in idTab.Rows)
                {
                    cId = Convert.ToInt64(rows["CustomerID"]);
                }

                if (Request.Cookies["OrderID"+cId.ToString()] != null)
                {
                    string CookiePID = Request.Cookies["OrderID" + cId.ToString()]["ProductID"].Split('=')[0];
                    CookiePID = CookiePID + "," + ProductID;

                    HttpCookie Order = new HttpCookie("OrderID" + cId.ToString());
                    Order.Values["ProductID"] = CookiePID;

                    string CookieQnty= Request.Cookies["OrderID" + cId.ToString()]["Quantity"].Split('=')[0];
                    CookieQnty = CookieQnty + "," + quantity;
                    Order.Values["Quantity"] = CookieQnty;
                    

                    string CookieSize= Request.Cookies["OrderID" + cId.ToString()]["Size"].Split('=')[0];
                    CookieSize = CookieSize + "," + size;
                    Order.Values["Size"] = CookieSize;


                    Order.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(Order);
                }
                else
                {
                    HttpCookie Order = new HttpCookie("OrderID" + cId.ToString());
                    //Order.Values["Customer"] = Session["Customer"].ToString();
                    Order.Values["ProductID"] = ProductID.ToString();
                    Order.Values["Quantity"] = quantity;
                    Order.Values["Size"] = size;
                    Order.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(Order);
                }
                 Response.Redirect("~/Cart.aspx");
            }
            else
            {
                Response.Redirect("/CustLogin.aspx?rurl=view");
               
            }
        }
        protected void rptrProductDetails_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Int64 ProductID = Convert.ToInt64(Request.QueryString["ProductCode"]);

                RadioButtonList rblSize = e.Item.FindControl("rblSize") as RadioButtonList;

                DataTable sizeDet = new DataTable();
                //SqlDataAdapter sda = new SqlDataAdapter();
                SqlCommand cmd2 = new SqlCommand("SELECT ProductQnty,ProductSize,PID  FROM Product WHERE ProductCode = @ProductCode");
                // cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.AddWithValue("@ProductCode", ProductID);
                sizeDet = access.SelectFromDatabase(cmd2);
                foreach(DataRow rows in sizeDet.Rows)
                {
                    if(Convert.ToInt32(rows["ProductQnty"])==0)
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
         
            rptrProductDetails.DataSource = DetProduct;
            rptrProductDetails.DataBind();
            rptrImages.DataSource = DetProduct;
            rptrImages.DataBind();
        }
        
        protected void AddCart(object sender,System.EventArgs e)
        {
            string x=string.Empty;
            string qnty =string.Empty;
            foreach (RepeaterItem item in rptrProductDetails.Items)
            {
                if (item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem)
                {
                    var sizelst = item.FindControl("rblSize") as RadioButtonList;
                    TextBox txt = (TextBox)item.FindControl("productQnty") as TextBox;
                    qnty = txt.Text;
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
                
                if (qnty.Equals("0") || qnty==string.Empty)
                {
                    lblErr.Text = "Please add quantity for your product";
                    lblErr.ForeColor = Color.Red;
                }
                else
                {
                    lblErr.Text = "";
                    if (Session["Customer"] == null)
                    {
                        Response.Redirect("~/CustLogin.aspx");
                    }
                    else AddToCart(qnty,x);
                      
                }
            }
        }
    }
}