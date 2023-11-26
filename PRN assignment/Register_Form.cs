using data;
using data.Models;
using Microsoft.VisualBasic.Logging;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PRN_assignment
{
    public partial class Register_Form : Form
    {
        public Register_Form()
        {
            InitializeComponent();
        }
        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register_Form register = new Register_Form();
            Login_Form login = new Login_Form();
            User user = new User();
            var userRepo = new UserRepository();


            String userName = txtUserName.Text;
            String password = txtPassword.Text;
            String confirmPassword = txtConfirmPassword.Text;
            String email = txtEmail.Text;
            String confirmEmail = txtConfimrEmail.Text;
            User userDB = userRepo.GetByUsername(userName);

            if (userName.Equals(""))
            {
                MessageBox.Show("User's Name cannot be null.");
                return;
            }

            if (password.Equals(""))
            {
                MessageBox.Show("Password cannot be null.");
                return;
            }
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");

            if (!regexItem.IsMatch(userName)) {
                MessageBox.Show("User's Name cannot have special character.");
                return;
            }
            if (!regexItem.IsMatch(password))
            {
                MessageBox.Show("User's Name cannot have special character.");
                return;
            }

            if (email.Equals(""))
            {
                MessageBox.Show("Email cannot be null.");
                return;
            }

            if (userDB != null)
            {
                MessageBox.Show("User's Name is duplicated.");
                return;
            }

            if (!password.Equals(confirmPassword))
            {
                MessageBox.Show("Password does not match with each others.");
                return;
            }

            if (!email.EndsWith("@gmail.com"))
            {
                MessageBox.Show("Email is not valid.");
                return;
            }

            if (!email.Equals(confirmEmail))
            {
                MessageBox.Show("Email does not match with each others.");
                return;
            }

            bool emailCheck = userRepo.IsEmailDuplicate(email);
            if (emailCheck)
            {
                MessageBox.Show("This email has been already registered.");
                return;
            }


            user.UserName = userName;
            user.Password = password;
            user.Email = email;
            userRepo.CreateUser(user);
            MessageBox.Show("User registerd successfully.");

            this.Hide();
            login.Show();



        }


        private void btnRegister_MouseEnter(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.Tomato;
        }

        private void btnRegister_MouseLeave(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.MediumSlateBlue;
        }

        private void Register_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Login_Form login = new Login_Form();

            this.Hide();
            login.Show();
        }
    }
}
