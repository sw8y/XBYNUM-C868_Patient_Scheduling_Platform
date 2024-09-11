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
    public class PatientController : AddressController
    {
        public static BindingList<Patient> Allpatients = new BindingList<Patient>();
        public static MySqlConnection connection = UserController.StartConnection();


        public void deletePatient(int patientId)
        {
            connection.Open();
            try
            {
                var sql_delete_patient = "DELETE FROM patient WHERE patientId=@patientId;";
                MySqlCommand cmd = new MySqlCommand(sql_delete_patient, connection);
                cmd.Parameters.AddWithValue("@patientId", patientId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when deleting patient record: {patientId}\n" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        public void addPatient(Patient patient)
        {
            User user = new User();
            //patient.setLogDataAdds(UserController.username);
            var dateTimeStamp = DateTime.Now;
            var loggedInUser = UserController.username;
            connection.Open();
            PatientController patientController = new PatientController();

            // add country information into database and get the ID
            patientController.addCountry(connection, patient);
            patient.countryId = patientController.lookupCountryId(connection, patient.country);

            // add city information into database and get the ID
            patientController.addCity(connection, patient);
            patient.cityId = patientController.lookupCityId(connection, patient.city);

            // add address information into database and get the ID
            patientController.addAddress(connection, patient);
            patient.addressId = patientController.lookupAddressId(connection, patient.address, patient.address2);

            // add patient information into database and get the ID
            patientController.addPatient(connection, patient);
            patient.patientId = patientController.lookupPatientId(connection, patient.patientName);

            connection.Close();

        }

        public void editPatient(Patient patient)
        {
            User user = new User();
            //patient.setLogDataAdds(UserController.username);
            var dateTimeStamp = DateTime.Now;
            var loggedInUser = UserController.username;
            connection.Open();
            PatientController patientController = new PatientController();

            // add country information into database and get the ID
            patientController.addCountry(connection, patient);
            patient.countryId = patientController.lookupCountryId(connection, patient.country);
            //Console.WriteLine($"{patient.countryId}");

            // add city information into database and get the ID
            patientController.addCity(connection, patient);
            patient.cityId = patientController.lookupCityId(connection, patient.city);
            //Console.WriteLine($"City ID is: {patient.cityId}");

            // add address information into database and get the ID
            patientController.addAddress(connection, patient);
            patient.addressId = patientController.lookupAddressId(connection, patient.address, patient.address2);
            //Console.WriteLine($"Address ID is: {patient.addressId}");

            // add patient information into database and get the ID
            patientController.editPatient(connection, patient);
            //patient.patientId = patientController.lookuppatientId(connection, patient.patientName);
            //Console.WriteLine($"patient ID is: {patient.patientId}");
            connection.Close();

        }

        public int lookupPatientId(MySqlConnection connection, string name)
        {
            //connection.Open();
            int patientId;
            try
            {
                var sql_patient_id = "SELECT patientId FROM patient WHERE patientName=@patientName;";
                MySqlCommand cmd = new MySqlCommand(sql_patient_id, connection);
                cmd.Parameters.AddWithValue("@patientName", name);
                patientId = (int)cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error when adding country: " + ex.Message);
                patientId = 0;
            }
            finally
            {
                //connection.Close();
            }

            return patientId;
        }

        public void addPatient(MySqlConnection connection, Patient patient)
        {
            
            try
            {
                var sql_patient = "INSERT IGNORE INTO patient (patientName, addressId, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                    "SELECT @patientName, @addressId, @active, @createDate, @createdBy, @lastUpdate, @lastUpdateBy FROM DUAL WHERE NOT EXISTS " +
                    "(SELECT * FROM patient WHERE patientName=@patientName); ";
                MySqlCommand cmd = new MySqlCommand(sql_patient, connection);
                cmd.Parameters.AddWithValue("@patientName", patient.patientName);
                cmd.Parameters.AddWithValue("@addressId", patient.addressId);
                cmd.Parameters.AddWithValue("@active", patient.active);
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
        public void editPatient(MySqlConnection connection, Patient patient)
        {
            try
            {
                var sql_patient = "UPDATE patient SET patientName=@patientName, " +
                    "addressId=@addressId, lastUpdate=@lastUpdate, lastUpdateBy=@lastUpdateBy " +
                    "WHERE patientId=@patientId;";
                MySqlCommand cmd = new MySqlCommand(sql_patient, connection);
                cmd.Parameters.AddWithValue("@patientId", patient.patientId);
                cmd.Parameters.AddWithValue("@patientName", patient.patientName);
                cmd.Parameters.AddWithValue("@addressId", patient.addressId);
                cmd.Parameters.AddWithValue("@active", patient.active);
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

        public static void AddPatientsFromDatabaseToDataGrid(DataTable table)
        {
            connection.Open();
            try
            {
                string query = ($"SELECT patientId, patientName, address, address2, city, country, postalCode, phone FROM patient " +
                    $"LEFT JOIN address ON patient.addressId = address.addressId " +
                    $"LEFT JOIN city ON address.cityId = city.cityId " +
                    $"LEFT JOIN country ON city.countryId = country.countryId;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DataRow row = table.NewRow();
                    row["Patient ID"] = rdr.GetString(0);
                    row["Patient Name"] = rdr.GetString(1);
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

        public static List<string> GetPatientDataToUpdate(int patientId)
        {
            List<string> result = new List<string>();
            connection.Open();
            try
            {
                string query = ($"SELECT patientId, patientName, address, address2, city, country, postalCode, phone FROM patient " +
                    $"LEFT JOIN address ON patient.addressId = address.addressId " +
                    $"LEFT JOIN city ON address.cityId = city.cityId " +
                    $"LEFT JOIN country ON city.countryId = country.countryId " +
                    $"WHERE patientId=@patientId;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@patientId", patientId);
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

        public bool validateUniquePatient(string name)
        {
            bool Unique = true;
            connection.Open();
            try
            {
                var sql_patient = "SELECT EXISTS (SELECT * FROM patient WHERE patientName=@patientName);";
                MySqlCommand cmd = new MySqlCommand(sql_patient, connection);
                cmd.Parameters.AddWithValue("@patientName", name);
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
