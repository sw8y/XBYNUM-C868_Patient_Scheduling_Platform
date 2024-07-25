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
    public partial class AddPatientRecordView : Form
    {
        public AddPatientRecordView()
        {
            InitializeComponent();
        }

        private void ConfirmAddPatientButton_Click(object sender, EventArgs e)
        {
            PatientController patientController = new PatientController();
            Patient patient = new Patient();

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
                    if (patientController.validateUniquePatient(name) != false) 
                    {
                        patient.active = 1;
                        patient.patientName = FirstNameAddCustomerTextBox.Text.Trim() + " " + LastNameAddCustomerTextBox.Text.Trim();
                        patient.address = StreetAddressAddCustomerTextBox.Text.Trim();
                        patient.address2 = StreetAddress2AddCustomerTextBox.Text.Trim();
                        patient.city = CityAddCustomerTextBox.Text.Trim();
                        patient.postalCode = ZipcodeAddCustomerTextBox.Text.Trim();
                        patient.country = CountryAddCustomerTextBox.Text.Trim();
                        patient.phone = PhoneNumberAddCustomerTextBox.Text.Trim();

                        patientController.addNewPatient(patient);

                        this.Hide();
                        var PatientRecords = new PatientRecordsView();
                        PatientRecords.Show();
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

        private void GoBackAddPatientButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new PatientRecordsView();
            Menu.Show();
        }
    }
}
