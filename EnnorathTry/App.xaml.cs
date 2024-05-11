using EnnorathTry.Models;
using EnnorathTry.Services;
using EnnorathTry.Stores;
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
        private readonly NavigationStore _navigationStore;
        public App()
        { 
            _tourBook = new TournamentBook();
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationStore.CurrentViewModel = CreateTournirListVM(); 

            MainWindow = new MainWindow()
            {
                DataContext = new MainWindowVM(_navigationStore)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }

        // also add navigation on start page
        private TournirListVM CreateTournirListVM() // Where do we want to go
        {
            return new TournirListVM(_tourBook, new NavigationService(_navigationStore, CreateTournirCreateVM));
        }

        private TournirCreateVM CreateTournirCreateVM() 
        {
            return new TournirCreateVM(_tourBook, new NavigationService(_navigationStore, CreateTournirListVM));   
        }
    }
}
