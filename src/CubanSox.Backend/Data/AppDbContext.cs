using CubanSox.Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace CubanSox.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<BattingStat> BattingStats { get; set; }
        public DbSet<PitchingStat> PitchingStats { get; set; }

        public DbSet<BoxScore> BoxScores { get; set; }
        public DbSet<InningScore> InningScores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar relaciones para evitar ciclos en Game (Home vs Visitor)
            modelBuilder.Entity<Game>()
                .HasOne(g => g.HomeTeam)
                .WithMany()
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Game>()
                .HasOne(g => g.VisitorTeam)
                .WithMany()
                .HasForeignKey(g => g.VisitorTeamId)
                .OnDelete(DeleteBehavior.Restrict);


            // Cuando se borre un BoxScore, se borran sus entradas automáticamente
            modelBuilder.Entity<BoxScore>()
                .HasMany(b => b.Innings)
                .WithOne()
                .HasForeignKey(i => i.BoxScoreId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
