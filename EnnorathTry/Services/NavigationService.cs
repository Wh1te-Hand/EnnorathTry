using EnnorathTry.Models;
using EnnorathTry.Stores;
using EnnorathTry.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Services
{
    public class NavigationService
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<VMBase> _createVM;

        public NavigationService(NavigationStore navigationStore, Func<VMBase> createVM)
        {
            _navigationStore = navigationStore;
            _createVM = createVM;
        }
        public void Navigate()
        {
            _navigationStore.CurrentViewModel = _createVM();
        }
    }
}
