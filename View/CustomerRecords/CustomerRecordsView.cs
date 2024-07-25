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
    public partial class CustomerRecordsView : Form
    {
        DataTable customersTable = new DataTable("All Customers");
        private DataSet dSet;

        public CustomerRecordsView()
        {
            InitializeComponent();
            CreateCustomersTable();
            
        }

        private void CustomerRecordsAddButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new AddCustomerRecordView();
            Menu.Show();
        }

        private void CustomerRecordsUpdateButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(customerDataGridView.CurrentRow.Cells["Customer ID"].Value.ToString()))
            {
                MessageBox.Show("No customer has been selected! Please select a customer record.");
            }
            else
            {
                this.Hide();
                UpdateCustomerRecordView.customerId = customerDataGridView.CurrentRow.Cells["Customer ID"].Value.ToString();
                var Menu = new UpdateCustomerRecordView();
                Menu.Show();
            }
        }

        private void CreateCustomersTable()
        {
            DataColumn customersDataColumn;

            // Create Customer ID column

            customersDataColumn = new DataColumn();
            customersDataColumn.DataType = Type.GetType("System.String");
            customersDataColumn.ColumnName = "Customer ID";
            customersDataColumn.Caption = "Customer ID";
            customersDataColumn.ReadOnly = true;
            //customersDataColumn.Unique = true;
            customersTable.Columns.Add(customersDataColumn);

            // Create Customer Name column

            customersDataColumn = new DataColumn();
            customersDataColumn.DataType = Type.GetType("System.String");
            customersDataColumn.ColumnName = "Customer Name";
            customersDataColumn.Caption = "Customer Name";
            customersDataColumn.ReadOnly = true;
            //customersDataColumn.Unique = true;
            customersTable.Columns.Add(customersDataColumn);

            // Create Address column.

            customersDataColumn = new DataColumn();
            customersDataColumn.DataType = Type.GetType("System.String");
            customersDataColumn.ColumnName = "Address";
            customersDataColumn.Caption = "Address";
            customersTable.Columns.Add(customersDataColumn);

            // Create Address (2) column.

            customersDataColumn = new DataColumn();
            customersDataColumn.DataType = Type.GetType("System.String");
            customersDataColumn.ColumnName = "Address (2)";
            customersDataColumn.Caption = "Address (2)";
            customersTable.Columns.Add(customersDataColumn);

            // Create City column.

            customersDataColumn = new DataColumn();
            customersDataColumn.DataType = Type.GetType("System.String");
            customersDataColumn.ColumnName = "City";
            customersDataColumn.Caption = "City";
            customersTable.Columns.Add(customersDataColumn);

            // Create Country column.

            customersDataColumn = new DataColumn();
            customersDataColumn.DataType = Type.GetType("System.String");
            customersDataColumn.ColumnName = "Country";
            customersDataColumn.Caption = "Country";
            customersTable.Columns.Add(customersDataColumn);

            // Create Postal Code column.

            customersDataColumn = new DataColumn();
            customersDataColumn.DataType = Type.GetType("System.String");
            customersDataColumn.ColumnName = "Postal Code";
            customersDataColumn.Caption = "Postal Code";
            customersTable.Columns.Add(customersDataColumn);

            // Create Phone Number column.

            customersDataColumn = new DataColumn();
            customersDataColumn.DataType = Type.GetType("System.String");
            customersDataColumn.ColumnName = "Phone Number";
            customersDataColumn.Caption = "Phone Number";
            customersTable.Columns.Add(customersDataColumn);
            // Make Part ID column the primary key column.

            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = customersTable.Columns["Customer Name"];
            customersTable.PrimaryKey = PrimaryKeyColumns;

            // Add Products Table to DataSet
            // Create a new DataSet

            dSet = new DataSet();
            dSet.Tables.Add(customersTable);

            // Add data to table using NewRow in Customer Controller method

            //CustomerController.AddCustomerDataToView(customersTable);
            CustomerController.AddCustomersFromDatabaseToDataGrid(customersTable);
            // Bind data to DataGridView.DataSource
            customerDataGridView.DataSource = dSet.Tables["All Customers"];
        }

        private void CustomerRecordsDeleteButton_Click(object sender, EventArgs e)
        {
            string message = $"Are you sure you want to delete this customer?" +
                $"\n\nCustomer: {customerDataGridView.CurrentRow.Cells["Customer Name"].Value}";
            string title = "Warning: Customer Deletion";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(message, title, buttons);
            if (result == DialogResult.Yes)
            {
                CustomerController customerController = new CustomerController();
                var customerIdToRemove = Convert.ToInt32(customerDataGridView.CurrentRow.Cells["Customer ID"].Value);
                var customerToRemove = customerDataGridView.CurrentRow.Cells["Customer Name"].Value;
                customersTable.Rows.Remove(customersTable.Rows.Find(customerToRemove));
                customerController.deleteCustomer(Convert.ToInt32(customerIdToRemove));

                customersTable.AcceptChanges();

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
            customerDataGridView.ClearSelection();
            Console.WriteLine(searchCriteria.All(char.IsDigit));
                
           if (searchCriteria.All(char.IsDigit) == true)
            {
                try
                {
                    //Debug.WriteLine($"{searchCriteria}");
                    foreach (DataGridViewRow row in customerDataGridView.Rows)
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
                        { MessageBox.Show("Customer could not be found!"); }
                    }

                }
                catch (System.NullReferenceException) { MessageBox.Show("Part could not be found!"); }

            }
            else
            {
                foreach (DataGridViewRow row in customerDataGridView.Rows)
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
                    { MessageBox.Show("Customer could not be found!"); }

                }
            }
        }
    }
}
