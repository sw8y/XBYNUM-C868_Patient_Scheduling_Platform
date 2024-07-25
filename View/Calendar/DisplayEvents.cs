using Google.Protobuf.WellKnownTypes;
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

namespace XBYNUM_C969_Application_Development.View.Calendar
{
    public partial class DisplayEvents : Form
    {
        DataTable appointmentsTable = new DataTable("All Appointments");
        private DataSet dSet;
        public DisplayEvents()
        {
            InitializeComponent();
            var check = CreateAppointmentsTable();
            YourTimeZoneTextBox.Text = TimeZone.CurrentTimeZone.StandardName;
            if (YourTimeZoneTextBox.Text == "Coordinated Universal Time")
            {
                daylightSavingsTimeTextBox.Text = "Does Not Apply To UTC";
            }
            else 
            {
                if (check) { daylightSavingsTimeTextBox.Text = "True"; } else { daylightSavingsTimeTextBox.Text = "False"; }
            }
            

        }

        private bool CreateAppointmentsTable()
        {
            DataColumn appointmentsDataColumn;

            // Create Appointment ID column

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = System.Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Appointment ID";
            appointmentsDataColumn.Caption = "Appointment ID";
            appointmentsDataColumn.ReadOnly = true;
            //appointmentsDataColumn.Unique = true;
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Customer Name column

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = System.Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Customer Name";
            appointmentsDataColumn.Caption = "Customer Name";
            appointmentsDataColumn.ReadOnly = true;
            //appointmentsDataColumn.Unique = true;
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Title column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = System.Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Title";
            appointmentsDataColumn.Caption = "Title";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Description column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = System.Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Description";
            appointmentsDataColumn.Caption = "description";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Location column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = System.Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Location";
            appointmentsDataColumn.Caption = "Location";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Contact column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = System.Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Contact";
            appointmentsDataColumn.Caption = "Contact";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Type column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = System.Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Type";
            appointmentsDataColumn.Caption = "Type";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create URL column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = System.Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "URL";
            appointmentsDataColumn.Caption = "URL";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create Start column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = System.Type.GetType("System.String");
            appointmentsDataColumn.ColumnName = "Start";
            appointmentsDataColumn.Caption = "Start";
            appointmentsTable.Columns.Add(appointmentsDataColumn);

            // Create END column.

            appointmentsDataColumn = new DataColumn();
            appointmentsDataColumn.DataType = System.Type.GetType("System.String");
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
            var check = UserControlDay.displayEvent(appointmentsTable);
            //AppointmentController.AddAppointmentsToAppointmentView(appointmentsTable);
            // Bind data to DataGridView.DataSource
            appointmentsDataGridView.DataSource = dSet.Tables["All Appointments"];
            return check;
        }


    }
}
