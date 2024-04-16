using EnnorathTry.Models;
using EnnorathTry.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace EnnorathTry
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly TournamentBook _tourBook;

        public App()
        { 
            _tourBook = new TournamentBook();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowVM(_tourBook)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
