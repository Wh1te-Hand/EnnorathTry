using EnnorathTry.DataBaseContext;
using EnnorathTry.DTOs;
using EnnorathTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TournamentDTO = EnnorathTry.DTOs.TournamentDTO;

namespace EnnorathTry.Services.TournamentCreators
{
    public class DatabaseTournamentCreator : ITournamentCreator
    {
        private readonly TournamentDBContextFactory _dbContextFactory;

        public DatabaseTournamentCreator(TournamentDBContextFactory dBContextFactory)
        {
            _dbContextFactory = dBContextFactory;
        }
        public async Task CreateTournament(Tournament tournament)
        {
            using (TournamentTestDbContext context= _dbContextFactory.CreateDbContext())
            {
                TournamentDTO tournamentDTO = ToTournamentDTO(tournament);

                context.Tournaments.Add(tournamentDTO);
                await context.SaveChangesAsync();
            }
        }

        private TournamentDTO ToTournamentDTO(Tournament tournament)
        {
            return new TournamentDTO()
            {
             //   Id=tournament.Id,
                Name = tournament.Name,
                Type = tournament.Type,
                CountPlayers = tournament.CountPlayers,
                DateStart = tournament.DateStart,
                DateFinish = tournament.DateFinish,
            };
        }
    }
}
