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
    public partial class UpdatePatientRecordView : Form
    {
        public static string patientId;
        public UpdatePatientRecordView()
        {
            InitializeComponent();
            customerIdTextBox.Text = patientId;
            loadPatientData(patientId);
        }

        public void loadPatientData(string customerId)
        {
            PatientController controller = new PatientController();
            controller.patientId = Int32.Parse(customerId);
            List<string> data = PatientController.GetPatientDataToUpdate(controller.patientId);

            customerIdTextBox.Text = patientId;
            FirstNameUpdateCustomerTextBox.Text = data[0].Split(' ')[0];
            LastNameUpdateCustomerTextBox.Text = data[0].Split(' ')[1];
            StreetAddressUpdateCustomerTextBox.Text = data[1];
            StreetAddress2UpdateCustomerTextBox.Text = data[2];
            CityUpdateCustomerTextBox.Text = data[3];
            ZipcodeUpdateCustomerTextBox.Text = data[5];
            CountryUpdateCustomerTextBox.Text = data[4];
            PhoneNumberUpdateCustomerTextBox.Text = data[6];
        }
        private void GoBackUpdatePatientButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            var Menu = new PatientRecordsView();
            Menu.Show(this);
        }

        private void ConfirmUpdatePatientButton_Click(object sender, EventArgs e)
        {
            PatientController patientController = new PatientController();
            Patient patient = new Patient();

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
                    if (patientController.validateUniquePatient(name) != false) 
                    {
                        patient.active = 1;
                        patient.patientId = Int32.Parse(customerIdTextBox.Text);
                        patient.patientName = FirstNameUpdateCustomerTextBox.Text.Trim() + " " + LastNameUpdateCustomerTextBox.Text.Trim();
                        patient.address = StreetAddressUpdateCustomerTextBox.Text.Trim();
                        patient.address2 = StreetAddress2UpdateCustomerTextBox.Text.Trim();
                        patient.city = CityUpdateCustomerTextBox.Text.Trim();
                        patient.postalCode = ZipcodeUpdateCustomerTextBox.Text.Trim();
                        patient.country = CountryUpdateCustomerTextBox.Text.Trim();
                        patient.phone = PhoneNumberUpdateCustomerTextBox.Text.Trim();

                        patientController.editExistingPatient(patient);

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
    }
}
