using BankApp.AdminPanel.DataContext;
using BankApp.Views.Windows;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using TexnoStore.Core.Factory;

namespace TexnoStoreAdminPanel
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            LoginWindow loginWindow = new LoginWindow();


            // MenuWindow menuWindow = new MenuWindow();
            //MenuViewModel menuViewWindow = new MenuViewModel(Kernel.DB,menuWindow);

            //menuWindow.DataContext = menuViewWindow;

            loginWindow.Show();
        }
    }
}
