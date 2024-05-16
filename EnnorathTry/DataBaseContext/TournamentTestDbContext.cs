using EnnorathTry.DTOs;
using EnnorathTry.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnnorathTry.DataBaseContext
{
    public class TournamentTestDbContext:DbContext
    {
        public DbSet<TournamentDTO> Tournaments { get; set; }

        public string dbPath;

        public TournamentTestDbContext(DbContextOptions options):base(options)
        {
            var folder = Environment.SpecialFolder.ApplicationData;
            var path = Environment.GetFolderPath(folder);
            dbPath = System.IO.Path.Join(path, "tournament.db");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
       => options.UseSqlite($"Data Source={dbPath}");
    }

   
}
