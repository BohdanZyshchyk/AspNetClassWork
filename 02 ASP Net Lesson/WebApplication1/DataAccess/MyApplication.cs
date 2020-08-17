namespace WebApplication1.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WebApplication1.DataAccess.Initializer;
    using WebApplication1.Models;

    public class MyApplication : DbContext
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers  { get; set; }
        public DbSet<Game> Games { get; set; }
        public MyApplication()
            : base("name=GameConnectionString")
        {
            Database.SetInitializer(new GamesInitializer());
        }

    }

}