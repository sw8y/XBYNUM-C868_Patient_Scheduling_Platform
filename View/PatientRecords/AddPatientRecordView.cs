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
            if (String.IsNullOrEmpty(FirstNameAddPatientTextBox.Text) ||
                (String.IsNullOrEmpty(LastNameAddPatientTextBox.Text)) ||
                (String.IsNullOrEmpty(StreetAddressAddPatientTextBox.Text)) ||
                (String.IsNullOrEmpty(CityAddPatientTextBox.Text)) ||
                (String.IsNullOrEmpty(ZipcodeAddPatientTextBox.Text)) ||
                (String.IsNullOrEmpty(CountryAddPatientTextBox.Text)) ||
                (String.IsNullOrEmpty(PhoneNumberAddPatientTextBox.Text)))
            {
                MessageBox.Show("Fields cannot be empty! Please add values.");
            }
            else 
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(PhoneNumberAddPatientTextBox.Text.Trim(), sPattern))
                {
                    string name = FirstNameAddPatientTextBox.Text.Trim() + " " + LastNameAddPatientTextBox.Text.Trim();
                    if (patientController.validateUniquePatient(name) != false) 
                    {
                        patient.active = 1;
                        patient.patientName = FirstNameAddPatientTextBox.Text.Trim() + " " + LastNameAddPatientTextBox.Text.Trim();
                        patient.address = StreetAddressAddPatientTextBox.Text.Trim();
                        patient.address2 = StreetAddress2AddPatientTextBox.Text.Trim();
                        patient.city = CityAddPatientTextBox.Text.Trim();
                        patient.postalCode = ZipcodeAddPatientTextBox.Text.Trim();
                        patient.country = CountryAddPatientTextBox.Text.Trim();
                        patient.phone = PhoneNumberAddPatientTextBox.Text.Trim();

                        patientController.addPatient(patient);

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
