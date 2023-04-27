using LibraryManagementSystem.controllers;
using LibraryManagementSystem.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace LibraryManagementSystem.views
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Window
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string reguser = txtRegUser.Text.Trim();
            string regpass = txtRegPass.Password.Trim();
            string firstname = txtFirstName.Text.Trim();
            string lastname = txtLastName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();

            // CALLING THE METHOD FROM AUTHCONTROLLER
            ControllerModifyData<User> res = AuthController.Register(reguser, regpass, firstname, lastname, address, phone, email);

            if (res.IsSuccess)
            {
                // CHECK IF THE REGISTRATION IS SUCCESS
                MessageBox.Show("Registration Successfull!!");
                

            }
            else
            {
                // SHOWS ERROR MESSAGE
                string errors = " ";
                foreach(var error in res.Errors)
                {

                    errors += error.Value + "\n";

                }

                MessageBox.Show(errors);

            }

           

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            // BACK TO THE LOGIN FORM
            Login login = new Login();
            login.Show();
            this.Hide();

        }
    }
}
