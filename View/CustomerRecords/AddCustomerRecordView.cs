using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using XBYNUM_C969_Application_Development.Controller;
using XBYNUM_C969_Application_Development.Model;

namespace XBYNUM_C969_Application_Development
{
    public partial class AddCustomerRecordView : Form
    {
        public AddCustomerRecordView()
        {
            InitializeComponent();
        }

        private void ConfirmAddCustomerButton_Click(object sender, EventArgs e)
        {
            CustomerController customerController = new CustomerController();
            Customer customer = new Customer();

            string sPattern = "^\\d{3}-\\d{3}-\\d{4}$";
            if (String.IsNullOrEmpty(FirstNameAddCustomerTextBox.Text) ||
                (String.IsNullOrEmpty(LastNameAddCustomerTextBox.Text)) ||
                (String.IsNullOrEmpty(StreetAddressAddCustomerTextBox.Text)) ||
                (String.IsNullOrEmpty(CityAddCustomerTextBox.Text)) ||
                (String.IsNullOrEmpty(ZipcodeAddCustomerTextBox.Text)) ||
                (String.IsNullOrEmpty(CountryAddCustomerTextBox.Text)) ||
                (String.IsNullOrEmpty(PhoneNumberAddCustomerTextBox.Text)))
            {
                MessageBox.Show("Fields cannot be empty! Please add values.");
            }
            else 
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(PhoneNumberAddCustomerTextBox.Text.Trim(), sPattern))
                {
                    string name = FirstNameAddCustomerTextBox.Text.Trim() + " " + LastNameAddCustomerTextBox.Text.Trim();
                    if (customerController.validateUniqueCustomer(name) != false) 
                    {
                        customer.active = 1;
                        customer.customerName = FirstNameAddCustomerTextBox.Text.Trim() + " " + LastNameAddCustomerTextBox.Text.Trim();
                        customer.address = StreetAddressAddCustomerTextBox.Text.Trim();
                        customer.address2 = StreetAddress2AddCustomerTextBox.Text.Trim();
                        customer.city = CityAddCustomerTextBox.Text.Trim();
                        customer.postalCode = ZipcodeAddCustomerTextBox.Text.Trim();
                        customer.country = CountryAddCustomerTextBox.Text.Trim();
                        customer.phone = PhoneNumberAddCustomerTextBox.Text.Trim();

                        customerController.addNewCustomer(customer);

                        this.Hide();
                        var CustomerRecords = new CustomerRecordsView();
                        CustomerRecords.Show();
                    }
                    else 
                    {
                        MessageBox.Show($"The user \"{name}\" already exists! Please try updating this specific user instead.");
                    }

                    
                }
                else 
                {
                    MessageBox.Show("Please correct the phone number field! Only numbers and dashes allowed in the format of 777-777-7777.");
                }
            }
        }

        private void GoBackAddCustomerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new CustomerRecordsView();
            Menu.Show();
        }
    }
}
