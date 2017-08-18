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
        int currentVendorId;
        string contenttype = String.Empty;
        Accessible access = new Accessible();
        String CS = ConfigurationManager.ConnectionStrings["BrandBoxDatabaseConnectionString"].ConnectionString.ToString();
        string[] size=  { "Small", "Medium", "Large" };
        

        protected void Page_Load(object sender, EventArgs e)
        {
            //getting current vendor id from tabe
            if (Session["id"] != null)
            {
                currentVendorId = Convert.ToInt32(Session["id"]);
            }

            if (!IsPostBack) {
                if (Session["vendor"] == null)
                {
                    Response.Redirect("~/AboutUs.aspx");
                }
                
                else if(Request.QueryString["ProductCode"] != null)
                {
                    if(Session["id"]==null)
                        Response.Redirect("~/AboutUs.aspx");
                    else
                    {
                        BindCategoryRptr();
                        editProduct(Request.QueryString["ProductCode"].ToString());
                    }
                   

                }
               else
               {
                    BindCategoryRptr();
               }               
            }
        }

        protected void updateDetail(String size)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("proceditProduct", con);

                cmd2.CommandType = CommandType.StoredProcedure;
                if (size.ToLower().Trim().Equals("small"))
                    cmd2.Parameters.AddWithValue("@ProductQnty", SproductQnty.Text);
                else if (size.ToLower().Trim().Equals("medium"))
                    cmd2.Parameters.AddWithValue("@ProductQnty", MproductQnty.Text);
                else if (size.ToLower().Trim().Equals("large"))
                    cmd2.Parameters.AddWithValue("@ProductQnty", LproductQnty.Text);

                cmd2.Parameters.AddWithValue("@ProductCode", Request.QueryString["ProductCode"].ToString());
                cmd2.Parameters.AddWithValue("ProductSize", size);

                cmd2.ExecuteNonQuery();
            }
        }

        protected void addDetail(Int64 ProductFK, String size,char s)
        {
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd2 = new SqlCommand("INSERT INTO Product(ProductQnty,ProductSize,ProductCode) VALUES(@ProductQnty,@ProductSize,@ProductCode)", con);

                if (s=='s')
                    cmd2.Parameters.AddWithValue("@ProductQnty", SproductQnty.Text);
                else if (s == 'm')
                    cmd2.Parameters.AddWithValue("@ProductQnty", MproductQnty.Text);
                else if (s == 'l')
                    cmd2.Parameters.AddWithValue("@ProductQnty", LproductQnty.Text);

                cmd2.Parameters.AddWithValue("@ProductSize", size);
                cmd2.Parameters.AddWithValue("@ProductCode", ProductFK);

                cmd2.ExecuteNonQuery();
            }
        }

        protected bool checkingForPUpdate(int n)
        {
            SqlCommand cmd2 = new SqlCommand(" SELECT * FROM Product where ProductCode=@ProductCode and ProductSize=@Size");
            cmd2.Parameters.AddWithValue("@ProductCode", Request.QueryString["ProductCode"].ToString());
            cmd2.Parameters.AddWithValue("@Size", size[n]);

            DataTable productDetailData = access.SelectFromDatabase(cmd2);
            if (productDetailData.Rows.Count > 0)
                return true;
            else
                return false;
        }

        private void AddProduct()
        {
            checkImage();

            if (contenttype != String.Empty && currentVendorId != 0 && validateCheckbox())
            {
                Stream fs = ProductImageFileUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO PDetails(VendorId,ProductPrice,ProductName," +
                        "ProductDetails,CategoryId,Gender,ImageContentType,ImageData) VALUES(@VendorId,@ProductPrice," +
                        "@ProductName,@ProductDetails,@PCID,@Gender,@ImageContentType,@ImageData);" +
                        " SELECT SCOPE_IDENTITY()", con);
                    cmd.Parameters.AddWithValue("@VendorId", currentVendorId);
                    cmd.Parameters.AddWithValue("@ProductPrice", productPrice.Text);
                    cmd.Parameters.AddWithValue("@ProductName", productName.Text);
                    cmd.Parameters.AddWithValue("@ProductDetails", productDetails.Text);
                    cmd.Parameters.AddWithValue("@PCID", Convert.ToInt32(productCategory.SelectedItem.Value));
                    cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedItem.Text);
                    cmd.Parameters.Add("@ImageContentType", SqlDbType.VarChar).Value = contenttype;
                    cmd.Parameters.Add("@ImageData", SqlDbType.Binary).Value = bytes;

                    Int64 ProductFK = Convert.ToInt64(cmd.ExecuteScalar());

                    if (chkSmall.Checked)
                        addDetail(ProductFK, size[0], 's');

                    if (chkMedium.Checked)
                        addDetail(ProductFK, size[1], 'm');
                    if (chkLarge.Checked)
                        addDetail(ProductFK, size[2], 'l');

                    Response.Redirect("~/AboutUs.aspx#signup");

                }
            }
        }

        private void UpdateProduct()
        {
            checkImage();

            if (contenttype != String.Empty && currentVendorId != 0 && validateCheckbox())
            {
                Stream fs = ProductImageFileUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("procUpdateProducts", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@VendorId", currentVendorId);
                    cmd.Parameters.AddWithValue("@ProductPrice", productPrice.Text);
                    cmd.Parameters.AddWithValue("@ProductName", productName.Text);
                    cmd.Parameters.AddWithValue("@ProductDetails", productDetails.Text);
                    cmd.Parameters.AddWithValue("@CategoryId", Convert.ToInt32(productCategory.SelectedItem.Value));
                    cmd.Parameters.AddWithValue("@Gender", ddlGender.SelectedItem.Text);
                    cmd.Parameters.Add("@ImageContentType", SqlDbType.VarChar).Value = contenttype;
                    cmd.Parameters.Add("@ImageData", SqlDbType.Binary).Value = bytes;
                    cmd.Parameters.AddWithValue("@ProductCode", Convert.ToInt64(Request.QueryString["ProductCode"]));

                    cmd.ExecuteNonQuery();

                    if (chkSmall.Checked)
                    {
                        if (checkingForPUpdate(0))
                            updateDetail(size[0]);
                        else
                            addDetail(Convert.ToInt64(Request.QueryString["ProductCode"]), size[0], 's');
                    }
                    else
                        if (checkingForPUpdate(0))
                        access.AddAndDelInDatabase("delete from Product where ProductCode=" + Request.QueryString["ProductCode"].ToString() + " and ProductSize='" + size[0] + "'");

                    if (chkMedium.Checked)
                    {
                        if (checkingForPUpdate(1))
                            updateDetail(size[1]);
                        else
                            addDetail(Convert.ToInt64(Request.QueryString["ProductCode"]), size[1], 'm');
                    }
                    else
                        if (checkingForPUpdate(1))
                        access.AddAndDelInDatabase("delete from Product where ProductCode=" + Request.QueryString["ProductCode"].ToString() + " and ProductSize='" + size[1] + "'");

                    if (chkLarge.Checked)
                    {
                        if (checkingForPUpdate(2))
                            updateDetail(size[2]);
                        else
                            addDetail(Convert.ToInt64(Request.QueryString["ProductCode"]), size[2], 'l');
                    }
                    else
                        if (checkingForPUpdate(2))
                    {
                        access.AddAndDelInDatabase("delete from Product where ProductCode = " + Request.QueryString["ProductCode"].ToString() + " AND ProductSize = '" + size[2] + "'");
                    }

                   // Session["pid"] = null;

                    Response.Redirect("~/AboutUs.aspx#signup");

                }
            }


        }

        protected void CreateProducts(object sender, EventArgs e)
        {

            if(Request.QueryString["ProductCode"] == null)
               AddProduct();
            
            else
               UpdateProduct();
        }       

        private void BindCategoryRptr()
        {
            DataTable categoryData = new DataTable();
            SqlCommand cmd = new SqlCommand(" SELECT p.PCID, p.ProductCatName FROM ProductCategory p JOIN VendorCatAssociation v ON(p.PCID = v.CategoryId) AND v.VendorId = @VId");
            cmd.Parameters.AddWithValue("@VId", currentVendorId);
            categoryData = access.SelectFromDatabase(cmd);

            if (categoryData.Rows.Count != 0)
                {
                    productCategory.DataSource = categoryData;
                    productCategory.DataTextField = "ProductCatName";
                    productCategory.DataValueField = "PCID";
                    productCategory.DataBind();
                    productCategory.Items.Insert(0, new ListItem("-Select-", "0"));
                   
                }
        }

        public void editProduct(String id)
        {
            DataTable productData = new DataTable();
            SqlCommand cmd = new SqlCommand(" SELECT * FROM PDetails where ProductCode=" + id);
            productData = access.SelectFromDatabase(cmd);
            if (productData.Rows.Count > 0)
            {
                foreach (DataRow row in productData.Rows)
                {
                    productPrice.Text = "";
                    productName.Text = row["ProductName"].ToString();
                    productCategory.SelectedValue = row["CategoryId"].ToString();

                    if (row["Gender"].ToString().ToLower().Trim().Equals("male"))
                        ddlGender.SelectedValue = 1.ToString();
                    else if(row["Gender"].ToString().ToLower().Trim().Equals("female"))
                        ddlGender.SelectedValue = 2.ToString();
                    else if(row["Gender"].ToString().ToLower().Trim().Equals("children"))
                        ddlGender.SelectedValue = 3.ToString();

                    productDetails.Text = row["ProductDetails"].ToString();

                    SqlCommand cmd2 = new SqlCommand(" SELECT * FROM Product where ProductCode=" + id);
                    DataTable productDetailData = access.SelectFromDatabase(cmd2);
                    if(productDetailData.Rows.Count > 0)
                    {
                        foreach(DataRow d in productDetailData.Rows)
                        {
                            if(d["ProductSize"].ToString().ToLower().Trim().Equals(size[2].ToLower()))
                            {
                                chkLarge.Checked = true;
                                LproductQnty.Enabled = true;
                                LproductQnty.Text = d["ProductQnty"].ToString();
                            }
                            else if(d["ProductSize"].ToString().ToLower().Trim().Equals(size[1].ToLower()))
                            {
                                chkMedium.Checked = true;
                                MproductQnty.Enabled = true;
                                MproductQnty.Text = d["ProductQnty"].ToString();

                            }
                            else if(d["ProductSize"].ToString().ToLower().Trim().Equals(size[0].ToLower()))
                            {
                                chkSmall.Checked = true;
                                SproductQnty.Enabled = true;
                                SproductQnty.Text = d["ProductQnty"].ToString();
                            }
                        }    
                    }
                }
            }         
        }

        protected void small_CheckedChanged(object sender, EventArgs e)
        {
            if (SproductQnty.Enabled)
            {
                SproductQnty.Enabled = false;
            }
            else
                SproductQnty.Enabled = true;

        }

        protected void medium_CheckedChanged(object sender, EventArgs e)
        {
            if (MproductQnty.Enabled)
            {
                MproductQnty.Enabled = false;
            }
            else
                MproductQnty.Enabled = true;
        }

        protected void large_CheckedChanged(object sender, EventArgs e)
        {
            if (LproductQnty.Enabled)
            {
                LproductQnty.Enabled = false;
            }
            else
                LproductQnty.Enabled = true;
        }

        protected bool validateCheckbox()
        {
            bool ret = true;

            if (!(chkSmall.Checked || chkLarge.Checked || chkMedium.Checked))
            {
                chkLabel.Text = "Please select at least one size";
                return false;
            }

            if (chkSmall.Checked)
            {
                if (SproductQnty.Text == null)
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

        public void checkImage()
        {
            // Read the file and convert it to Byte Array
            string filePath = ProductImageFileUpload.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);


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
        }
    }
}