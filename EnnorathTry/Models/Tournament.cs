using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EnnorathTry.Models
{
    public class Tournament
    {
        private readonly MatchesBook _matchesBook;
        public string Name
        {
            get;
            set;
        }

        public int CountPlayers
        { get; }
        public string Type
        { get; }
        private DateOnly DateStart
        { get; }
        private DateOnly DateFinish
        { get; set; }

        public Tournament(string name, string type, int countPlayers)
        {
            Name = name;
            Type = type;
            CountPlayers = countPlayers;

            _matchesBook = new MatchesBook(countPlayers);
        }

    }
}
