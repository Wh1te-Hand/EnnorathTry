using EnnorathTry.Commands;
using EnnorathTry.Models;
using EnnorathTry.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EnnorathTry.ViewModels
{
    public class TournirListVM: VMBase
    {
        private readonly ObservableCollection<TournamentVMhelp> _tournaments;
        private TournamentBook _tourBook;
        public IEnumerable<TournamentVMhelp> Tournaments => _tournaments;
        public ICommand BackToTournir { get; }

        public TournirListVM(TournamentBook tourBook, NavigationService tournirCreateNavService) // can be changed to be need VMclass to display
        { 
            _tournaments=new ObservableCollection<TournamentVMhelp>();
            _tourBook=tourBook;
/*
            _tournaments.Add(new TournamentVMhelp(new Tournament("Manya", "solo", 8, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now))));
            _tournaments.Add(new TournamentVMhelp(new Tournament("Badya", "solo", 8, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now))));
*/
            BackToTournir = new NavigateCommand(tournirCreateNavService);
            if ((_tourBook.GetTournaments())!=null)
                UpdateList();
            else
                _tournaments.Add(new TournamentVMhelp(new Tournament("empty", "empty", 0, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now))));

        }

        private void UpdateList()
        {
            _tournaments.Clear();

            foreach (Tournament item in _tourBook.GetTournaments())
            { 
                TournamentVMhelp tournirCreateVM=new TournamentVMhelp(item);
                _tournaments.Add(tournirCreateVM);
            }
        }
    }
}
