using EnnorathTry.DataBaseContext;
using EnnorathTry.Models;
using EnnorathTry.Services;
using EnnorathTry.Services.DatabaseValidators;
using EnnorathTry.Services.TournamentCreators;
using EnnorathTry.Services.TournamentProvider;
using EnnorathTry.Stores;
using EnnorathTry.ViewModels;
using Microsoft.EntityFrameworkCore;
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
        private const String CONNECTION_STRING = "Data Source=tournament.db";
        private readonly TournamentBook _tourBook;
        private readonly TournamentStore _tourStore;
        private readonly TournamentDBContextFactory _dbContext;
        private readonly NavigationStore _navigationStore;
        public App()
        {
            _dbContext = new TournamentDBContextFactory(CONNECTION_STRING);

            ITournamentCreator tourCreator= new DatabaseTournamentCreator(_dbContext);
            ITournamentProvider tourProvider = new DatabaseTournamentProvider(_dbContext);
            ITournamentValidator tourValidator = new DatabaseTournamentValidator(_dbContext);

            _tourBook = new TournamentBook(tourProvider,tourCreator,tourValidator);
            _tourStore = new TournamentStore(_tourBook);
            _navigationStore = new NavigationStore();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            //DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(CONNECTION_STRING).Options;
/*            using (TournamentTestDbContext dbContext = _dbContext.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }*/


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
            return TournirListVM.LoadListViewModel(_tourStore, new NavigationService(_navigationStore, CreateTournirCreateVM));
        }

        private TournirCreateVM CreateTournirCreateVM() 
        {
            return new TournirCreateVM(_tourStore, new NavigationService(_navigationStore, CreateTournirListVM));   
        }
    }
}
