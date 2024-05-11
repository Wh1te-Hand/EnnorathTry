using EnnorathTry.Models;
using EnnorathTry.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.ViewModels
{
    public class MainWindowVM:VMBase
    {
        private readonly NavigationStore _navigationStore;

        public VMBase CurrentViewModel { get=>_navigationStore.CurrentViewModel;}

        public MainWindowVM(NavigationStore navigationStore)
        { 
            _navigationStore = navigationStore;

            _navigationStore.CurrentViewModelChanged +=OnCurrentViewModelChanged;
        }

        private void OnCurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }
    }
}
