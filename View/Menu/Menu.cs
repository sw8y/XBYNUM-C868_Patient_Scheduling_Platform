using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XBYNUM_C969_Application_Development
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void customerGoButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new CustomerRecordsView();
            Menu.Show();
        }

        private void appointmentGoButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new AppointmentsView();
            Menu.Show();
        }

        private void calendarGoButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new CalendarView();
            Menu.Show();
        }

        private void reportGoButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new ReportView();
            Menu.Show();
        }
    }
}
