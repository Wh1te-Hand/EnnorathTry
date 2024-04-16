using EnnorathTry.Models;
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

        public IEnumerable<TournamentVMhelp> Tournaments => _tournaments;
        public ICommand BackToTournir { get; }

        public TournirListVM()
        { 
            _tournaments=new ObservableCollection<TournamentVMhelp>();

            _tournaments.Add(new TournamentVMhelp(new Tournament("Manya", "solo", 8, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now))));
            _tournaments.Add(new TournamentVMhelp(new Tournament("Badya", "solo", 8, DateOnly.FromDateTime(DateTime.Now), DateOnly.FromDateTime(DateTime.Now))));
            
        }
    }
}
