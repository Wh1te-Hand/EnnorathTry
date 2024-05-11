using EnnorathTry.Models;
using EnnorathTry.Services;
using EnnorathTry.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Commands
{
    public class AddTournamentCommand : CommandBase
    {
        private readonly TournamentBook _tourBook;
        private readonly NavigationService _navigationService;
        private readonly TournirCreateVM _tourCreateVM;
        public AddTournamentCommand(TournirCreateVM tourCreateVM, TournamentBook tourBook, NavigationService navigationService) 
        {
            _tourBook = tourBook;
            _navigationService = navigationService;
            _tourCreateVM = tourCreateVM;

            _tourCreateVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object param)
        {
            return !string.IsNullOrEmpty(_tourCreateVM.TournirName) && !string.IsNullOrEmpty(_tourCreateVM.Count) && base.CanExecute(param);
        }
        public override void Execute(object param)
        {
            Tournament tournament = new Tournament(
                _tourCreateVM.TournirName,
                _tourCreateVM.Type,
                int.Parse(_tourCreateVM.Count.Trim()),
                DateOnly.FromDateTime(_tourCreateVM.DateStart),
                DateOnly.FromDateTime(_tourCreateVM.DateFinish)
                );
            _tourBook.AddTournament(tournament);
            _navigationService.Navigate();
        }
        private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(TournirCreateVM.TournirName) || e.PropertyName == nameof(TournirCreateVM.Count))
            { 
                OnCanExecuteChanged();
            }


        }
    }
}
