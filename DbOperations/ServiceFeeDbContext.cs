using Microsoft.EntityFrameworkCore;
using service_fee_backend;

namespace DbOperation
{
    public class ServiceFeeDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=service-fee;Username=postgres;Password=12345");
        }

        public DbSet<FeeCustomer> FeeCustomers{get;set;}
        public DbSet<WritedCustomer> WritedCustomers{get;set;}
    }
}