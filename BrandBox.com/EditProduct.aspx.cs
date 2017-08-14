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
    public partial class WebForm6 : System.Web.UI.Page
    {
        Accessible access = new Accessible();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pid"] != null)
            {
                //BindEditFormRptr();
                editProduct(Session["pid"].ToString());
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
                    productPrice.Text = row["ProductPrice"].ToString();
                    productName.Text = row["ProductName"].ToString();
                    productCategory.SelectedValue = row["CategoryId"].ToString();
                    ddlGender.SelectedItem.Text = row["Gender"].ToString();

                    productDetails.Text = row["ProductDetails"].ToString();

                    SqlCommand cmd2 = new SqlCommand(" SELECT * FROM Product where ProductCode=" + id);
                    DataTable productDetailData = access.SelectFromDatabase(cmd2);
                    if (productDetailData.Rows.Count > 0)
                    {
                        foreach (DataRow d in productDetailData.Rows)
                        {
                            if (d["ProductSize"].ToString().ToLower().Trim().Equals("large"))
                            {
                                chkLarge.Checked = true;
                                LproductQnty.Enabled = true;
                                LproductQnty.Text = d["ProductQnty"].ToString();
                            }
                            else if (d["ProductSize"].ToString().ToLower().Trim().Equals("medium"))
                            {
                                chkMedium.Checked = true;
                                MproductQnty.Enabled = true;
                                MproductQnty.Text = d["ProductQnty"].ToString(); ;

                            }
                            else if (d["ProductSize"].ToString().ToLower().Trim().Equals("small"))
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

        protected void editProduct(object sender, EventArgs e)
        {
            /*
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
                        cmd.Parameters.AddWithValue("@ProductCode", Session["pid"].ToString());
                        cmd.ExecuteNonQuery();


                        /* if (chkSmall.Checked)
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
                         }*/


            /* Response.Redirect("~/AboutUs.aspx#signup");

         }
     }

     Session["pid"] = null;

    }*/
        }
    }

    
    }