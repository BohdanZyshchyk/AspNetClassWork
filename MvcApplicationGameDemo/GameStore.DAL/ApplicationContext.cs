using GameStore.DAL.Entities;
using GameStore.DAL.Initializer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameStore.DAL
{
    public class ApplicationContext:DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public ApplicationContext()
            : base("name=GameConnectionString")
        {
            Database.SetInitializer(new GamesInitializer());
        }
    }
}
