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
    public partial class WebForm5 : System.Web.UI.Page
    {
        int currentVendorId;
        Accessible access = new Accessible();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["id"] != null)
            {
                currentVendorId = Convert.ToInt32(Session["id"]);
            }
            if (!IsPostBack)
            {
                if (Session["vendor"] == null)
                {
                    Response.Redirect("~/AboutUs.aspx");
                }
                else
                {

                    BindMyProductsRptr();
                }
            }
        }

        private void BindMyProductsRptr()
        {
            DataTable categoryData = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT ProductPrice,ImageData,ProductName From PDetails Where VendorId = @VId");
            cmd.Parameters.AddWithValue("@VId", currentVendorId);
            categoryData = access.SelectFromDatabase(cmd);

            MyProductsRptr.DataSource = categoryData;
            MyProductsRptr.DataBind();
        }
    }
}