using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using XBYNUM_C969_Application_Development.Model;
//using XBYNUM_C969_Application_Development.Model;
//using XBYNUM_C969_Application_Development.Controller;

namespace XBYNUM_C969_Application_Development.Controller
{
    public class ReportController
    {
        // Collection classes for holding report data
        public static MySqlConnection connection = UserController.StartConnection();
        public delegate IList<dynamic> getReportData();



        // First button - Get number of appointment types by month

        public getReportData appointmentTypePerMonth = () =>
        {
            IList<dynamic> appointmentTypePerMonth = new List<dynamic>();
            connection.Open();
            try
            {
                string query = ("SELECT DISTINCT MONTHNAME(start) as 'Month', type as 'Meeting Type', count(type) AS 'Count' FROM appointment " +
                "GROUP BY MONTHNAME(start), type;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    appointmentTypePerMonth.Add(rdr.GetString(0) + ":" + rdr.GetString(1) + ":" + rdr.GetString(2));
                    //customerCountPerCity.Add(new KeyValuePair<dynamic, dynamic>(rdr.GetString(0), Int32.Parse(rdr.GetString(1))));
                }
                rdr.Close();
            }
            catch { }
            connection.Close();
            return appointmentTypePerMonth;
        };

        // Second button - Get schedule for each user
        public getReportData allUserSchedules = () =>
        {
            IList<dynamic> allUserSchedules = new List<dynamic>();
            connection.Open();
            try
            {
                string query = ("SELECT customer.customerName, user.userName, title, start, end FROM appointment " +
                "LEFT JOIN customer ON appointment.customerId = customer.customerId " +
                "LEFT JOIN user ON appointment.userId = user.userId " +
                "ORDER BY user.UserName, start ASC;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    var schedule = rdr.GetString(0) + ";" + rdr.GetString(1) + ";" + rdr.GetString(2) + ";" + rdr.GetString(3) + ";" + rdr.GetString(4);
                    allUserSchedules.Add(schedule);
                    //customerCountPerCity.Add(new KeyValuePair<dynamic, dynamic>(rdr.GetString(0), Int32.Parse(rdr.GetString(1))));
                }
                rdr.Close();
            }
            catch { }
            connection.Close();
            return allUserSchedules;
        };

        // Third button - Get count of customers per city
        public getReportData customersPerCity = () =>
        {
            IList<dynamic> customerCountPerCity = new List<dynamic>();
            connection.Open();
            try
            {
                string query = (" select city.city, COUNT(customerName) FROM customer " +
                "LEFT JOIN address ON customer.addressId = address.addressId " +
                "LEFT JOIN city ON address.cityId = city.cityId GROUP BY city;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    customerCountPerCity.Add(rdr.GetString(0) + ":" + rdr.GetString(1));
                    //customerCountPerCity.Add(new KeyValuePair<dynamic, dynamic>(rdr.GetString(0), Int32.Parse(rdr.GetString(1))));
                }
                rdr.Close();
            }
            catch { }
            connection.Close();
            return customerCountPerCity;
        };

        // Appointment type per month report maker
        public static void GenerateAppointmentTypeReport(string generator, IList<dynamic> reportData)
        {
            string path = Directory.GetCurrentDirectory() + $"\\{generator}_Report-" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".txt";


            if (!File.Exists(path))
            {
                // Create the file if it does not exist.
                if (!File.Exists(path))
                {
                    // Create the file.
                    using (FileStream fs = File.Create(path))
                    {
                        foreach (dynamic value in reportData)
                        {
                            byte[] info = new UTF8Encoding(true).GetBytes($"Month: {value.Split(':')[0]}, Appoinment Type: {value.Split(':')[1]}, Appointment Count: {value.Split(':')[2]}\n");
                            // Add some information to the file.
                            fs.Write(info, 0, info.Length);
                            //Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                        }

                    }
                }
            }
            else
            {
                try
                {
                    // Create the file, or overwrite if the file exists.
                    //using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
                    using (StreamWriter sw = File.AppendText(path))
                    {

                        // Add some information to the file.
                        sw.WriteLine($"\n{UserController.username} - {DateTime.Now}");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        // All user schedules report maker
        public static void GenerateAllUserSchedulesReport(string generator, IList<dynamic> reportData)
        {
            string path = Directory.GetCurrentDirectory() + $"\\{generator}_Report-" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".txt";


            if (!File.Exists(path))
            {
                // Create the file if it does not exist.
                if (!File.Exists(path))
                {
                    // Create the file.
                    using (FileStream fs = File.Create(path))
                    {
                        foreach (dynamic value in reportData)
                        {
                            byte[] info = new UTF8Encoding(true).GetBytes($"Customer: {value.Split(';')[0]}, User: {value.Split(';')[1]}, Meeting Title: {value.Split(';')[2]}, Start Date & Time: {value.Split(';')[3]}, End Date & Time: {value.Split(';')[4]}\n");
                            // Add some information to the file.
                            fs.Write(info, 0, info.Length);
                            //Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                        }

                    }
                }
            }
            else
            {
                try
                {
                    // Create the file, or overwrite if the file exists.
                    //using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
                    using (StreamWriter sw = File.AppendText(path))
                    {

                        // Add some information to the file.
                        sw.WriteLine($"\n{UserController.username} - {DateTime.Now}");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        // Customer count report maker
        public static void GenerateCustomerCountReport(string generator, IList<dynamic> reportData)
        {
            string path = Directory.GetCurrentDirectory() + $"\\{generator}_Report-" + DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss") + ".txt";


            if (!File.Exists(path))
            {
                // Create the file if it does not exist.
                if (!File.Exists(path))
                {
                    // Create the file.
                    using (FileStream fs = File.Create(path))
                    {
                        foreach (dynamic value in reportData)
                        {
                            byte[] info = new UTF8Encoding(true).GetBytes($"City: {value.Split(':')[0]}, Customer Count = {value.Split(':')[1]}\n");
                            // Add some information to the file.
                            fs.Write(info, 0, info.Length);
                            //Console.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
                        }

                    }
                }
            }
            else
            {
                try
                {
                    // Create the file, or overwrite if the file exists.
                    //using (FileStream fs = File.Open(path, FileMode.Open, FileAccess.Write, FileShare.None))
                    using (StreamWriter sw = File.AppendText(path))
                    {

                        // Add some information to the file.
                        sw.WriteLine($"\n{UserController.username} - {DateTime.Now}");
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
