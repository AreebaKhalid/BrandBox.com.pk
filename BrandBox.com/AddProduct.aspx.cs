using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BrandBox.com
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        String CS = ConfigurationManager.ConnectionStrings["BrandBoxDatabaseConnectionString"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            Accessible access = new Accessible();
            if (!IsPostBack) {
                if (Session["vendor"] == null)
                {
                    Response.Redirect("~/AboutUs.aspx");
                }
                else
                {

                    BindCategoryRptr();


                }
            }
        }

        protected bool validateCheckbox()
        {
            bool ret=true;

            if(!(chkSmall.Checked || chkLarge.Checked || chkMedium.Checked))
            {
                chkLabel.Text = "Please select at least one size";
                return false;
            }

            if(chkSmall.Checked)
            {
                if(SproductQnty.Text == null)
                {
                    chkLabel.Text = "Please enter product Qnty";
                    chkLabel.ForeColor = Color.Red;
                    ret = false;
                }
            }
            if (chkLarge.Checked)
            {
                if (LproductQnty.Text == null)
                {
                    chkLabel.Text = "Please enter product Qnty";
                    chkLabel.ForeColor = Color.Red;
                    ret = false;
                }
            }
            if (chkMedium.Checked)
            {
                if (MproductQnty.Text == null)
                {
                    chkLabel.Text = "Please enter product Qnty";
                    chkLabel.ForeColor = Color.Red;
                    ret = false;
                }
            }
            return ret;

        }

        protected void CreateProducts(object sender, EventArgs e)
        {

           

            // Read the file and convert it to Byte Array
            string filePath = ProductImageFileUpload.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;
            int currentVendorId = 0;

            //getting current vendor id from tabe
            if (Session["id"] != null)
            {
                currentVendorId = Convert.ToInt32(Session["id"]);
            }


                //Set the contenttype based on File Extension
                switch (ext)
            {
                case ".jpg":
                    contenttype = "image/jpg";
                    break;
                case ".png":
                    contenttype = "image/png";
                    break;
                case ".gif":
                    contenttype = "image/gif";
                    break;
                case ".pdf":
                    contenttype = "application/pdf";
                    break;
                default:
                    {
                        PImageUploadError.Text = "Invalid Image";
                        PImageUploadError.ForeColor = Color.Red;
                        break;
                    }
            }

            if (contenttype != String.Empty && currentVendorId != 0 && validateCheckbox())
            {
                Stream fs = ProductImageFileUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);



                 using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO PDetails(VendorId,ProductPrice,ProductName," +
                        "ProductDetails,CategoryId,ImageContentType,ImageData) VALUES(@VendorId,@ProductPrice," +
                        "@ProductName,@ProductDetails,@PCID,@ImageContentType,@ImageData);" +
                        " SELECT SCOPE_IDENTITY()", con);
                    cmd.Parameters.AddWithValue("@VendorId", currentVendorId);
                    cmd.Parameters.AddWithValue("@ProductPrice",productPrice.Text);
                    cmd.Parameters.AddWithValue("@ProductName", productName.Text);
                    cmd.Parameters.AddWithValue("@ProductDetails", productDetails.Text);
                    cmd.Parameters.AddWithValue("@PCID", Convert.ToInt32(productCategory.SelectedItem.Value));
                    cmd.Parameters.Add("@ImageContentType", SqlDbType.VarChar).Value = contenttype;
                    cmd.Parameters.Add("@ImageData", SqlDbType.Binary).Value = bytes;

                    int ProductFK = Convert.ToInt32(cmd.ExecuteScalar());


                    if (chkSmall.Checked)
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO Product(ProductQnty,ProductSize,ProductCode) VALUES(@ProductQnty,@ProductSize,@ProductCode)", con);
                        cmd2.Parameters.AddWithValue("@ProductQnty", SproductQnty.Text);
                        cmd2.Parameters.AddWithValue("@ProductSize", "Small");
                        cmd2.Parameters.AddWithValue("@ProductCode", ProductFK);
                        cmd2.ExecuteNonQuery();

                    }
                    if (chkMedium.Checked)
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO Product(ProductQnty,ProductSize,ProductCode) VALUES(@ProductQnty,@ProductSize,@ProductCode)", con);
                        cmd2.Parameters.AddWithValue("@ProductQnty", MproductQnty.Text);
                        cmd2.Parameters.AddWithValue("@ProductSize", "Medium");
                        cmd2.Parameters.AddWithValue("@ProductCode", ProductFK);
                        cmd2.ExecuteNonQuery();
                    }
                    if (chkLarge.Checked)
                    {
                        SqlCommand cmd2 = new SqlCommand("INSERT INTO Product(ProductQnty,ProductSize,ProductCode) VALUES(@ProductQnty,@ProductSize,@ProductCode)", con);
                        cmd2.Parameters.AddWithValue("@ProductQnty", LproductQnty.Text);
                        cmd2.Parameters.AddWithValue("@ProductSize", "Large");
                        cmd2.Parameters.AddWithValue("@ProductCode", ProductFK);
                        cmd2.ExecuteNonQuery();
                    }


                    Response.Redirect("~/AboutUs.aspx#signup");

                }
            }



        }

       

        private void BindCategoryRptr()
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                SqlCommand cmd = new SqlCommand("select * from ProductCategory", con);
                con.Open();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count != 0)
                {
                    productCategory.DataSource = dt;
                    productCategory.DataTextField = "ProductCatName";
                    productCategory.DataValueField = "PCID";
                    productCategory.DataBind();
                    productCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                   
                }
            }
            
        }
        

    }
}