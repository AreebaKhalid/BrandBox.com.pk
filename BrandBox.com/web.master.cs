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
    public partial class web : System.Web.UI.MasterPage
    {
        Int64 cId;
        Accessible access = new Accessible();
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCartNumber();
        }

        public void BindCartNumber()
        {
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
                if (Request.Cookies["OrderID" + cId.ToString()] != null)
                {
                    string CookiePID = Request.Cookies["OrderID" + cId.ToString()]["ProductID"].Split('=')[0];
                    string[] ProductArray = CookiePID.Split(',');
                    int ProductCount = ProductArray.Length;
                    pCount.InnerText = ProductCount.ToString();
                }
                else
                {
                    pCount.InnerText = 0.ToString();
                }
            }
            else
            {
                pCount.InnerText = 0.ToString();
            }
        }

        protected void LogOutBtn(object sender, EventArgs e)
        {
            if(Session["vendor"]!=null)
            {
                Session["vendor"] = null;
                Session["id"] = null;
            }
            if(Session["Customer"]!=null)
            {
                Session["Customer"] = null;
            }
            Response.Redirect("~/AboutUs.aspx");
        }
        protected void CartClick(object sender, EventArgs e)
        {
            if (Session["Customer"] == null)
            {
                Response.Redirect("~/CustLogin.aspx");
            }
            else
                Response.Redirect("~/Cart.aspx");
        }
    }
}