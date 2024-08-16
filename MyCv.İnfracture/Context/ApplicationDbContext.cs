using Microsoft.EntityFrameworkCore;
using MyCv.Domain.Entities;
using MyCv.İnfracture.Configration;

namespace MyCv.İnfracture
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)

        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-B9VAHUE\\SQLEXPRESS;Database=MyCvDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientFeatures> ClientFeatures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ClientFeaturesConfiguration());

            
        }
    }
}
