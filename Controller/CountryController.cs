using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using XBYNUM_C969_Application_Development.Model;
using System.Windows.Forms;

namespace XBYNUM_C969_Application_Development.Controller
{
    public class CountryController : Patient
    {
        public int lookupCountryId(MySqlConnection connection, string country) 
        {
            //connection.Open();
            int countryId;
            try
            {
                var sql_country_id = "SELECT countryId FROM country WHERE country=@country;";
                MySqlCommand cmd = new MySqlCommand(sql_country_id, connection);
                cmd.Parameters.AddWithValue("@country", country);
                countryId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when adding country: " + ex.Message);
                countryId = 0;
            }
            finally
            {
                //connection.Close();
            }

            return countryId;
        }
        public void addCountry(MySqlConnection connection, Patient customer)
        { 
            try 
            {
                var sql_country = "INSERT IGNORE INTO country (country, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "SELECT @country, @createDate, @createdBy, @lastUpdate, @lastUpdateBy FROM DUAL WHERE NOT EXISTS " +
                    "(SELECT * FROM country WHERE country=@country);";
                MySqlCommand cmd = new MySqlCommand(sql_country, connection);
                cmd.Parameters.AddWithValue("@country", customer.country);
                cmd.Parameters.AddWithValue("@createDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@createdBy", User.username);
                cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@lastUpdateBy", User.username);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex) 
            {
                Console.WriteLine("Error when adding country: " + ex.Message);
                countryId = 0;
            }
            finally 
            {
                //connection.Close();
            }
        }
    }
}
