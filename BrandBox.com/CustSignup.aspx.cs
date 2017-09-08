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
    public partial class WebForm9 : System.Web.UI.Page
    {
        Accessible access = new Accessible();
        String CS = ConfigurationManager.ConnectionStrings["BrandBoxDatabaseConnectionString"].ConnectionString.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Customer"] != null)
                {
                    Response.Redirect("~/AboutUs.aspx");
                }
                else
                {

                    BindCityRptr();
                }
            }

        }
        protected void SignUpSuccessful(object sender, EventArgs e)
        {
            if (access.checkEmail(custEmail.Text, 'c'))
            {
                CEmailErrorMessage.Text = "Email address not available.";
                CEmailErrorMessage.ForeColor = Color.Red;
            }
            else if (access.checkEmail(custEmail.Text, 'v'))
            {
                CEmailErrorMessage.Text = "You have already signed as brand.";
                CEmailErrorMessage.ForeColor = Color.Red;
            }
            else
            {
                string randomVCode = access.genCode();
                Accessible.sendMsg(custEmail.Text, custName.Text, custPassword.Text, randomVCode);

                using (SqlConnection con = new SqlConnection(CS))
                {
                    con.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO CustomerDetails(CustomerName,CustomerAddress,CustomerPhoneNo,CustomerEmailAddress,CustomerPassword,CustomerCityId,VerifiedEmail,VerificationCode) VALUES(@CustomerName,@CustomerAddress,@CustomerPhoneNo,@CustomerEmailAddress,@CustomerPassword,@CustomerCityId,@VerifiedEmail,@VerificationCode); SELECT SCOPE_IDENTITY()", con);
                    cmd.Parameters.AddWithValue("@CustomerName",custName.Text);
                    cmd.Parameters.AddWithValue("@CustomerAddress",custLocation.Text);
                    cmd.Parameters.AddWithValue("@CustomerPhoneNo",custphoneNum.Text);
                    cmd.Parameters.AddWithValue("@CustomerEmailAddress",custEmail.Text);
                    cmd.Parameters.AddWithValue("@CustomerPassword",custPassword.Text);
                    cmd.Parameters.AddWithValue("@CustomerCityId", custCity.SelectedItem.Value);
                    cmd.Parameters.AddWithValue("@VerifiedEmail", 0);
                    cmd.Parameters.AddWithValue("@VerificationCode", randomVCode);

                    cmd.ExecuteNonQuery();


                    Response.Redirect("/Activation.aspx?rurl=notVerifiedCust");

                }
            }
        }
        private void BindCityRptr()
        {
            DataTable cityData = new DataTable();
            SqlCommand cmd = new SqlCommand(" SELECT * from CityTable");
            cityData = access.SelectFromDatabase(cmd);

            if (cityData.Rows.Count != 0)
            {
                custCity.DataSource = cityData;
                custCity.DataTextField = "CityName";
                custCity.DataValueField = "Id";
                custCity.DataBind();
                custCity.Items.Insert(0, new ListItem("-Select-", "0"));
            }           
        }
    }
}