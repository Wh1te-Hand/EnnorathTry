using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.DataBaseContext
{
    public class TournamentDesignTimeDBContextFactory : IDesignTimeDbContextFactory<TournamentTestDbContext>
    {
        public TournamentTestDbContext CreateDbContext(string[] args)
        {
            DbContextOptions contextOptions= new DbContextOptionsBuilder().UseSqlite("Data Source=tournament.db").Options;

            return new TournamentTestDbContext(contextOptions);
        }
    }
}
