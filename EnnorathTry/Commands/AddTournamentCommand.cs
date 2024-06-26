﻿using EnnorathTry.Models;
using EnnorathTry.Services;
using EnnorathTry.Stores;
using EnnorathTry.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EnnorathTry.Commands
{
    public class AddTournamentCommand : AsyncCommandBase
    {
        private readonly TournamentStore _tourStore;
        private readonly NavigationService _navigationService;
        private readonly TournirCreateVM _tourCreateVM;
        public AddTournamentCommand(TournirCreateVM tourCreateVM, TournamentStore tourStore, NavigationService navigationService) 
        {
            _tourStore=tourStore;
            _navigationService = navigationService;
            _tourCreateVM = tourCreateVM;

            _tourCreateVM.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object param)
        {
            return !string.IsNullOrEmpty(_tourCreateVM.TournirName) && !string.IsNullOrEmpty(_tourCreateVM.Count) && base.CanExecute(param);
        }
        public override async Task ExecuteAsync(object param)
        {
            Tournament tournament = new Tournament(
                _tourCreateVM.TournirName,
                _tourCreateVM.Type,
                int.Parse(_tourCreateVM.Count.Trim()),
                DateOnly.FromDateTime(_tourCreateVM.DateStart),
                DateOnly.FromDateTime(_tourCreateVM.DateFinish)
                );

            try
            {
            // await _tourBook.AddTournament(tournament);
            await _tourStore.CreateTournament( tournament );
                _navigationService.Navigate();
            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Something wrong {ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

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
