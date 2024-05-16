using EnnorathTry.Models;
using EnnorathTry.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace EnnorathTry.Commands
{
    public class LoadTournamentCommand : AsyncCommandBase
    {
        private readonly TournamentBook _tournamentBook;
        private readonly TournirListVM _tournirListVM;
        public override async Task ExecuteAsync(object param)
        {
            try
            { 
                IEnumerable<Tournament> tournaments = await _tournamentBook.GetTournaments();
                _tournirListVM.UpdateList(tournaments);
            }
            catch(Exception ex)
            {
                MessageBox.Show($"Something bad in loading, {ex}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public LoadTournamentCommand(TournirListVM tournamentList,TournamentBook tournamentBook)
        { 
            _tournamentBook = tournamentBook;
            _tournirListVM = tournamentList;
        }
    }
}
