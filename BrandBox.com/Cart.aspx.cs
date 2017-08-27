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
                {
                    
                    BindCartProducts();
                }
                else
                    Response.Redirect("~/Login.aspx");
                

            }
        }

        private Int64 getCId()
        {
            Int64 cId=0;
            DataTable idTab = new DataTable();
            SqlCommand cmd2 = new SqlCommand("SELECT CustomerID  FROM CustomerDetails WHERE CustomerEmailAddress = @email");
            cmd2.Parameters.AddWithValue("@email", Session["Customer"].ToString());
            idTab = access.SelectFromDatabase(cmd2);
            foreach (DataRow rows in idTab.Rows)
            {
                cId = Convert.ToInt64(rows["CustomerID"]);
            }
            return cId;
        }

        private void BindCartProducts()
            {
            Int64 cId = getCId();
            if (Request.Cookies["OrderID" + cId.ToString()] != null)
                {
                    string CookieData = Request.Cookies["OrderID" + cId.ToString()]["ProductID"].Split('=')[0];
                    string[] CookieDataArray = CookieData.Split(',');


                    string CookieQuantity = Request.Cookies["OrderID" + cId.ToString()]["Quantity"].Split('=')[0];
                    string[] CookieQuantityArray = CookieQuantity.Split(',');

                    string CookieSize = Request.Cookies["OrderID" + cId.ToString()]["Size"].Split('=')[0];
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

                            SqlCommand cmd = new SqlCommand("Select * from PDetails where ProductCode=" + ProductID);

                            cartitems.Merge(access.SelectFromDatabase(cmd));

                            cartitems.Rows[i]["ProductQnty"] = CookieQuantityArray[i].ToString().Split('-')[0];
                            cartitems.Rows[i]["ProductSize"] = CookieSizeArray[i].ToString().Split('-')[0];

                            CartTotal += Convert.ToInt64(cartitems.Rows[i]["ProductPrice"]) * Convert.ToInt64(cartitems.Rows[i]["ProductQnty"]);
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
            Int64 cId = getCId();
            string CookiePID = Request.Cookies["OrderID" + cId.ToString()]["ProductID"].Split('=')[0];
            string CookieQuantity = Request.Cookies["OrderID"+cId.ToString()]["Quantity"].Split('=')[0];
            string CookieSize = Request.Cookies["OrderID" + cId.ToString()]["Size"].Split('=')[0];
            LinkButton btn = (LinkButton)sender;
            string PID = btn.CommandArgument;
            List<String> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
            List<String> CookieQuantityList = CookieQuantity.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
            List<String> CookieSizeList = CookieSize.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
            Int32 ind = CookiePIDList.IndexOf(PID);


            CookieQuantityList.RemoveAt(ind);
            CookieSizeList.RemoveAt(ind);
            CookiePIDList.RemoveAt(ind);

            string CookiePIDUpdated = String.Join(",", CookiePIDList.ToArray());
            string CookieQntyUpdated = String.Join(",", CookieQuantityList.ToArray());
            string CookieSizeUpdated = String.Join(",", CookieSizeList.ToArray());

            if (CookiePIDUpdated == "")
            {
                HttpCookie CartProducts = Request.Cookies["OrderID"+ cId.ToString()];
                CartProducts.Values["ProductID"] = null;
                CartProducts.Values["Quantity"] = null;
                CartProducts.Values["Size"] = null;
                CartProducts.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(CartProducts);

            }
            else
            {
                HttpCookie CartProducts = Request.Cookies["OrderID" + cId.ToString()];
                CartProducts.Values["ProductID"] = CookiePIDUpdated;
                CartProducts.Values["Quantity"] = CookieQntyUpdated;
                CartProducts.Values["Size"] = CookieSizeUpdated;
                CartProducts.Expires = DateTime.Now.AddDays(30);
                Response.Cookies.Add(CartProducts);

            }
            Response.Redirect("~/Cart.aspx");

        }
    }
}