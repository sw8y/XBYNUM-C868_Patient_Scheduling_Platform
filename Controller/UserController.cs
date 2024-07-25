using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Device.Location;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using XBYNUM_C969_Application_Development.Model;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X500;
using System.Reflection.Emit;
using System.Text;
using System.Security.Cryptography;

namespace XBYNUM_C969_Application_Development.Controller
{
    public class UserController : User
    {

        public static MySqlConnection StartConnection() 
        {
            string connectionString = null;
            connectionString = ($"server=localhost;database=client_schedule;uid=sqlUser;pwd=\"Passw0rd!\";");
            MySqlConnection conn = new MySqlConnection(connectionString);
            return conn;
        }
        public static bool AuthenticateUser(string user, string password) 
        {
            MySqlConnection cnn = StartConnection();
            bool verification = false;
            cnn.Open();
            try
            {
                string query = ($"SELECT userName, IF(userName=\"{user}\" && password=\"{password}\", true, false) FROM user;");
                MySqlCommand cmd = new MySqlCommand(query, cnn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    if (rdr[1].ToString() == "1") 
                    {
                        verification = true;
                        UserController.userId = 1;
                    }
                    else 
                    {
                        verification = false;
                    }
                }
                rdr.Close();
            }

            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection!");
                Console.WriteLine(ex.ToString());
            }
            cnn.Close();
            return verification;
        }

        public static void LogAccess() 
        {
            string path = Directory.GetCurrentDirectory() + "\\Login_History.txt";
            

            if (!File.Exists(path)) 
            {
                // Create the file if it does not exist.
                if (!File.Exists(path))
                {
                    // Create the file.
                    using (FileStream fs = File.Create(path))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes($"{UserController.username} - {DateTime.Now}");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
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
        public static string GetPublicIPAddress() 
        {
            string PublicIP;
            string url = "https://api.ipify.org?format=json";
            var request = System.Net.WebRequest.Create(url);

            using (WebResponse wrs = request.GetResponse())
            {
                using (Stream stream = wrs.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {

                        string json = reader.ReadToEnd();
                        UserLocationData userLocationData = JsonSerializer.Deserialize<UserLocationData>(json);
                        Console.WriteLine($"{userLocationData.ip}");
                        PublicIP = userLocationData.ip;

                    }
                }
            }

            return PublicIP;
        }

        public static string CityStateCountByIp(string IP)
        {
            string State, Country;
            string url = "http://api.ipstack.com/" + IP + "?access_key=a5aa77f9f10166259d079f61276de760";
            var request = System.Net.WebRequest.Create(url);
            
            using (WebResponse wrs = request.GetResponse())
            {
                using (Stream stream = wrs.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        string jsonString = reader.ReadToEnd();
                        UserLocationData userLocationData = JsonSerializer.Deserialize<UserLocationData>(jsonString);
                        State = userLocationData.region_name;
                        Country = userLocationData.country_name;
                    }
                }
            }
            return (State + ", " + Country);

        }

        public static bool appointmentAboutToStart() 
        {

            bool appointmentAboutToStart = false;
            var CurrentDateTime = DateTime.Now;
            //var myCurrentEasternZoneTime = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(CurrentDateTime, "Eastern Standard Time");
            MySqlConnection cnn = StartConnection();
            cnn.Open();

            try
            {
                string query = ("SELECT start FROM appointment;");
                MySqlCommand cmd = new MySqlCommand(query, cnn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
               
                {
                    var diff = DateTime.Parse(rdr.GetString(0)).ToLocalTime().Subtract(CurrentDateTime);
                    /*
                        Console.WriteLine($"My time: {CurrentDateTime} \n" +
                        $"Appointment Start Time {DateTime.Parse(rdr.GetString(0))}\n " +
                        $" Subtraction = {diff}");
                    
                    */
                    if (diff <= TimeSpan.FromMinutes(15) && diff >= TimeSpan.FromMinutes(0))
                    {
                        MessageBox.Show("You have an appointment starting in less than 15 minutes!");
                        break;
                    }
                }
                rdr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            cnn.Close();
            return appointmentAboutToStart;
        }
        
    }
}
