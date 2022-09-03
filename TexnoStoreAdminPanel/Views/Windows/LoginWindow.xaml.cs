using BankApp.AdminPanel.Views.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BankApp.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();            
        }

        public bool count = false;
        private void ShowPassword_Checked(object sender, RoutedEventArgs e)
        {
            PasswordTxtBox.Text = PasswordTxt.Password;
            PasswordTxt.Visibility = Visibility.Collapsed;
            PasswordTxtBox.Visibility = Visibility.Visible;
            count = true;
        }

        private void ShowPassword_Unchecked(object sender, RoutedEventArgs e)
        {
            PasswordTxt.Password = PasswordTxtBox.Text;
            PasswordTxtBox.Visibility = Visibility.Collapsed;
            PasswordTxt.Visibility = Visibility.Visible;

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void login_Click_1(object sender, RoutedEventArgs e)
        {
            if (count)
            {
                PasswordTxt.Password = PasswordTxtBox.Text;
            }
        }
    }
}
