using EnnorathTry.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.ViewModels
{
    public class DisplayIdTournamentHelp
    {
        private readonly Tournament _tour;
        public int Id => _tour.Id;
        public string Name
        {
            get => _tour.Name;
        }
        public int CountPlayers => _tour.CountPlayers;
        public string Type => _tour.Type;
        public string DateStart => _tour.DateStart.ToString();
        public string DateFinish => _tour.DateFinish.ToString();

        public DisplayIdTournamentHelp(Tournament tour,int id)
        {
            _tour = new Tournament(tour.Name, tour.Type, tour.CountPlayers, tour.DateStart, tour.DateFinish, id);
        }
    }
}
