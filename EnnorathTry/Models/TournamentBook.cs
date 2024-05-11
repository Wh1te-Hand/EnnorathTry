using EnnorathTry.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Models
{
    public class TournamentBook
    {
        private List<Tournament> _tournamentBook; // для регистрирования полуфиналов и остальных этапов турнира , 1-финал, 2-полуфинал и т.д.
        public TournamentBook()
        {
            _tournamentBook = new List<Tournament>();
        }

        public void AddTournament(Tournament tournament)
        {
            _tournamentBook.Add(tournament); //memoryException?+ check if i need unique tournament every time
        }

        public List<Tournament> GetTournaments()
        {
            if (_tournamentBook.Count != 0)
                return _tournamentBook;
            else
                return null;
        }
    }
}
