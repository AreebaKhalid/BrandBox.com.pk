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
    public partial class WebForm11 : System.Web.UI.Page
    {
        Accessible access = new Accessible();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customer"] != null)
            {
                if (!IsPostBack)
                {
                    if(Request.QueryString["OrderID"] != null)
                    {
                        BindCartProducts();
                        BindOrderDetails();
                    }
                    else
                    {
                        Response.Redirect("~/Login.aspx");
                    }


                }
                else
                {
                    Response.Redirect("~/Login.aspx");
                }

            }
            else
            {
                Response.Redirect("~/Login.aspx");
            }
        }
        public void BindCartProducts()
        {
            Int64 OrderID = Convert.ToInt64(Request.QueryString["OrderID"]);
            DataTable cartitems = new DataTable();
            SqlCommand cmd = new SqlCommand("select p.ProductName,p.ImageData, o.OrderQnty, o.OrderTotalPrice from OrderDetails o JOIN PDetails p ON p.ProductCode=o.ProductCode  where OrderID=" + OrderID + "");
            cartitems = access.SelectFromDatabase(cmd);

            if (cartitems.Rows.Count > 0)
            {
                h2NoItems.InnerText = "Items you buyed (" + cartitems.Rows.Count + ")";
                rptrCartProducts.DataSource = cartitems;
                rptrCartProducts.DataBind();
            }
            else
            {
                //TODO Show Empty Cart
                h2NoItems.InnerText = "Your Shopping Cart is Empty";
            }

        }





        private void BindOrderDetails()
        {
            Int64 OrderID = Convert.ToInt64(Request.QueryString["OrderID"]);

            SqlCommand cmd = new SqlCommand("select o.OrderID,c.CustomerAddress,p.CTotalPayment from OrderTable o JOIN CustomerDetails c ON o.CustomerID=c.CustomerID JOIN CustomerPayment p ON p.OrderId=o.OrderID where o.OrderID=" + OrderID + "");

            DataTable dtOrders = new DataTable();
            dtOrders = access.SelectFromDatabase(cmd);
            rptrOrderDetails.DataSource = dtOrders;
            rptrOrderDetails.DataBind();


        }
    }
}