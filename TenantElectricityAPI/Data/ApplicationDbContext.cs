using Microsoft.EntityFrameworkCore;
using TenantElectricity.Shared.Models;

namespace TenantElectricityAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ElectricityConsumption> ElectricityConsumptions { get; set; }
    }
}
