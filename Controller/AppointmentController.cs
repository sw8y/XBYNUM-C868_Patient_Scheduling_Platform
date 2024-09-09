using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using XBYNUM_C969_Application_Development.Model;
using Google.Protobuf.WellKnownTypes;
using Org.BouncyCastle.Utilities.Collections;

namespace XBYNUM_C969_Application_Development.Controller
{
    public class AppointmentController : Appointment
    {
        public static MySqlConnection connection = UserController.StartConnection();

        public static List<string> getPatients()
        {
            List<string> patients = new List<string>();
            connection.Open();

            try
            {
                string query = ("SELECT patientName FROM patient;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    patients.Add(rdr.GetString(0));
                }
                rdr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
            return patients;
        }
        public static int getPatientId(string patientName) 
        {
            connection.Open();
            int patientId = 0;

            try
            {
                string query = ("SELECT patientId FROM patient WHERE patientsName=@patientsName;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@patientName", patientName);
                patientId = (int)cmd.ExecuteScalar();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
            return patientId; 
        }

        public static void addAppointment(Appointment appointment) 
        {
            connection.Open();
            try
            {
                string add_appointments = ("INSERT INTO appointment(patientId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@patientId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);");
                MySqlCommand cmd = new MySqlCommand(add_appointments, connection);
                cmd.Parameters.AddWithValue("@patientId", appointment.patientId);
                cmd.Parameters.AddWithValue("@userId", UserController.userId);
                cmd.Parameters.AddWithValue("@title", appointment.title);
                cmd.Parameters.AddWithValue("@description", appointment.description);
                cmd.Parameters.AddWithValue("@location", appointment.location);
                cmd.Parameters.AddWithValue("@contact", appointment.contact);
                cmd.Parameters.AddWithValue("@type", appointment.type);
                cmd.Parameters.AddWithValue("@url", appointment.url);
                cmd.Parameters.AddWithValue("@start", appointment.start.ToUniversalTime());
                cmd.Parameters.AddWithValue("@end", appointment.end.ToUniversalTime());
                cmd.Parameters.AddWithValue("@createDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@createdBy", UserController.username);
                cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@lastUpdateBy", UserController.username);
                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
        }

        public static void updateAppointment(Appointment appointment) 
        {
            connection.Open();

            try
            {
                string update_appointments = ("INSERT INTO appointment(patientId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                "VALUES (@patientId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, @createDate, @createdBy, @lastUpdate, @lastUpdateBy);");
                MySqlCommand cmd = new MySqlCommand(update_appointments, connection);
                //cmd.Parameters.AddWithValue("@appointmentId", appointment.appointmentId);
                cmd.Parameters.AddWithValue("@patientId", appointment.patientId);
                cmd.Parameters.AddWithValue("@userId", UserController.userId);
                cmd.Parameters.AddWithValue("@title", appointment.title);
                cmd.Parameters.AddWithValue("@description", appointment.description);
                cmd.Parameters.AddWithValue("@location", appointment.location);
                cmd.Parameters.AddWithValue("@contact", appointment.contact);
                cmd.Parameters.AddWithValue("@type", appointment.type);
                cmd.Parameters.AddWithValue("@url", appointment.url);
                cmd.Parameters.AddWithValue("@start", appointment.start.ToUniversalTime());
                cmd.Parameters.AddWithValue("@end", appointment.end.ToUniversalTime());
                cmd.Parameters.AddWithValue("@createDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@createdBy", UserController.username);
                cmd.Parameters.AddWithValue("@lastUpdate", DateTime.Now);
                cmd.Parameters.AddWithValue("@lastUpdateBy", UserController.username);
                cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
        }
        public static bool businessHourChecker(DateTime meetingStartTime, DateTime meetingEndTime, DateTime meetingDate) 
        {

            bool withinBusinessHours = false;

            DateTime startOfDay = new DateTime().AddHours(9);
            DateTime endOfDay = new DateTime().AddHours(17);
            
            var mstEasternZone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(meetingStartTime, "Eastern Standard Time");
            var metEasternZone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(meetingEndTime, "Eastern Standard Time");


            if (mstEasternZone.TimeOfDay >= startOfDay.TimeOfDay && metEasternZone.TimeOfDay <= endOfDay.TimeOfDay)
            {
                if (meetingDate.DayOfWeek == DayOfWeek.Sunday || meetingDate.DayOfWeek == DayOfWeek.Saturday) 
                {
                    withinBusinessHours = false;
                }
                else 
                {
                    withinBusinessHours = true;
                }
                     
            }
            else
            {
                withinBusinessHours = false;
            };
            return withinBusinessHours;
        }

        public static bool appointmentTimeChecker(DateTime meetingStartTime, DateTime meetingEndTime)
        {

            bool appointmentTimeChecker = false;


            var mstEasternZone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(meetingStartTime, "Eastern Standard Time");
            var metEasternZone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(meetingEndTime, "Eastern Standard Time");

            // If meeting start time is BEFORE the meeting end time
            if (meetingStartTime.TimeOfDay < meetingEndTime.TimeOfDay)
            {
                appointmentTimeChecker = true;
                Console.WriteLine("testing");
            }
            else
            {
                appointmentTimeChecker = false;
            };
            return appointmentTimeChecker;
        }

        public static bool overlappingAppointmentChecker(DateTime meetingStartTime, DateTime meetingEndTime)
        {
            connection.Open();
            bool overlappingAppointment = false;

            Console.WriteLine(meetingStartTime);
            var mstEasternZone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(meetingStartTime, "Eastern Standard Time");
            var metEasternZone = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(meetingEndTime, "Eastern Standard Time");
            
            try
            {
                string query = ("SELECT start, end FROM appointment;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read() && !overlappingAppointment)
                {
                    DateTime tempStartTime = DateTime.Parse(rdr.GetString(0));
                    DateTime convertedStartTime = tempStartTime.ToLocalTime();

                    DateTime tempEndTime = DateTime.Parse(rdr.GetString(1));
                    DateTime convertedEndTime = tempEndTime.ToLocalTime();

                    int beforeResultA = DateTime.Compare(convertedStartTime, meetingEndTime.ToLocalTime());
                    int afterResultB = DateTime.Compare(convertedEndTime, meetingStartTime.ToLocalTime());
           
                  
                    //Console.WriteLine(endResultB);

                    if (beforeResultA <= 1 && afterResultB >= 1)
                    {
                        overlappingAppointment = true;
                    }
                    else
                    { overlappingAppointment = false; }
   
                }
                rdr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
            return overlappingAppointment;
        }
        public static void AddAppointmentsToAppointmentView(DataTable table)
        {
            connection.Open();
            try
            {
                string query = ("SELECT appointmentId, patient.patientName, title, description, location, contact, type, url, start, end FROM appointment LEFT JOIN patient ON patient.patientId = appointment.patientId;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DataRow row = table.NewRow();
                    row["Appointment ID"] = rdr.GetString(0);
                    row["Patient Name"] = rdr.GetString(1);
                    row["Title"] = rdr.GetString(2);
                    row["Description"] = rdr.GetString(3);
                    row["Location"] = rdr.GetString(4);
                    row["Contact"] = rdr.GetString(5);
                    row["Type"] = rdr.GetString(6);
                    row["URL"] = rdr.GetString(7);
                    row["Start"] = DateTime.Parse(rdr.GetString(8)).ToLocalTime().ToString();
                    row["End"] = DateTime.Parse(rdr.GetString(9)).ToLocalTime().ToString();

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

        public static void AddAppointmentsToAddView(DataTable table)
        {
            connection.Open();
            try
            {
                string query = ("SELECT patient.patientName, title, start, end FROM appointment LEFT JOIN patient ON appointment.patientId = patient.patientId;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DataRow row = table.NewRow();
                    row["Patient Name"] = rdr.GetString(0);
                    row["Title"] = rdr.GetString(1);
                    row["Start"] = DateTime.Parse(rdr.GetString(2)).ToLocalTime().ToString();
                    row["End"] = DateTime.Parse(rdr.GetString(3)).ToLocalTime().ToString();

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

        public void deleteAppointment(int appointmentId)
        {
            connection.Open();
            try
            {
                var sql_delete_appointment = "DELETE FROM appointment WHERE appointmentId=@appointmentId;";
                MySqlCommand cmd = new MySqlCommand(sql_delete_appointment, connection);
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error when deleting appointment record: {appointmentId}\n" + ex.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public static List<string> GetAppointmentDataToUpdate(int appointmentId)
        {
            List<string> result = new List<string>();
            connection.Open();
            try
            {
                string query = ($"SELECT appointmentId, patient.patientName, title, description, location, contact, type, url, start, end FROM appointment " +
                     $"LEFT JOIN patient ON appointment.patientId = patient.patientId " +
                     $"WHERE appointmentId=@appointmentId;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@appointmentId", appointmentId);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    result.Add(rdr.GetString(0)); // appointmentId
                    result.Add(rdr.GetString(1)); // customerName
                    result.Add(rdr.GetString(2)); // title
                    result.Add(rdr.GetString(3)); // description
                    result.Add(rdr.GetString(4)); // location
                    result.Add(rdr.GetString(5)); // contact
                    result.Add(rdr.GetString(6)); // type
                    result.Add(rdr.GetString(7)); // url
                    //result.Add(rdr.GetString(8)) // start
                    result.Add(DateTime.Parse(rdr.GetString(8)).ToLocalTime().ToString());
                    result.Add(DateTime.Parse(rdr.GetString(9)).ToLocalTime().ToString());
                    //result.Add(rdr.GetString(9)); // end

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
    }
}
