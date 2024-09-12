using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XBYNUM_C969_Application_Development.Controller;
using XBYNUM_C969_Application_Development.Model;

namespace XBYNUM_C969_Application_Development
{
    public partial class PatientRecordsView : Form
    {
        DataTable patientsTable = new DataTable("All Patients");
        private DataSet dSet;

        public PatientRecordsView()
        {
            InitializeComponent();
            CreatePatientsTable();
            
        }

        private void PatientRecordsAddButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new AddPatientRecordView();
            Menu.Show();
        }

        private void PatientRecordsUpdateButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(patientDataGridView.CurrentRow.Cells["Patient ID"].Value.ToString()))
            {
                MessageBox.Show("No patient has been selected! Please select a customer record.");
            }
            else
            {
                this.Hide();
                UpdatePatientRecordView.patientId = patientDataGridView.CurrentRow.Cells["Patient ID"].Value.ToString();
                var Menu = new UpdatePatientRecordView();
                Menu.Show();
            }
        }

        private void CreatePatientsTable()
        {
            DataColumn patientsDataColumn;

            // Create Patient ID column

            patientsDataColumn = new DataColumn();
            patientsDataColumn.DataType = Type.GetType("System.String");
            patientsDataColumn.ColumnName = "Patient ID";
            patientsDataColumn.Caption = "Patient ID";
            patientsDataColumn.ReadOnly = true;
            //patientsDataColumn.Unique = true;
            patientsTable.Columns.Add(patientsDataColumn);

            // Create Patient Name column

            patientsDataColumn = new DataColumn();
            patientsDataColumn.DataType = Type.GetType("System.String");
            patientsDataColumn.ColumnName = "Patient Name";
            patientsDataColumn.Caption = "Patient Name";
            patientsDataColumn.ReadOnly = true;
            //patientsDataColumn.Unique = true;
            patientsTable.Columns.Add(patientsDataColumn);

            // Create Address column.

            patientsDataColumn = new DataColumn();
            patientsDataColumn.DataType = Type.GetType("System.String");
            patientsDataColumn.ColumnName = "Address";
            patientsDataColumn.Caption = "Address";
            patientsTable.Columns.Add(patientsDataColumn);

            // Create Address (2) column.

            patientsDataColumn = new DataColumn();
            patientsDataColumn.DataType = Type.GetType("System.String");
            patientsDataColumn.ColumnName = "Address (2)";
            patientsDataColumn.Caption = "Address (2)";
            patientsTable.Columns.Add(patientsDataColumn);

            // Create City column.

            patientsDataColumn = new DataColumn();
            patientsDataColumn.DataType = Type.GetType("System.String");
            patientsDataColumn.ColumnName = "City";
            patientsDataColumn.Caption = "City";
            patientsTable.Columns.Add(patientsDataColumn);

            // Create Country column.

            patientsDataColumn = new DataColumn();
            patientsDataColumn.DataType = Type.GetType("System.String");
            patientsDataColumn.ColumnName = "Country";
            patientsDataColumn.Caption = "Country";
            patientsTable.Columns.Add(patientsDataColumn);

            // Create Postal Code column.

            patientsDataColumn = new DataColumn();
            patientsDataColumn.DataType = Type.GetType("System.String");
            patientsDataColumn.ColumnName = "Postal Code";
            patientsDataColumn.Caption = "Postal Code";
            patientsTable.Columns.Add(patientsDataColumn);

            // Create Phone Number column.

            patientsDataColumn = new DataColumn();
            patientsDataColumn.DataType = Type.GetType("System.String");
            patientsDataColumn.ColumnName = "Phone Number";
            patientsDataColumn.Caption = "Phone Number";
            patientsTable.Columns.Add(patientsDataColumn);
            // Make Part ID column the primary key column.

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = patientsTable.Columns["Patient Name"];
            patientsTable.PrimaryKey = PrimaryKeyColumns;

            // Add Products Table to DataSet
            // Create a new DataSet

            dSet = new DataSet();
            dSet.Tables.Add(patientsTable);
            // Add data to table using NewRow in Customer Controller method

            //CustomerController.AddCustomerDataToView(patientsTable);
            PatientController.AddPatientsFromDatabaseToDataGrid(patientsTable);
            // Bind data to DataGridView.DataSource
            patientDataGridView.DataSource = dSet.Tables["All Patients"];
        }

        private void PatientRecordsDeleteButton_Click(object sender, EventArgs e)
        {
            string message = $"Are you sure you want to delete this patient?" +
                $"\n\nPatient: {patientDataGridView.CurrentRow.Cells["Patient Name"].Value}";
            string title = "Warning: Patient Deletion";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                PatientController patientController = new PatientController();
                var patientIdToRemove = Convert.ToInt32(patientDataGridView.CurrentRow.Cells["Patient ID"].Value);
                var patientToRemove = patientDataGridView.CurrentRow.Cells["Patient Name"].Value;
                patientsTable.Rows.Remove(patientsTable.Rows.Find(patientToRemove));
                patientController.deletePatient(Convert.ToInt32(patientIdToRemove));

                patientsTable.AcceptChanges();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new Menu();
            Menu.Show();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string searchCriteria = textBox.Text;
            patientDataGridView.ClearSelection();
            Console.WriteLine(searchCriteria.All(char.IsDigit));
                
           if (searchCriteria.All(char.IsDigit) == true)
            {
                try
                {
                    //Debug.WriteLine($"{searchCriteria}");
                    foreach (DataGridViewRow row in patientDataGridView.Rows)
                    {
                        if (row.Cells[0].Value != null)
                        {
                            if (row.Cells[0].Value.ToString().Equals(searchCriteria))
                            {
                                row.Selected = true;
                                break;
                            }
                        }
                        else 
                        { MessageBox.Show("Patient could not be found!"); }
                    }

                }
                catch (System.NullReferenceException) { MessageBox.Show("Part could not be found!"); }

            }
            else
            {
                foreach (DataGridViewRow row in patientDataGridView.Rows)
                {
                    if (row.Cells[1].Value != null)
                    {
                        // 1 is the column index
                        if (row.Cells[1].Value.ToString().Equals(searchCriteria))
                        {
                            row.Selected = true;
                            break;
                        }
                    }
                    else
                    { MessageBox.Show("Patient could not be found!"); }

                }
            }
        }
    }
}
