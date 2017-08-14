using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrandBox.com
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        WebForm2 obj = new WebForm2();
        int currentVendorId;
        Accessible access = new Accessible();
        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {
                if (Session["vendor"] == null)
                {
                    Response.Redirect("~/AboutUs.aspx");
                }
                else
                {
                    if (Session["id"] != null)
                    {
                        currentVendorId = Convert.ToInt32(Session["id"]);
                    }
                    BindMyProductsRptr();
                }
            }
        }

        private void BindMyProductsRptr()
        {
            DataTable categoryData = new DataTable();
            SqlCommand cmd = new SqlCommand("SELECT ProductPrice,ImageData,ProductName,ProductCode From PDetails Where VendorId = @VId");
            cmd.Parameters.AddWithValue("@VId", currentVendorId);
            categoryData = access.SelectFromDatabase(cmd);

            MyProductsRptr.DataSource = categoryData;
            MyProductsRptr.DataBind();
        }

     

        protected void Repeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            string id = Convert.ToString(e.CommandArgument);
            switch (e.CommandName)
            {
                case ("Delete"):
                    DeleteRepeaterData(id);
                    break;
                case ("Edit"):
                    EditProduct(id);
                    Response.Redirect("~/AddProduct.aspx");
                    break;
               
            }
        }
        private void EditProduct(String id)
        {
            Session["pid"] = id;
        }
        private void DeleteRepeaterData(string id)
        {
            string str = "delete from Product where ProductCode=" + id;
            if(access.AddAndDelInDatabase(str))
            {
                string str2 = "delete from PDetails where ProductCode=" + id;
                if(access.AddAndDelInDatabase(str2))
                {
                    lblDel.Text = "Record Deleted Successfully";
                    lblDel.ForeColor = System.Drawing.Color.Green;
                    BindMyProductsRptr();
                }
            }
            else
            {
                lblDel.Text = "Unable to delete";
                lblDel.ForeColor = System.Drawing.Color.Red;

            }
        }

    }
}