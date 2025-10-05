using System;
using System.Windows.Forms;

namespace StudentManagementWinForms
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            
            // Add login button programmatically
            Button loginButton = new Button();
            loginButton.Text = "Login";
            loginButton.Location = new System.Drawing.Point(100, 150);
            loginButton.Click += LoginButton_Click;
            this.Controls.Add(loginButton);
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // In a real application, validate credentials here
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}