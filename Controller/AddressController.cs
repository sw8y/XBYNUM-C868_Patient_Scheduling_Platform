using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using XBYNUM_C969_Application_Development.Model;

namespace XBYNUM_C969_Application_Development.Controller
{
    public class AddressController : CityController
    {
        public int lookupAddressId(MySqlConnection connection, string address, string address2)
        {
            //connection.Open();
            int addressId;
            try
            {
                if (string.IsNullOrEmpty(address2)) 
                {
                    var sql_address_id = "SELECT addressId FROM address WHERE address=@address;"; //AND address2 IS NULL;";
                    MySqlCommand cmd = new MySqlCommand(sql_address_id, connection);
                    cmd.Parameters.AddWithValue("@address", address);
                    addressId = (int)cmd.ExecuteScalar();
                }
                else 
                {
                    var sql_address_id = "SELECT addressId FROM address WHERE address=@address AND address2=@address2;";
                    MySqlCommand cmd = new MySqlCommand(sql_address_id, connection);
                    cmd.Parameters.AddWithValue("@address", address);
                    cmd.Parameters.AddWithValue("@address2", address2);
                    addressId = (int)cmd.ExecuteScalar();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when adding country: " + ex.Message);
                addressId = 0;
            }
            finally
            {
                //connection.Close();
            }

            return addressId;
        }
        public void addAddress(MySqlConnection connection, Patient patient)
        {
            try
            {
                var sql_address = "INSERT IGNORE INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "SELECT @address, @address2, @cityId, @postalCode, @phone, @createDate, @createdBy, @lastUpdate, @lastUpdateBy FROM DUAL WHERE NOT EXISTS " +
                    "(SELECT * FROM address WHERE address=@address AND address2=@address2); ";
                MySqlCommand cmd = new MySqlCommand(sql_address, connection);
                cmd.Parameters.AddWithValue("@address", patient.address);
                if (string.IsNullOrEmpty(patient.address2))
                {
                    cmd.Parameters.AddWithValue("@address2", (object)(DBNull.Value));
                }
                else
                {
                    cmd.Parameters.AddWithValue("@address2", patient.address2);
                }
                //cmd.Parameters.AddWithValue("@address2", customer.address2);
                cmd.Parameters.AddWithValue("@cityId", patient.cityId);
                cmd.Parameters.AddWithValue("@postalCode", patient.postalCode);
                cmd.Parameters.AddWithValue("@phone", patient.phone);
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
