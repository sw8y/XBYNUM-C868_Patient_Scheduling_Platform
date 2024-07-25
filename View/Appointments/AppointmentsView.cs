using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XBYNUM_C969_Application_Development.Controller;

namespace XBYNUM_C969_Application_Development
{
    public partial class AppointmentsView : Form
    {
        DataTable appointmentsTable = new DataTable("All Appointments");
        private DataSet dSet;
        public AppointmentsView()
        {
            InitializeComponent();
            CreateAppointmentsTable();
        }

        private void CreateAppointmentsTable()
        {
            DataColumn appointmentsDataColumn;

            // Create Appointment ID column

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Appointment ID";
            appointmentsDataColumn.Caption = "Appointment ID";
            appointmentsDataColumn.ReadOnly = true;
            //appointmentsDataColumn.Unique = true;
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Customer Name column

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Customer Name";
            appointmentsDataColumn.Caption = "Customer Name";
            appointmentsDataColumn.ReadOnly = true;
            //appointmentsDataColumn.Unique = true;
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Title column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Title";
            appointmentsDataColumn.Caption = "Title";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Description column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Description";
            appointmentsDataColumn.Caption = "description";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Location column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Location";
            appointmentsDataColumn.Caption = "Location";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Contact column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Contact";
            appointmentsDataColumn.Caption = "Contact";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Type column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Type";
            appointmentsDataColumn.Caption = "Type";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create URL column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "URL";
            appointmentsDataColumn.Caption = "URL";
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

            AppointmentController.AddAppointmentsToAppointmentView(appointmentsTable);
            // dSet.Tables.Add(appointmentsTable);
            // Bind data to DataGridView.DataSource
            appointmentsDataGridView.DataSource = dSet.Tables["All Appointments"];
        }

        private void goBackButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new Menu();
            Menu.Show(this);
        }

        private void AppointmentsDeleteButton_Click(object sender, EventArgs e)
        {
            string message = $"Are you sure you want to delete this appointment?" +
                $"\n\nCustomer: {appointmentsDataGridView.CurrentRow.Cells["Customer Name"].Value}\n" +
                $"Begin: {appointmentsDataGridView.CurrentRow.Cells["Start"].Value}\n" +
                $"End: {appointmentsDataGridView.CurrentRow.Cells["End"].Value}";
            string title = "Warning: Appointment Deletion";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {

                AppointmentController appointmentController = new AppointmentController();
                var appointmentIdToRemove = Convert.ToInt32(appointmentsDataGridView.CurrentRow.Cells["Appointment ID"].Value);
                appointmentsTable.Rows.Remove(appointmentsTable.Rows.Find(appointmentIdToRemove));
                appointmentController.deleteAppointment(appointmentIdToRemove);

                appointmentsTable.AcceptChanges();

            }
        }

        private void AppointmentsAddButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new AddAppointmentView();
            Menu.Show(this);
        }

        private void AppointmentsUpdateButton_Click(object sender, EventArgs e)
        {
    
            if (String.IsNullOrEmpty(appointmentsDataGridView.CurrentRow.Cells["Appointment ID"].Value.ToString()))
            {
                MessageBox.Show("No appointment has been selected! Please select an appointment record.");
            }
            else 
            {
                this.Hide();
                UpdateAppointmentView.appointmentId = appointmentsDataGridView.CurrentRow.Cells["Appointment ID"].Value.ToString();
                var Menu = new UpdateAppointmentView();
                Menu.Show(this);
            }
            
        }
    }
}
