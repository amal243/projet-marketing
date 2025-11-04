using gestion_marketing.Models;
using Microsoft.EntityFrameworkCore;

namespace gestion_marketing.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // === Définition des tables (DbSet) ===
        public DbSet<Campagne> Campagnes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Canal> Canaux { get; set; }
        public DbSet<PublicCible> PublicsCibles { get; set; }
        public DbSet<IndicateurPerformance> IndicateursPerformance { get; set; }
        public DbSet<Suggestion> Suggestions { get; set; }
        public DbSet<HistoriqueAction> HistoriqueActions { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<ServiceMarketing> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // === Relation Many-to-Many entre Campagne et Client ===
            modelBuilder.Entity<Campagne>()
                .HasMany(c => c.Clients)
                .WithMany(c => c.Campagnes)
                .UsingEntity(j => j.ToTable("CampagneClients")); //  Nom de la table d'association
        }


    }
}
