using EnnorathTry.DataBaseContext;
using EnnorathTry.DTOs;
using EnnorathTry.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Services.DatabaseValidators
{
    public class DatabaseTournamentValidator : ITournamentValidator
    {
        private readonly TournamentDBContextFactory _dbContextFactory;

        public DatabaseTournamentValidator(TournamentDBContextFactory dBContextFactory)
        {
            _dbContextFactory = dBContextFactory;
        }
        public async Task<Tournament> ConflictData(Tournament tournament)// add something
        {
            using (TournamentTestDbContext context = _dbContextFactory.CreateDbContext())
            {
                /* TournamentDTO tournamentDTO = await context.Tournaments.
                     Where(r => r.Name == tournament.Name).
                     Where(r => r.Type == tournament.Type).
                     Where(r => r.CountPlayers == tournament.CountPlayers).
                     Where(r => r.DateFinish > tournament.DateStart).
                     Where(r => r.DateStart < tournament.DateFinish).
                     FirstOrDefaultAsync();

                 if (tournamentDTO == null)
                 {
                     return null;
                 }

                 return new Tournament(tournamentDTO.Name, tournamentDTO.Type, tournamentDTO.CountPlayers, tournamentDTO.DateStart, tournamentDTO.DateFinish);*/
                return null;
            }            
        }
    }
}
