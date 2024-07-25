using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XBYNUM_C969_Application_Development
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginPageView());
            //Application.Run(new CalendarView());
            //Application.Run(new ReportView());
            //Application.Run(new Menu());
            //Application.Run(new AppointmentsView());
            Application.Run(new PatientRecordsView());
            //Application.Run(new Form1());
            //Application.Run(new AddCustomerRecordView());
        }
    }
}
