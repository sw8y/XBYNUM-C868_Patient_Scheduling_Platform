using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using System.Threading.Tasks;
using XBYNUM_C969_Application_Development.Model;
using XBYNUM_C969_Application_Development.Controller;
using System.ComponentModel;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System.Data;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using static System.Data.Entity.Infrastructure.Design.Executor;
using System.Xml.Linq;

namespace XBYNUM_C969_Application_Development.Controller
{
    public class CustomerController : AddressController
    {
        public static BindingList<Customer> AllCustomers = new BindingList<Customer>();
        public static MySqlConnection connection = UserController.StartConnection();


        public void deleteCustomer(int customerId)
        {
            connection.Open();
            try
            {
                var sql_delete_customer = "DELETE FROM customer WHERE customerId=@customerId;";
                MySqlCommand cmd = new MySqlCommand(sql_delete_customer, connection);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when deleting customer record: {customerId}\n" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void addNewCustomer(Customer customer)
        {
            User user = new User();
            //customer.setLogDataAdds(UserController.username);
            var dateTimeStamp = DateTime.Now;
            var loggedInUser = UserController.username;
            connection.Open();
            CustomerController customerController = new CustomerController();

            // add country information into database and get the ID
            customerController.addCountry(connection, customer);
            customer.countryId = customerController.lookupCountryId(connection, customer.country);

            // add city information into database and get the ID
            customerController.addCity(connection, customer);
            customer.cityId = customerController.lookupCityId(connection, customer.city);

            // add address information into database and get the ID
            customerController.addAddress(connection, customer);
            customer.addressId = customerController.lookupAddressId(connection, customer.address, customer.address2);

            // add customer information into database and get the ID
            customerController.addCustomer(connection, customer);
            customer.customerId = customerController.lookupCustomerId(connection, customer.customerName);

            connection.Close();

        }

        public void editExistingCustomer(Customer customer)
        {
            User user = new User();
            //customer.setLogDataAdds(UserController.username);
            var dateTimeStamp = DateTime.Now;
            var loggedInUser = UserController.username;
            connection.Open();
            CustomerController customerController = new CustomerController();

            // add country information into database and get the ID
            customerController.addCountry(connection, customer);
            customer.countryId = customerController.lookupCountryId(connection, customer.country);
            //Console.WriteLine($"{customer.countryId}");

            // add city information into database and get the ID
            customerController.addCity(connection, customer);
            customer.cityId = customerController.lookupCityId(connection, customer.city);
            //Console.WriteLine($"City ID is: {customer.cityId}");

            // add address information into database and get the ID
            customerController.addAddress(connection, customer);
            customer.addressId = customerController.lookupAddressId(connection, customer.address, customer.address2);
            //Console.WriteLine($"Address ID is: {customer.addressId}");

            // add customer information into database and get the ID
            customerController.editCustomer(connection, customer);
            //customer.customerId = customerController.lookupCustomerId(connection, customer.customerName);
            //Console.WriteLine($"Customer ID is: {customer.customerId}");
            connection.Close();

        }

        public int lookupCustomerId(MySqlConnection connection, string name)
        {
            //connection.Open();
            int customerId;
            try
            {
                var sql_customer_id = "SELECT customerId FROM customer WHERE customerName=@customerName;";
                MySqlCommand cmd = new MySqlCommand(sql_customer_id, connection);
                cmd.Parameters.AddWithValue("@customerName", name);
                customerId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when adding country: " + ex.Message);
                customerId = 0;
            }
            finally
            {
                //connection.Close();
            }

            return customerId;
        }

        public void addCustomer(MySqlConnection connection, Customer customer)
        {
            
            try
            {
                var sql_customer = "INSERT IGNORE INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "SELECT @customerName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy FROM DUAL WHERE NOT EXISTS " +
                    "(SELECT * FROM customer WHERE customerName=@customerName); ";
                MySqlCommand cmd = new MySqlCommand(sql_customer, connection);
                cmd.Parameters.AddWithValue("@customerName", customer.customerName);
                cmd.Parameters.AddWithValue("@addressId", customer.addressId);
                cmd.Parameters.AddWithValue("@active", customer.active);
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
        public void editCustomer(MySqlConnection connection, Customer customer)
        {
            try
            {
                var sql_customer = "UPDATE customer SET customerName=@customerName, " +
                    "addressId=@addressId, lastUpdate=@lastUpdate, lastUpdateBy=@lastUpdateBy " +
                    "WHERE customerId=@customerId;";
                MySqlCommand cmd = new MySqlCommand(sql_customer, connection);
                cmd.Parameters.AddWithValue("@customerId", customer.customerId);
                cmd.Parameters.AddWithValue("@customerName", customer.customerName);
                cmd.Parameters.AddWithValue("@addressId", customer.addressId);
                cmd.Parameters.AddWithValue("@active", customer.active);
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

        public static void AddCustomersFromDatabaseToDataGrid(DataTable table)
        {
            connection.Open();
            try
            {
                string query = ($"SELECT customerId, customerName, address, address2, city, country, postalCode, phone FROM customer " +
                    $"LEFT JOIN address ON customer.addressId = address.addressId " +
                    $"LEFT JOIN city ON address.cityId = city.cityId " +
                    $"LEFT JOIN country ON city.countryId = country.countryId;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DataRow row = table.NewRow();
                    row["Customer ID"] = rdr.GetString(0);
                    row["Customer Name"] = rdr.GetString(1);
                    row["Address"] = rdr.GetString(2);
                    try
                    {
                        if (string.IsNullOrEmpty(rdr.GetString(3))) { row["Address (2)"] = ""; } else { row["Address (2)"] = rdr.GetString(3); };
                    }
                    catch (Exception SqlNullValueException) { Console.WriteLine($"Null value detected in Address (2). Printing empty table cell. \n{SqlNullValueException}"); }

                    //row["Address (2)"] = rdr.GetString(2);
                    row["City"] = rdr.GetString(4);
                    row["Country"] = rdr.GetString(5);
                    row["Postal Code"] = rdr.GetString(6);
                    row["Phone Number"] = rdr.GetString(7);
                    //Console.WriteLine($"{rdr.GetString(0)}");

                    table.Rows.Add(row);

                }
                rdr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
        }

        public static List<string> GetCustomerDataToUpdate(int customerId)
        {
            List<string> result = new List<string>();
            connection.Open();
            try
            {
                string query = ($"SELECT customerId, customerName, address, address2, city, country, postalCode, phone FROM customer " +
                    $"LEFT JOIN address ON customer.addressId = address.addressId " +
                    $"LEFT JOIN city ON address.cityId = city.cityId " +
                    $"LEFT JOIN country ON city.countryId = country.countryId " +
                    $"WHERE customerId=@customerId;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@customerId", customerId);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Add(rdr.GetString(1));
                    result.Add(rdr.GetString(2));
                    try { result.Add(rdr.GetString(3)); } catch (Exception SqlNullValueException) { result.Add(""); }
                    result.Add(rdr.GetString(4));
                    result.Add(rdr.GetString(5));
                    result.Add(rdr.GetString(6));
                    result.Add(rdr.GetString(7));

                }
                rdr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
            return result;
        }

        public bool validateUniqueCustomer(string name)
        {
            bool Unique = true;
            connection.Open();
            try
            {
                var sql_customer = "SELECT EXISTS (SELECT * FROM customer WHERE customerName=@customerName);";
                MySqlCommand cmd = new MySqlCommand(sql_customer, connection);
                cmd.Parameters.AddWithValue("@customerName", name);
                if (cmd.ExecuteScalar().ToString() == "1")
                {
                    Unique = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
            return Unique;
        }
    }
}
