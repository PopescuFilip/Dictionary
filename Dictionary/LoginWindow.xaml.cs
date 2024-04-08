using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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

namespace Dictionary
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            //AdministratorWindow admin = new AdministratorWindow();
            //admin.Show();
            //Close();

            string username = tbUsername.Text;
            string password = tbPassword.Password;
            tbUsername.Clear();
            tbPassword.Clear();

            if (AdminValidator.Validate(username, password))
            {
                AdministratorWindow admin = new AdministratorWindow();
                admin.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Incorrect user or password");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
