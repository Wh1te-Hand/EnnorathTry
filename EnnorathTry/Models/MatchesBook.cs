using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Models
{
    public class MatchesBook
    {
        private Dictionary<int, List<Match>> _matchesBook; // для регистрирования полуфиналов и остальных этапов турнира , 1-финал, 2-полуфинал и т.д.
        public int NumberOfParticipants { get; }
        public MatchesBook(int countPlayers)
        { 
            NumberOfParticipants = countPlayers;
            _matchesBook= new Dictionary<int, List<Match>>();
        }

    }
}
