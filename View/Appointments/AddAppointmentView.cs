using System;
using System.Globalization;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XBYNUM_C969_Application_Development.Controller;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace XBYNUM_C969_Application_Development
{
    public partial class AddAppointmentView : Form
    {
        DataTable appointmentsTable = new DataTable("All Appointments");
        private DataSet dSet;
        public AddAppointmentView()
        {
            InitializeComponent();
            CreateAppointmentsTable();
            var patients = AppointmentController.getPatients();
            foreach (string patient in patients) { InviteeComboBox.Items.Add(patient); };
            YourTimeZoneTexBox.Text = TimeZone.CurrentTimeZone.StandardName;
        }

        private void ConfirmAddAppointmentButton_Click(object sender, EventArgs e)
        {
            Appointment appointment = new Appointment();
            bool incompleteInfo;
            if (String.IsNullOrEmpty(TitleAddAppointmentTextBox.Text) ||
                String.IsNullOrEmpty(DescriptionAddAppointmentTextBox.Text) ||
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
                            appointment.title = TitleAddAppointmentTextBox.Text.Trim();
                            appointment.description = DescriptionAddAppointmentTextBox.Text.Trim();
                            appointment.patientName = InviteeComboBox.Text.Trim();
                            appointment.patientId = AppointmentController.getCustomerId(appointment.patientName);
                            appointment.location = locationTextBox.Text.Trim();
                            appointment.contact = ContactTextBox.Text.Trim();
                            appointment.type = TypeTextBox.Text.Trim();
                            appointment.url = URLTextBox.Text.Trim();
                            appointment.start = DateTime.Parse(appointmentStartTime);
                            appointment.end = DateTime.Parse(appointmentEndTime);
                            AppointmentController.addAppointment(appointment);

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

        private void GoBackAddPatientButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new AppointmentsView();
            Menu.Show();
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
            addAppointmentDataGridView1.DataSource = dSet.Tables["All Appointments"];
        }
    }
}
