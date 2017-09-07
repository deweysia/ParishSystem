﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ParishSystem
{
    public partial class LoginForm : Form
    {
        Login login = new Login();
        public LoginForm()
        {
            InitializeComponent();
        }

        private void login_button_Click(object sender, EventArgs e)
        {


            if (login.verify(Username_textbox.Text, Password_textbox.Text))
            {
                this.Hide();
                SAD2 sad = new SAD2(Username_textbox.Text);
                sad.ShowDialog();
                this.Show();
            }
            else
            {
                Notification.Show(State.WrongCredentials);
            }
        }

        private void peek_button_MouseDown(object sender, MouseEventArgs e)
        {
            Password_textbox.PasswordChar = '\0';   
        }

        private void peek_button_MouseUp(object sender, MouseEventArgs e)
        {
            Password_textbox.PasswordChar = '*';
        }
    }
}
