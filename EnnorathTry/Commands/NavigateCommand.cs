using EnnorathTry.Models;
using EnnorathTry.Services;
using EnnorathTry.Stores;
using EnnorathTry.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Commands
{
    public class NavigateCommand : CommandBase
    {
        private readonly NavigationService _navigationService;

        public NavigateCommand(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void Execute(object param)
        {
            _navigationService.Navigate();
        }
    }
}
