using MySqlX.XDevAPI.Common;
using Org.BouncyCastle.Asn1.X500;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XBYNUM_C969_Application_Development.Controller;

namespace XBYNUM_C969_Application_Development
{
    public partial class UpdateAppointmentView : Form
    {
        public static string appointmentId;
        DataTable appointmentsTable = new DataTable("All Appointments");
        private DataSet dSet;
        public UpdateAppointmentView()
        {
            InitializeComponent();
            CreateAppointmentsTable();
            var customers = AppointmentController.getPatients();
            foreach (string customer in customers) { InviteeComboBox.Items.Add(customer); };
            YourTimeZoneTexBox.Text = TimeZone.CurrentTimeZone.StandardName;
            loadAppointmentData(appointmentId);
        }

        public void loadAppointmentData(string appointmentId)
        {
            AppointmentController controller = new AppointmentController();
            controller.appointmentId = Int32.Parse(appointmentId);
            List<string> data = AppointmentController.GetAppointmentDataToUpdate(controller.appointmentId);
            TitleUpdateAppointmentTextBox.Text = data[2];
            DescriptionUpdateAppointmentTextBox.Text = data[3];
            InviteeComboBox.SelectedIndex = InviteeComboBox.FindStringExact(data[1]);
            locationTextBox.Text = data[4];
            ContactTextBox.Text = data[5];
            TypeTextBox.Text = data[6];
            URLTextBox.Text = data[7];
            Console.WriteLine(data[8]);
            dateTimePicker1.Value = DateTime.ParseExact(data[8], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            startTimePicker.Value = DateTime.ParseExact(data[8], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
            endTimePicker.Value = DateTime.ParseExact(data[9], "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture);
        }

        private void GoBackUpdateCustomerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new AppointmentsView();
            Menu.Show();
        }

        private void ConfirmUpdateAppointmentButton_Click(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();
            AppointmentController ac = new AppointmentController();
            ac.deleteAppointment(Int32.Parse(appointmentId));
            bool incompleteInfo;
            Console.WriteLine(InviteeComboBox.ValueMember);
            if (String.IsNullOrEmpty(TitleUpdateAppointmentTextBox.Text) ||
                String.IsNullOrEmpty(DescriptionUpdateAppointmentTextBox.Text) ||
                Int32.Parse(InviteeComboBox.SelectedIndex.ToString()) == -1 ||
                String.IsNullOrEmpty(locationTextBox.Text) ||
                String.IsNullOrEmpty(ContactTextBox.Text) ||
                String.IsNullOrEmpty(TypeTextBox.Text) ||
                String.IsNullOrEmpty(URLTextBox.Text))
            {
                incompleteInfo = true;
                MessageBox.Show("Text boxes cannot be empty. Please ensure all boxes contain information.");
            }
            else
            {
                incompleteInfo = false;
            }

            var appointmentStartTime = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + startTimePicker.Value.TimeOfDay;
            var appointmentEndTime = dateTimePicker1.Value.ToString("yyyy-MM-dd") + " " + endTimePicker.Value.TimeOfDay;

            Console.WriteLine(AppointmentController.overlappingAppointmentChecker(DateTime.Parse(appointmentStartTime), DateTime.Parse(appointmentEndTime)));

            if (!incompleteInfo)
            {
                if (AppointmentController.businessHourChecker(startTimePicker.Value, endTimePicker.Value, dateTimePicker1.Value))
                {
                    if (AppointmentController.appointmentTimeChecker(startTimePicker.Value, endTimePicker.Value) && DateTime.Parse(startTimePicker.Text) != DateTime.Parse(endTimePicker.Text))
                    {
                        if (!AppointmentController.overlappingAppointmentChecker(DateTime.Parse(appointmentStartTime), DateTime.Parse(appointmentEndTime)))
                        {
                            appointment.title = TitleUpdateAppointmentTextBox.Text;
                            appointment.description = DescriptionUpdateAppointmentTextBox.Text;
                            appointment.patientName = InviteeComboBox.Text;
                            appointment.patientId = AppointmentController.getCustomerId(appointment.patientName);
                            appointment.location = locationTextBox.Text;
                            appointment.contact = ContactTextBox.Text;
                            appointment.type = TypeTextBox.Text;
                            appointment.url = URLTextBox.Text;
                            appointment.start = DateTime.Parse(appointmentStartTime);
                            appointment.end = DateTime.Parse(appointmentEndTime);
                            AppointmentController.updateAppointment(appointment);

                            this.Hide();
                            var Menu = new AppointmentsView();
                            Menu.Show();
                        }
                        else
                        {
                            MessageBox.Show("Overlapping appointment detected! Please correct this.");
                        }

                    }
                    else
                    {
                        MessageBox.Show("Appointment start time cannot be after the appoinment end time, nor can they be the same time!");
                    }

                }
                else
                {
                    MessageBox.Show("Appointment times are outside of business hours! \n" +
                        "Please schedule meetings from 9:00 AM EST - 5:00 PM EST, Monday - Friday.");
                }

            }

        }
        private void CreateAppointmentsTable()
        {
            DataColumn appointmentsDataColumn;

            // Create Customer Name column

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Patient Name";
            appointmentsDataColumn.Caption = "Patient Name";
            appointmentsDataColumn.ReadOnly = true;
            //appointmentsDataColumn.Unique = true;
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Title column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Title";
            appointmentsDataColumn.Caption = "Title";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Start column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Start";
            appointmentsDataColumn.Caption = "Start";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create END column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "End";
            appointmentsDataColumn.Caption = "End";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Make Appointment ID column the primary key column.

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = appointmentsTable.Columns["Appointment ID"];
            appointmentsTable.PrimaryKey = PrimaryKeyColumns;

            // Add Appointment Table to DataSet
            // Create a new DataSet

            dSet = new DataSet();
            dSet.Tables.Add(appointmentsTable);

            // Add data to table using NewRow in Appointment Controller method

            AppointmentController.AddAppointmentsToAddView(appointmentsTable);
            // Bind data to DataGridView.DataSource
            updateAppointmentDataGridView1.DataSource = dSet.Tables["All Appointments"];
        }
    }
}

