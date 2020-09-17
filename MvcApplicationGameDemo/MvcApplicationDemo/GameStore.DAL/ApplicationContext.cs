using GameStore.DAL.Entities;
using GameStore.DAL.Initializer;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace GameStore.DAL
{
    public class ApplicationContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Game> Games { get; set; }
        public ApplicationContext()
            : base("name=GameConnectionString")
        {
            Database.SetInitializer(new GamesInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Game>()
            .HasOptional<Developer>(s => s.Developer)
            .WithMany()
            .WillCascadeOnDelete(true);
            modelBuilder.Entity<Game>()
            .HasOptional<Genre>(s => s.Genre)
            .WithMany()
            .WillCascadeOnDelete(true);
        }
        public static ApplicationContext Create()
        {
            return new ApplicationContext();
        }
    }
}
