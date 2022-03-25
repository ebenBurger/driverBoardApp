using Microsoft.EntityFrameworkCore;

namespace driverBoard.API.Models
{
    public class DriverAppContext : DbContext
    {
        public DriverAppContext(DbContextOptions options) : base(options) { }

        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Office> Offices { get; set; }
    }
}
