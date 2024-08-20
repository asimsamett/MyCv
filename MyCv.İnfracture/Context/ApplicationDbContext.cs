using Microsoft.EntityFrameworkCore;
using MyCv.Domain.Entities;
using MyCv.İnfracture.Configration;

namespace MyCv.İnfracture
{
    public class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// ApplicationDbContext
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }




        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            Console.WriteLine(optionsBuilder);
            optionsBuilder.UseSqlServer("Server=DESKTOP-B9VAHUE\\SQLEXPRESS;Database=MyCvDb;Trusted_Connection=True;TrustServerCertificate=True;");
        }




        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientFeatures> ClientFeatures { get; set; }




        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClientFeatures>()

                .HasOne(cf => cf.Client)
                .WithOne(c => c.ClientFeature)
                .HasForeignKey<ClientFeatures>(cf=>cf.ClientId);
                
            modelBuilder.ApplyConfiguration(new ClientConfiguration());
            modelBuilder.ApplyConfiguration(new ClientFeaturesConfiguration());

            
        }
    }
}
