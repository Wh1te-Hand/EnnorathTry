using EnnorathTry.DataBaseContext;
using EnnorathTry.DTOs;
using EnnorathTry.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Services.TournamentProvider
{
    public class DatabaseTournamentProvider : ITournamentProvider
    {
        private readonly TournamentDBContextFactory _dbContextFactory;

        public DatabaseTournamentProvider(TournamentDBContextFactory dBContextFactory)
        {
            _dbContextFactory = dBContextFactory;
        }

        public async Task<IEnumerable<Tournament>> GetAllTournaments()
        {
           
            using (TournamentTestDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<DTOs.TournamentDTO> tournamentsDTOs= await context.Tournaments.ToListAsync();
                if (tournamentsDTOs != null)
                { // return tournamentsDTOs.Select(r => new Tournament(r.Name, r.Type, r.CountPlayers, r.DateStart, r.DateFinish, r.Id));//int.Parse(r.Id.ToString())));
                    await Task.Delay(2000);  
                    return tournamentsDTOs.Select(r => new Tournament(r.Name, r.Type, r.CountPlayers, r.DateStart, r.DateFinish));
                }
                else
                    return null;
            }
            
        }
    }
}
