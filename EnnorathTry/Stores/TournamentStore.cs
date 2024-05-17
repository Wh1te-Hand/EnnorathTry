using EnnorathTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Stores
{
    public class TournamentStore
    {
        private readonly TournamentBook _tournamentBook;
        private Lazy<Task> _initializeLazy;
        private List<Tournament> _tournaments;
        public IEnumerable<Tournament> Tournaments => _tournaments;

        public event Action<Tournament> TournamentAdd;// can add to something

        public TournamentStore(TournamentBook tourBook) 
        {
            _initializeLazy = new Lazy<Task>(Initialize);
            _tournaments= new List<Tournament>();
            _tournamentBook = tourBook;
        }

        public async Task Load()
        {
            try
            {
                await _initializeLazy.Value;
            }
            catch(Exception)
            {
                _initializeLazy = new Lazy<Task>(Initialize);
                throw;
            }
            
        }

        public async Task CreateTournament(Tournament tournament)
        {
            await _tournamentBook.AddTournament(tournament);

            _tournaments.Add(tournament);
        }


        private async Task Initialize()
        {
            IEnumerable<Tournament> tournaments = await _tournamentBook.GetTournaments();
            _tournaments.Clear();
            _tournaments.AddRange(tournaments);
        }
    }
}
