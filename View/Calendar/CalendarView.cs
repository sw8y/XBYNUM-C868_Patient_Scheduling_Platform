using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using XBYNUM_C969_Application_Development.Controller;
using XBYNUM_C969_Application_Development.Model;

namespace XBYNUM_C969_Application_Development
{
    public partial class CalendarView : Form
    {
        public static MySqlConnection connection = UserController.StartConnection();
        int month, year;
        public static int static_month, static_year;

        public CalendarView()
        {
            InitializeComponent();
            
        }

        private void CalendarView_Load(object sender, EventArgs e)
        {
            showDays();

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void showDays() 
        {
            List<string> appointments = getAppointmentDates();
            DateTime now = DateTime.Now;
            month = now.Month;
            year = now.Year;

            var monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            monthYearLabel.Text = monthName + " " + year.ToString();

            static_month = month;
            static_year = year;

            // beginning of month (day 1)
            DateTime startOfMonth = new DateTime(year, month, 1);
            Console.WriteLine(startOfMonth);

            //get total days of the month
            int days = DateTime.DaysInMonth(year, month);
            Console.WriteLine(days);

            // convert start of month to integer
            int dayOfTheWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d"));
            Console.WriteLine(dayOfTheWeek);

           for(int i = 0 ;i < dayOfTheWeek; i++) 
            {
                UserControlCal cal = new UserControlCal();
                monthContainer.Controls.Add(cal);
            }
           
            //  create user control for days
            for (int i = 1; i <= days; i++) 
            { 
                UserControlDay userControlDay = new UserControlDay();
                userControlDay.days(i);
                foreach (string appointment in appointments) 
                {
                    if (DateTime.Parse(appointment).ToShortDateString() == new DateTime(year, month, i).ToShortDateString()) 
                    {
                        userControlDay.BackColor = System.Drawing.Color.Aqua;
                    }
                }
                monthContainer.Controls.Add(userControlDay);
            }
           
        }

        public List<string> getAppointmentDates() 
        {
            connection.Open();
            List<string> appointments = new List<string>();

            try
            {
                string query = ("SELECT start FROM appointment;");
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    appointments.Add(rdr.GetString(0));
                }
                rdr.Close();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            connection.Close();
            connection.Close();
            return appointments;
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new Menu();
            Menu.Show(this);
        }

        private void calPreviousButton_Click(object sender, EventArgs e)
        {
            monthContainer.Controls.Clear();
            List<string> appointments = getAppointmentDates();
            // decrement month
            if (month == 1)
            {

                year--;
                month = 12;
                static_month = month;
                static_year = year;
            }
            else
            {
                month--;
                static_month = month;
            }

            var monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            monthYearLabel.Text = monthName + " " + year.ToString();

            // beginning of month (day 1)
            DateTime startOfMonth = new DateTime(year
                , month, 1);
            Console.WriteLine(startOfMonth);

            //get total days of the month
            int days = DateTime.DaysInMonth(year, month);
            Console.WriteLine(days);

            // convert start of month to integer
            int dayOfTheWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d"));
            Console.WriteLine(dayOfTheWeek);

            for (int i = 0; i < dayOfTheWeek; i++)
            {
                UserControlCal cal = new UserControlCal();
                monthContainer.Controls.Add(cal);
            }

            //  create user control for days
            for (int i = 1; i <= days; i++)
            {
                UserControlDay userControlDay = new UserControlDay();
                userControlDay.days(i);
                foreach (string appointment in appointments)
                {
                    if (DateTime.Parse(appointment).ToShortDateString() == new DateTime(year, month, i).ToShortDateString())
                    {
                        userControlDay.BackColor = System.Drawing.Color.Aqua;
                    }
                }
                monthContainer.Controls.Add(userControlDay);
            }
        }

        private void calNextButton_Click(object sender, EventArgs e)
        {
            monthContainer.Controls.Clear();
            List<string> appointments = getAppointmentDates();
            // increment month
            if (month == 12) 
            {
                year++;
                month = 1;
                static_month = month;
                static_year = year;
            }
            else 
            {
                month++;
                static_month = month;
            }

            var monthName = DateTimeFormatInfo.CurrentInfo.GetMonthName(month);
            monthYearLabel.Text = monthName + " " + year.ToString();

            // beginning of month (day 1)
            DateTime startOfMonth = new DateTime(year, month, 1);
            Console.WriteLine(startOfMonth);

            //get total days of the month
            int days = DateTime.DaysInMonth(year, month);
            Console.WriteLine(days);

            // convert start of month to integer
            int dayOfTheWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d"));
            Console.WriteLine(dayOfTheWeek);

            for (int i = 0; i < dayOfTheWeek; i++)
            {
                UserControlCal cal = new UserControlCal();
                monthContainer.Controls.Add(cal);
            }

            //  create user control for days
            for (int i = 1; i <= days; i++)
            {
                UserControlDay userControlDay = new UserControlDay();
                userControlDay.days(i);
                foreach (string appointment in appointments)
                {
                    if (DateTime.Parse(appointment).ToShortDateString() == new DateTime(year, month, i).ToShortDateString())
                    {
                        userControlDay.BackColor = System.Drawing.Color.Aqua;
                    }
                }
                monthContainer.Controls.Add(userControlDay);
            }
        }
    }
}
