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
        //private TournamentBook _tourBook;
        public IEnumerable<TournamentVMhelp> Tournaments => _tournaments;
        public ICommand BackToTournir { get; }
        public ICommand LoadTournaments { get; }

        public TournirListVM(TournamentBook tourBook, NavigationService tournirCreateNavService) // can be changed to be need VMclass to display
        { 
            _tournaments=new ObservableCollection<TournamentVMhelp>();
           // _tourBook=tourBook;
/*
            _tournaments.Add(new TournamentVMhelp(new Tournament("Manya", "solo", 8, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now))));
            _tournaments.Add(new TournamentVMhelp(new Tournament("Badya", "solo", 8, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now))));
*/
            BackToTournir = new NavigateCommand(tournirCreateNavService);
            LoadTournaments = new LoadTournamentCommand(this, tourBook);

/*            if ((_tourBook.GetTournaments())!=null) // our update function
                UpdateList();
            else
                _tournaments.Add(new TournamentVMhelp(new Tournament("empty", "empty", 0, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now))));
*/
        }

        public static TournirListVM LoadListViewModel(TournamentBook tourBook, NavigationService tournirCreateNavService)
        {
            TournirListVM newListViewModel = new TournirListVM(tourBook,tournirCreateNavService);
            newListViewModel.LoadTournaments.Execute(null);
            return newListViewModel;
        }

        public void UpdateList(IEnumerable<Tournament> tournaments)
        {
            _tournaments.Clear();
            int id = 1;
            foreach (Tournament item in tournaments)
            { 
                TournamentVMhelp tournirCreateVM=new TournamentVMhelp(item,id);
                _tournaments.Add(tournirCreateVM);
                id++;
            }
        }
    }
}
