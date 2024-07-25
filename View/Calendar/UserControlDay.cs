using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using MySql.Data.MySqlClient;
using MySql.Data.Types;
using XBYNUM_C969_Application_Development.Controller;
using XBYNUM_C969_Application_Development.View.Calendar;

namespace XBYNUM_C969_Application_Development
{
    public partial class UserControlDay : UserControl
    {
        public static MySqlConnection connection = UserController.StartConnection();
        public static string selectedDay;
        public UserControlDay()
        {
            InitializeComponent();
        }

        public void days(int dayNumber) 
        {
            dayCountLabel.Text = dayNumber + "";
        }

        private void UserControlDay_Click(object sender, EventArgs e)
        {
            selectedDay = dayCountLabel.Text;
            DisplayEvents displayEvents = new DisplayEvents();
            displayEvents.Show();
            //displayEvent();
        }

        // Show events
        public static bool displayEvent(DataTable table) 
        {   
            connection.Open();
            bool DST = false;

            DateTime date = new DateTime(CalendarView.static_year, CalendarView.static_month, Int32.Parse(selectedDay));
            string sql_get_events = "SELECT appointmentId, customer.customerName, title, description, location, contact, type, url, start, end FROM appointment " +
                "LEFT JOIN customer ON customer.customerId = appointment.customerId " +
                "WHERE start LIKE @date";
            MySqlCommand cmd = new MySqlCommand(sql_get_events, connection);
            cmd.Parameters.AddWithValue("@date", date.ToString("yyyy-MM-dd") + "%");
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
               Console.WriteLine(rdr.GetString(0));
                DataRow row = table.NewRow();
                row["Appointment ID"] = rdr.GetString(0);
                row["Customer Name"] = rdr.GetString(1);
                row["Title"] = rdr.GetString(2);
                row["Description"] = rdr.GetString(3);
                row["Location"] = rdr.GetString(4);
                row["Contact"] = rdr.GetString(5);
                row["Type"] = rdr.GetString(6);
                row["URL"] = rdr.GetString(7);
                row["Start"] = DateTime.Parse(rdr.GetString(8)).ToLocalTime();
                row["End"] = DateTime.Parse(rdr.GetString(9)).ToLocalTime();
                
                table.Rows.Add(row);
                if (TimeZone.CurrentTimeZone.StandardName == "Coordinated Universal Time")
                {
                    DST = DateTime.Parse(rdr.GetString(8)).ToUniversalTime().IsDaylightSavingTime();
                }
                else
                {
                    DST = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Parse(rdr.GetString(8)), TimeZone.CurrentTimeZone.StandardName).IsDaylightSavingTime();
                }
                
            }
            rdr.Close();    
             connection.Close();

            return DST;
        }


    }
}
