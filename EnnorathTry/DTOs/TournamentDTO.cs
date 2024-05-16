using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.DTOs
{
    public  class TournamentDTO
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int CountPlayers { get; set; }
        public DateOnly DateStart { get; set; }
        public DateOnly DateFinish { get; set; }
    }
}
