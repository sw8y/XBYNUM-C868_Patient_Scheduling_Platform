using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XBYNUM_C969_Application_Development.Controller;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using XBYNUM_C969_Application_Development.Model;

namespace XBYNUM_C969_Application_Development.Controller
{
    public class CityController : CountryController
    {
        public int lookupCityId(MySqlConnection connection, string city)
        {
            //connection.Open();
            int cityId;
            try
            {
                var sql_city_id = "SELECT cityId FROM city WHERE city=@city;";
                MySqlCommand cmd = new MySqlCommand(sql_city_id, connection);
                cmd.Parameters.AddWithValue("@city", city);
                cityId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when adding city: " + ex.Message);
                cityId = 0;
            }
            finally
            {
                //connection.Close();
            }

            return cityId;
        }
        public void addCity(MySqlConnection connection, Patient patient)
        {

            try
            {
                var sql_city = "INSERT IGNORE INTO city (city, countryId, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "SELECT @city, (SELECT countryId FROM country WHERE country=@country), @createDate, @createdBy, @lastUpdate, @lastUpdateBy FROM DUAL WHERE NOT EXISTS " +
                    "(SELECT * FROM city WHERE city=@city); ";
                MySqlCommand cmd = new MySqlCommand(sql_city, connection);
               
                cmd.Parameters.AddWithValue("@city", patient.city);
                cmd.Parameters.AddWithValue("@countryId", patient.countryId);
                cmd.Parameters.AddWithValue("@country", patient.country);
                cmd.Parameters.AddWithValue("@createDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@createdBy", User.username);
                cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@lastUpdateBy", User.username);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when adding country: " + ex.Message);
            }
            finally
            {
                
            }
        }
    }
}
