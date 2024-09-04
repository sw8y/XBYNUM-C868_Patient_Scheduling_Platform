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
            patientIdTextBox.Text = patientId;
            loadPatientData(patientId);
        }

        public void loadPatientData(string patientId)
        {
            PatientController controller = new PatientController();
            controller.patientId = Int32.Parse(patientId);
            List<string> data = PatientController.GetPatientDataToUpdate(controller.patientId);

            patientIdTextBox.Text = patientId;
            FirstNameUpdatePatientTextBox.Text = data[0].Split(' ')[0];
            LastNameUpdatePatientTextBox.Text = data[0].Split(' ')[1];
            StreetAddressUpdatePatientTextBox.Text = data[1];
            StreetAddress2UpdatePatientTextBox.Text = data[2];
            CityUpdatePatientTextBox.Text = data[3];
            ZipcodeUpdatePatientTextBox.Text = data[5];
            CountryUpdatePatientTextBox.Text = data[4];
            PhoneNumberUpdatePatientTextBox.Text = data[6];
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
            if (String.IsNullOrEmpty(FirstNameUpdatePatientTextBox.Text) ||
                (String.IsNullOrEmpty(LastNameUpdatePatientTextBox.Text)) ||
                (String.IsNullOrEmpty(StreetAddressUpdatePatientTextBox.Text)) ||
                (String.IsNullOrEmpty(CityUpdatePatientTextBox.Text)) ||
                (String.IsNullOrEmpty(ZipcodeUpdatePatientTextBox.Text)) ||
                (String.IsNullOrEmpty(CountryUpdatePatientTextBox.Text)) ||
                (String.IsNullOrEmpty(PhoneNumberUpdatePatientTextBox.Text)))
            {
                MessageBox.Show("Fields cannot be empty! Please add values.");
            }
            else
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(PhoneNumberUpdatePatientTextBox.Text.Trim(), sPattern))
                {
                    string name = FirstNameUpdatePatientTextBox.Text.Trim() + " " + LastNameUpdatePatientTextBox.Text.Trim();
                    if (patientController.validateUniquePatient(name) != false) 
                    {
                        patient.active = 1;
                        patient.patientId = Int32.Parse(patientIdTextBox.Text);
                        patient.patientName = FirstNameUpdatePatientTextBox.Text.Trim() + " " + LastNameUpdatePatientTextBox.Text.Trim();
                        patient.address = StreetAddressUpdatePatientTextBox.Text.Trim();
                        patient.address2 = StreetAddress2UpdatePatientTextBox.Text.Trim();
                        patient.city = CityUpdatePatientTextBox.Text.Trim();
                        patient.postalCode = ZipcodeUpdatePatientTextBox.Text.Trim();
                        patient.country = CountryUpdatePatientTextBox.Text.Trim();
                        patient.phone = PhoneNumberUpdatePatientTextBox.Text.Trim();

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
