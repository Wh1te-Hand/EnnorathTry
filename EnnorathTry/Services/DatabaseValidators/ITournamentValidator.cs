using EnnorathTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Services.DatabaseValidators
{
    public interface ITournamentValidator
    {
        Task<Tournament> ConflictData(Tournament tournament);
    }
}
