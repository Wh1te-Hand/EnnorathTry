using EnnorathTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Services.TournamentProvider
{
    public interface ITournamentProvider
    {
        Task<IEnumerable<Tournament>> GetAllTournaments();
    }
}
