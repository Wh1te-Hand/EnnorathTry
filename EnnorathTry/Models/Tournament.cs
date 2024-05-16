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

        public int Id
        { get; }
        public int CountPlayers
        { get; }
        public string Type //can be changrd
        { get; }
        public DateOnly DateStart
        { get; }
        public DateOnly DateFinish
        { get; set; }

        public Tournament(string name, string type, int countPlayers, DateOnly start, DateOnly finish, int id=1)
        {
            Name = name;
            Type = type;
            CountPlayers = countPlayers;
            DateStart = start;
            DateFinish = finish;

            _matchesBook = new MatchesBook(countPlayers);
            Id = id;
        }

        public bool Conflict(Tournament tournament)
        { 
            if(tournament.Name!=Name)
            {
                return false;
            }

            return tournament.DateStart < DateFinish && tournament.DateFinish > DateStart;
        }

    }
}
