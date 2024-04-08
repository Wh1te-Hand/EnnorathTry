using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Models
{
    public class Match
    {
        public List<Player> _playerList;
        public DateOnly Date
        { get; }
        private readonly long _matchID;


        public Match(DateOnly date)
        {
            _playerList = new List<Player>();
            Date = date;
            _matchID = 1; //запрос к БД потом сделать
        }
    }
}
