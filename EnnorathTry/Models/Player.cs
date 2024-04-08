using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.Models
{
    public class Player
    {
        private int Id { get; }
        public string Name { get; set; }
        public string ClanTag { get; set; }

        public Player(string name, string clan="") 
        {
            Name = name;
            ClanTag = clan;
            Id = 1; //проработать на уровне БД
        }
    }
}
