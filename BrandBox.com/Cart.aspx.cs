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
using BrandBox.com;

namespace BrandBox.com
{
    public partial class WebForm10 : System.Web.UI.Page
    {
        String CS = ConfigurationManager.ConnectionStrings["BrandBoxDatabaseConnectionString"].ConnectionString.ToString();

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

        private string getUserName()
        {
            String userName = string.Empty;
            DataTable user = new DataTable();
            SqlCommand cmd2 = new SqlCommand("SELECT CustomerName  FROM CustomerDetails WHERE CustomerEmailAddress = @email");
            cmd2.Parameters.AddWithValue("@email", Session["Customer"].ToString());
            user = access.SelectFromDatabase(cmd2);
            foreach (DataRow rows in user.Rows)
            {
                userName = rows["CustomerName"].ToString();
            }
            return userName;
        }

        private Int64 getCId()
        {
            Int64 cId = 0;
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
            string CookieQuantity = Request.Cookies["OrderID" + cId.ToString()]["Quantity"].Split('=')[0];
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
                deleteCookie();

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

        protected void checkOut_Click(object sender, EventArgs e)
        {
            Int64 cId = getCId();

            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                SqlCommand cmd = new SqlCommand("INSERT INTO OrderTable(CustomerID, PurchaseDateTime) VALUES('" + cId.ToString() + "', '" + DateTime.Now + "'); SELECT SCOPE_IDENTITY()", con);


                int OrderId = Convert.ToInt32(cmd.ExecuteScalar());

                string CookiePID = Request.Cookies["OrderID" + cId.ToString()]["ProductID"].Split('=')[0];
                string CookieQuantity = Request.Cookies["OrderID" + cId.ToString()]["Quantity"].Split('=')[0];
                string CookieSize = Request.Cookies["OrderID" + cId.ToString()]["Size"].Split('=')[0];


                List<String> CookiePIDList = CookiePID.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
                List<String> CookieQuantityList = CookieQuantity.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();
                List<String> CookieSizeList = CookieSize.Split(',').Select(i => i.Trim()).Where(i => i != string.Empty).ToList();



                for (int i = 0; i < CookiePIDList.Count; i++)
                {
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO OrderDetails(ProductCode,OrderQnty,OrderSize,OrderTotalPrice,OrderID) VALUES(@ProductCode,@OrderQnty,@OrderSize,@OrderTotalPrice,@OrderID)", con);
                    cmd2.Parameters.AddWithValue("@ProductCode", CookiePIDList.ElementAt(i));
                    cmd2.Parameters.AddWithValue("@OrderQnty", CookieQuantityList.ElementAt(i));
                    cmd2.Parameters.AddWithValue("@OrderSize", CookieSizeList.ElementAt(i));

                    DataTable price = new DataTable();
                    SqlCommand cmd3 = new SqlCommand("Select ProductPrice from PDetails where ProductCode=" + CookiePIDList.ElementAt(i));

                    price = access.SelectFromDatabase(cmd3);


                    cmd2.Parameters.AddWithValue("@OrderTotalPrice", Convert.ToInt64(price.Rows[0]["ProductPrice"]) * Convert.ToInt64(CookieQuantityList.ElementAt(i)));
                    cmd2.Parameters.AddWithValue("@OrderID", OrderId);



                    int x = cmd2.ExecuteNonQuery();

                    if (x > 0)
                    {
                        addCustomerpayment(cId.ToString(),OrderId.ToString());
                        subtractItems(CookiePIDList.ElementAt(i), CookieQuantityList.ElementAt(i), CookieSizeList.ElementAt(i));
                        Accessible.sendOrderToCustomer(Session["Customer"].ToString(), OrderId.ToString(), getUserName());
                       deleteCookie();
                    }

                }

            }


        }
        private void deleteCookie()
        {
            Int64 cId = getCId();
            HttpCookie CartProducts = Request.Cookies["OrderID" + cId.ToString()];
            CartProducts.Values["ProductID"] = null;
            CartProducts.Values["Quantity"] = null;
            CartProducts.Values["Size"] = null;
            CartProducts.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(CartProducts);


            Response.Redirect(Request.RawUrl);
        }
        private void addCustomerpayment(string CustId,string orderID)
        {
            DataTable orderPrice = new DataTable();
            Int64 totalPay = 0;
            SqlCommand cmd = new SqlCommand("SELECT OrderTotalPrice From OrderDetails Where OrderID = @OId");
            cmd.Parameters.AddWithValue("@OId", orderID);
            orderPrice = access.SelectFromDatabase(cmd);

            if (orderPrice.Rows.Count > 0)
            {
                foreach(DataRow row in orderPrice.Rows)
                {
                    totalPay += Convert.ToInt64(row["OrderTotalPrice"]);
                }
            }


            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
              
                SqlCommand cmd2 = new SqlCommand("Update CustomerPayment set CTotalPayment=@totalPay, OrderId=@OrderId WHERE CustomerID=" + CustId, con);
                cmd2.Parameters.AddWithValue("@TotalPay", totalPay);
                cmd2.Parameters.AddWithValue("@OrderId", orderID);


                cmd2.ExecuteNonQuery();

            }

           
        
        }
        private void subtractItems(string pid, string qnty, string size)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();

                SqlCommand cmd3 = new SqlCommand("Select ProductQnty From Product where ProductCode='" + pid + "' AND ProductSize='" + size + "'");
                DataTable qntyTable = access.SelectFromDatabase(cmd3);
                Int64 quantity = Convert.ToInt64(qntyTable.Rows[0]["ProductQnty"]);
                Int64 purchasedQnty = Convert.ToInt64(qnty);
                Int64 updateQuantity = (quantity - purchasedQnty);
                SqlCommand cmd = new SqlCommand("Update Product set ProductQnty='" + updateQuantity+"' where ProductCode='"+pid+"' AND ProductSize='"+size+"'", con);

               // msg.Text = quantity + " " + purchasedQnty + " " + updateQuantity;
                cmd.ExecuteNonQuery();

            }
        }
    }
}