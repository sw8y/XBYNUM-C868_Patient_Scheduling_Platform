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
using XBYNUM_C969_Application_Development.Model;

namespace XBYNUM_C969_Application_Development
{
    public partial class UpdateCustomerRecordView : Form
    {
        public static string customerId;
        public UpdateCustomerRecordView()
        {
            InitializeComponent();
            customerIdTextBox.Text = customerId;
            loadCustomerData(customerId);
        }

        public void loadCustomerData(string customerId)
        {
            CustomerController controller = new CustomerController();
            controller.customerId = Int32.Parse(customerId);
            List<string> data = CustomerController.GetCustomerDataToUpdate(controller.customerId);

            customerIdTextBox.Text = customerId;
            FirstNameUpdateCustomerTextBox.Text = data[0].Split(' ')[0];
            LastNameUpdateCustomerTextBox.Text = data[0].Split(' ')[1];
            StreetAddressUpdateCustomerTextBox.Text = data[1];
            StreetAddress2UpdateCustomerTextBox.Text = data[2];
            CityUpdateCustomerTextBox.Text = data[3];
            ZipcodeUpdateCustomerTextBox.Text = data[5];
            CountryUpdateCustomerTextBox.Text = data[4];
            PhoneNumberUpdateCustomerTextBox.Text = data[6];
        }
        private void GoBackUpdateCustomerButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new CustomerRecordsView();
            Menu.Show(this);
        }

        private void ConfirmUpdateCustomerButton_Click(object sender, EventArgs e)
        {
            CustomerController customerController = new CustomerController();
            Customer customer = new Customer();

            string sPattern = "^\\d{3}-\\d{3}-\\d{4}$";
            if (String.IsNullOrEmpty(FirstNameUpdateCustomerTextBox.Text) ||
                (String.IsNullOrEmpty(LastNameUpdateCustomerTextBox.Text)) ||
                (String.IsNullOrEmpty(StreetAddressUpdateCustomerTextBox.Text)) ||
                (String.IsNullOrEmpty(CityUpdateCustomerTextBox.Text)) ||
                (String.IsNullOrEmpty(ZipcodeUpdateCustomerTextBox.Text)) ||
                (String.IsNullOrEmpty(CountryUpdateCustomerTextBox.Text)) ||
                (String.IsNullOrEmpty(PhoneNumberUpdateCustomerTextBox.Text)))
            {
                MessageBox.Show("Fields cannot be empty! Please add values.");
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(PhoneNumberUpdateCustomerTextBox.Text.Trim(), sPattern))
                {
                    string name = FirstNameUpdateCustomerTextBox.Text.Trim() + " " + LastNameUpdateCustomerTextBox.Text.Trim();
                    if (customerController.validateUniqueCustomer(name) != false) 
                    {
                        customer.active = 1;
                        customer.customerId = Int32.Parse(customerIdTextBox.Text);
                        customer.customerName = FirstNameUpdateCustomerTextBox.Text.Trim() + " " + LastNameUpdateCustomerTextBox.Text.Trim();
                        customer.address = StreetAddressUpdateCustomerTextBox.Text.Trim();
                        customer.address2 = StreetAddress2UpdateCustomerTextBox.Text.Trim();
                        customer.city = CityUpdateCustomerTextBox.Text.Trim();
                        customer.postalCode = ZipcodeUpdateCustomerTextBox.Text.Trim();
                        customer.country = CountryUpdateCustomerTextBox.Text.Trim();
                        customer.phone = PhoneNumberUpdateCustomerTextBox.Text.Trim();

                        customerController.editExistingCustomer(customer);

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
    }
}
