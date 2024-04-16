using EnnorathTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.ViewModels
{
    public class TournamentVMhelp : VMBase
    {

        private readonly Tournament _tour;
        public string Name
        { 
        get=> _tour.Name;
        }
        public int CountPlayers => _tour.CountPlayers;
        public string Type => _tour.Type;
        public string DateStart => _tour.DateStart.ToString();
        public string DateFinish =>_tour.DateFinish.ToString();
        
        public TournamentVMhelp(Tournament tour)
        { 
            _tour= tour;
        }
    }
}
