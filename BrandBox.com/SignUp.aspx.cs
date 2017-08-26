using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
using System.Drawing;
using System.IO;
using System.Data;

namespace BrandBox.com
{
    public partial class SignUp : System.Web.UI.Page
    {
        Accessible access = new Accessible();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["vendor"] == null)
            {
                
            }
            else
            {
                if (!IsPostBack)
                {
                    Response.Redirect("~/AboutUs.aspx");

                }
            }
        }

      

        protected void SignUpSuccessful(object sender, EventArgs e)
        {
            // Read the file and convert it to Byte Array
            string filePath = VendorFileUpload.PostedFile.FileName;
            string filename = Path.GetFileName(filePath);
            string ext = Path.GetExtension(filename);
            string contenttype = String.Empty;

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
                        VUploadError.Text = "Invalid Image";
                        VUploadError.ForeColor = Color.Red;
                        break;
                    }
            }



            if (access.checkEmail(vendorEmail.Text,'v'))
            {
                VEmailErrorMessage.Text = "Email address not available.";
                VEmailErrorMessage.ForeColor = Color.Red;
            }
            else if (access.checkBrandName(vendorName.Text))
            {
                VNameErrorMessage.Text = "This brand name has already been registered.";
                VNameErrorMessage.ForeColor = Color.Red;
            }
            else if(contenttype != String.Empty)
            {
                Stream fs = VendorFileUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);



                String CS = ConfigurationManager.ConnectionStrings["BrandBoxDatabaseConnectionString"].ConnectionString.ToString();
                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO VendorPayment(VTotalPayment,VProfit) VALUES(@VTotalPayment,@VProfit); SELECT SCOPE_IDENTITY()", con);
                    cmd.Parameters.AddWithValue("@VTotalPayment", 0);
                    cmd.Parameters.AddWithValue("@VProfit", 0);

                    int VendorPaymentFK = Convert.ToInt32(cmd.ExecuteScalar());


                    SqlCommand cmd2 = new SqlCommand("INSERT INTO Vendor(VendorEmail, VendorPassword, VendorLocation, VendorPhoneNo,VendorName,VendorDetails,VPaymentNo,ImageContentType,ImageData) VALUES(@VendorEmail,@VendorPassword,@VendorLocation,@VendorPhoneNo,@VendorName,@VendorDetails,@VPaymentNo,@ImageContentType,@ImageData)", con);
                    cmd2.Parameters.AddWithValue("@VendorEmail", vendorEmail.Text);
                    cmd2.Parameters.AddWithValue("@VendorPassword", vendorPassword.Text);
                    cmd2.Parameters.AddWithValue("@VendorLocation", vendorLocation.Text);
                    cmd2.Parameters.AddWithValue("@VendorPhoneNo", vendorphoneNum.Text);
                    cmd2.Parameters.AddWithValue("@VendorName", vendorName.Text);
                    cmd2.Parameters.AddWithValue("@VendorDetails", vendorDetails.Text);
                    cmd2.Parameters.AddWithValue("@VPaymentNo", VendorPaymentFK);
                    cmd2.Parameters.Add("@ImageContentType", SqlDbType.VarChar).Value = contenttype;
                    cmd2.Parameters.Add("@ImageData", SqlDbType.Binary).Value = bytes;

                    cmd2.ExecuteNonQuery();


                    Response.Redirect("~/Login.aspx");

                }
            }           
        }
    }
}