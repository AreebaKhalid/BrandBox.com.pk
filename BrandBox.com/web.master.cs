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

        }
       

        protected void LogOutBtn(object sender, EventArgs e)
        {
            Session["vendor"] = null;
            Session["id"] = null;
            Session["pid"] = null;
            Response.Redirect("~/AboutUs.aspx");
        }

    }
}