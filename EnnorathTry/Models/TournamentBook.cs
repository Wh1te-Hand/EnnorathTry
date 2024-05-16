using EnnorathTry.Commands;
using EnnorathTry.Services.DatabaseValidators;
using EnnorathTry.Services.TournamentCreators;
using EnnorathTry.Services.TournamentProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Models
{
    public class TournamentBook
    {
        //private List<Tournament> _tournamentBook; // для регистрирования полуфиналов и остальных этапов турнира , 1-финал, 2-полуфинал и т.д.#
        private readonly ITournamentProvider _tournamentProvider;
        private readonly ITournamentCreator _tournamentCreator;
        private readonly ITournamentValidator _tournamentValidator;

        public TournamentBook(ITournamentProvider tournamentProvider, ITournamentCreator tournamentCreator, ITournamentValidator tournamentValidator)
        {
            _tournamentValidator = tournamentValidator;
            _tournamentProvider = tournamentProvider;
            _tournamentCreator = tournamentCreator;
        }

        public async Task AddTournament(Tournament tournament)
        {
            Tournament badTournament = await _tournamentValidator.ConflictData(tournament);

            if (badTournament != null) 
            {
                throw new Exception("bad input data");
            }

            await _tournamentCreator.CreateTournament(tournament);
           // _tournamentBook.Add(tournament); //memoryException?+ check if i need unique tournament every time
        }

        public async Task <IEnumerable<Tournament>> GetTournaments()
        {
           // if (_tournamentProvider.GetAllTournaments())
                return await _tournamentProvider.GetAllTournaments();
         //   else
             //   return null;
        }
    }
}
