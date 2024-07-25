using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XBYNUM_C969_Application_Development.Controller;

namespace XBYNUM_C969_Application_Development
{
    public partial class ReportView : Form
    {
        public ReportView()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ReportController reporter = new ReportController();
            ReportController.GenerateCustomerCountReport("Customer_Count", reporter.customersPerCity());
            MessageBox.Show($"The report can be found within the following folder:\n {Directory.GetCurrentDirectory()}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportController reporter = new ReportController();
            ReportController.GenerateAppointmentTypeReport("Appointment_Type_Per_Month", reporter.appointmentTypePerMonth());
            MessageBox.Show($"The report can be found within the following folder:\n {Directory.GetCurrentDirectory()}");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportController reporter = new ReportController();
            ReportController.GenerateAllUserSchedulesReport("All_User_Schedules", reporter.allUserSchedules());
            MessageBox.Show($"The report can be found within the following folder:\n {Directory.GetCurrentDirectory()}");
        }

        private void menuButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new Menu();
            Menu.Show(this);
        }
    }
}
