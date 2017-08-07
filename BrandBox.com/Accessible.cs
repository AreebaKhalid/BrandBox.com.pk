using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Web;

namespace BrandBox.com
{
    public class Accessible
    {
        public static string GetImage(object img)
        {
            return "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
        }
        public bool AddInDatabase(String SQL_Insert)
        {
            int x;
            String CS = ConfigurationManager.ConnectionStrings["BrandBoxDatabaseConnectionString"].ConnectionString.ToString();
            using (SqlConnection con = new SqlConnection(CS))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand(SQL_Insert, con);

                x = cmd.ExecuteNonQuery();
                
            }
            if (x > 0)
                return true;
            else
                return false;

        }
        public DataTable SelectFromDatabase(SqlCommand SQL_Select_Qury)
        {
            String CS = ConfigurationManager.ConnectionStrings["BrandBoxDatabaseConnectionString"].ConnectionString.ToString();
            SQL_Select_Qury.CommandType = CommandType.Text;
            using (SqlConnection con = new SqlConnection(CS))
            {
                SQL_Select_Qury.Connection = con;
                con.Open();
                using (SqlDataAdapter sda = new SqlDataAdapter(SQL_Select_Qury))
                {
                    DataTable toReturn = new DataTable();
                    sda.Fill(toReturn);
                    return toReturn;
                }
            }
        }
    }
}