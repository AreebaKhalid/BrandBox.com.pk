using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrandBox.com
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        Accessible access = new Accessible();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Session["Customer"] != null)
                    BindCartProducts();
                else
                    Response.Redirect("~/Login.aspx");
            }

        }
        private void BindCartProducts()
        {
            if (Request.Cookies["OrderID"] != null)
            {
                string CookieData = Request.Cookies["OrderID"]["OrderID"].Split('=')[0];
                string[] CookieDataArray = CookieData.Split(',');

                
                string CookieQuantity = Request.Cookies["OrderID"]["Quantity"].Split('=')[0];
                string[] CookieQuantityArray = CookieQuantity.Split(',');

                string CookieSize = Request.Cookies["OrderID"]["Size"].Split('=')[0];
                string[] CookieSizeArray = CookieSize.Split(',');

                if (CookieDataArray.Length > 0)
                {
                    h2NoItems.InnerText = "MY CART (" + CookieDataArray.Length + " Items)";
                    DataTable cartitems = new DataTable();
                    cartitems.Columns.Add("ProductQnty");
                    cartitems.Columns.Add("ProductSize");

                    DataTable det = new DataTable();
                    Int64 CartTotal = 0;
                    Int64 Total = 0;
                    Int64 Discount = 0;
                    for (int i = 0; i < CookieDataArray.Length; i++)
                    {
                        string ProductID = CookieDataArray[i].ToString().Split('-')[0];

                        SqlCommand cmd = new SqlCommand("Select * from PDetails where ProductCode="+ProductID);

                        //DataTable dt = new DataTable();

                        
                        //DataRow dr = dt.NewRow();
                      //  DataRow ds = cartitems.NewRow();

                        

                       // dt.Rows.Add(dr);

                       // det.Merge(dt);
                        //cartitems.Rows.AsParallel(dt);                        
                        cartitems.Merge(access.SelectFromDatabase(cmd));

                        cartitems.Rows[i]["ProductQnty"] = CookieQuantityArray[i].ToString().Split('-')[0];
                        cartitems.Rows[i]["ProductSize"] = CookieSizeArray[i].ToString().Split('-')[0];

                        /*foreach(DataRow d in cartitems.Rows)
                        {
                            cartitems.Rows.Add(ds);
                        }*/

                        CartTotal += Convert.ToInt64(cartitems.Rows[i]["ProductPrice"]);
                        Discount = (CartTotal * 10) / 100;

                    }

                    rptrCartProducts.DataSource = cartitems;
                    rptrCartProducts.DataBind();
                 
                    divPriceDetails.Visible = true;

                    spanCartTotal.InnerText = CartTotal.ToString();
                    spanDiscount.InnerText = "Rs. " + Discount.ToString();
                    Total = CartTotal - Discount;
                    spanTotal.InnerText = "Rs. " + Total.ToString();


                }

                else
                {
                    //TODO Show Empty Cart
                    h2NoItems.InnerText = "Your Shopping Cart is Empty";
                    divPriceDetails.Visible = false;

                }
            }
            else
            {
                //TODO Show Empty Cart
                h2NoItems.InnerText = "Your Shopping Cart is Empty";
                divPriceDetails.Visible = false;


            }

        }
        protected void btnRemoveItem_Click(object sender, EventArgs e)
        {
            string CookiePID = Request.Cookies["OrderID"].Value.Split('=')[1];
            LinkButton btn = (LinkButton)sender;
            string PID = btn.CommandArgument;
            List<String> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
            CookiePIDList.Remove(PID);
            string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
            if (CookiePIDUpdated == "")
            {
                HttpCookie CartProducts = Request.Cookies["OrderID"];
                CartProducts.Values["OrderID"] = null;
                CartProducts.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(CartProducts);

            }
            else
            {
                HttpCookie CartProducts = Request.Cookies["OrderID"];
                CartProducts.Values["OrderID"] = CookiePIDUpdated;
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);

            }
            Response.Redirect("~/Cart.aspx");

        }
    }
}