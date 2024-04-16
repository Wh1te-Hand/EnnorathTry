using EnnorathTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.ViewModels
{
    public class MainWindowVM:VMBase
    {
        public VMBase CurrentModel { get;}

        public MainWindowVM(TournamentBook tourBook)
        { 
            CurrentModel = new TournirCreateVM(tourBook);
        }
    }
}
