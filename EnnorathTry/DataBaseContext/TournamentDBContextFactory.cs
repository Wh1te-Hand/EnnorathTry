using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.DataBaseContext
{
    public class TournamentDBContextFactory
    {
        private readonly string _connectionString;

        public TournamentDBContextFactory(string connectionString) 
        {
            _connectionString=connectionString;
        }

        public TournamentTestDbContext CreateDbContext()
        {
            DbContextOptions contextOptions = new DbContextOptionsBuilder().UseSqlite(_connectionString).Options;

            //   return new TournirDBContext(contextOptions);
            return new TournamentTestDbContext(contextOptions);
        }
    }
}
