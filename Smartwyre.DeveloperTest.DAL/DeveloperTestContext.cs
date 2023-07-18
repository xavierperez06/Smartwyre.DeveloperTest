using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using Smartwyre.DeveloperTest.Core.Data.Models;

namespace Smartwyre.DeveloperTest.DAL
{
    public class DeveloperTestContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Rebate> Rebates { get; set; }

        public DeveloperTestContext(DbContextOptions<DeveloperTestContext> options) : base(options) { }

        public void ConfigureServices(IServiceCollection services) 
        {
            services.AddScoped<DeveloperTestContext>();
            services.AddSingleton<DeveloperTestContext>();
            services.AddDbContext<DeveloperTestContext>(opts => opts.UseSqlServer("DeveloperTest.DB"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(ConfigureProducts);
            modelBuilder.Entity<Rebate>(ConfigureRebates);
        }

        #region Configurations

        private void ConfigureProducts(EntityTypeBuilder<Product> product)
        {
            product.HasKey(p => p.Id);

            product.Property(p => p.Identifier)
                .IsRequired();

            product.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("decimal(6,2)");

            product.Property(p => p.Uom);

            product.Property(p => p.SupportedIncentives);

        }

        private void ConfigureRebates(EntityTypeBuilder<Rebate> rebates)
        {
            // Rebates config
        }

        #endregion
    }
}