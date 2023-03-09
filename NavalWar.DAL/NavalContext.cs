using Microsoft.EntityFrameworkCore;
using NavalWar.DAL.Models;

namespace NavalWar.DAL
{
    public class NavalContext :  DbContext
    {
        public NavalContext(DbContextOptions<NavalContext> options) : base(options) {}

        public DbSet<Player> Players { get; set; }
        public DbSet<Session> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Player>()
                        .ToTable("Player")
                        .HasKey(x => x.Id);

            modelBuilder.Entity<Session>()
                        .ToTable("Session")
                        .HasKey(x => x.Id);
        }
    }
}
