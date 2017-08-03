using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrandBox.com
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vendor"] == null)
            {
                Response.Redirect("~/AboutUs.aspx");
            }
            else
            {
                //nothing


            }
        }
    }
}