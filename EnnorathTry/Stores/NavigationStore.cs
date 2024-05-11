using EnnorathTry.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Stores
{
    public class NavigationStore
    {
        private VMBase _currentViewModel;

        public VMBase CurrentViewModel
        {
            get => _currentViewModel;
            set
            {
                _currentViewModel = value; //add something useful
                OnCurrentViewModelChanged();
            }

        }

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }

        public event Action CurrentViewModelChanged;
    }
}
