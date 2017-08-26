using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrandBox.com
{
    public partial class web : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindCartNumber();
        }

        public void BindCartNumber()
        {
            if (Session["Customer"] != null)
            {
                if (Request.Cookies["OrderID"] != null)
                {
                    string CookiePID = Request.Cookies["OrderID"].Value.Split('=')[1];
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