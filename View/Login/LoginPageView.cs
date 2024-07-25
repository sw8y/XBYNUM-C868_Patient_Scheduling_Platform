using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Device.Location;
using XBYNUM_C969_Application_Development.Controller;
using XBYNUM_C969_Application_Development.Model;
using MySql.Data.MySqlClient;
using System.Globalization;

namespace XBYNUM_C969_Application_Development
{
    public partial class LoginPageView : Form
    {
        public LoginPageView()
        {
            InitializeComponent();
            locationTextBox.Text = UserController.CityStateCountByIp(UserController.GetPublicIPAddress().ToString());
           
        }

        private void loginPageSubmitButton_Click(object sender, EventArgs e)
        {
            bool VerificationStatus = UserController.AuthenticateUser(loginPageUsernameTextBox.Text, loginPagePasswordTextBox.Text);
            if (VerificationStatus)
            {
                UserController.username = loginPageUsernameTextBox.Text;
                UserController.LogAccess();
                if (UserController.appointmentAboutToStart()) { MessageBox.Show("You have an appointment starting within 15 minutes!"); };
                this.Hide();
                var Menu = new Menu();
                Menu.Show();
            }
            else 
            {
               
                if (RegionInfo.CurrentRegion.ToString() == "US") 
                {
                    MessageBox.Show("English: The username and password do not match!");
                }
                else 
                {
                    MessageBox.Show("Spanish: El nombre de usuario y la contraseña no coinciden!");
                }
              
            }
        }
    }
}
