using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LagerMan
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            domain.Items.Add("corp.com");
        }

        private void logon_Click(object sender, EventArgs e)
        {
            if (isDemo.Checked == true)
            {
                this.Close();
            }
            else
            {
                switch (Properties.Settings.Default.authType)
                {
                    case "local":
                        authLocal(userName.Text, maskedPass.Text); break;
                    case "AD":
                        authAD(domain.SelectedText, userName.Text, maskedPass.Text); break;
                    default:
                        MessageBox.Show("Case Error", "Logik fejl", MessageBoxButtons.OK); break;
                }
            }
        }

        public void authLocal(string uName, string uPass)
        {

            bool isLoggedIn = false;


            AuthDbUser check = new AuthDbUser();
            isLoggedIn = (bool)check.auth(userName.Text, maskedPass.Text)[0];
            int uGroup = (int) check.auth(userName.Text, maskedPass.Text)[1];

            if (isLoggedIn == true)
            {
                MainForm.setLoggedIn(uName, uGroup, DateTime.Now.ToString());
                this.Close();
            }
            else
            {
                MessageBox.Show("Forker eller manglende brugernavn / password", "Login fejl!", MessageBoxButtons.OK);
            }
        }

        public void authAD(string domain, string uName, string uPass)
        {
            bool isLoggedIn = false;
            int uGrp = 1;

            AuthAD check = new AuthAD(Properties.Settings.Default.adPath);

            if (isLoggedIn == true)
            {
                MainForm.setLoggedIn(uName, uGrp, DateTime.Now.ToString());
                this.Close();
            }
            else
            {
                MessageBox.Show("Forker eller manglende brugernavn / password", "Login fejl!", MessageBoxButtons.OK);
            }
        }
    }

}
