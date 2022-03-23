using Microsoft.EntityFrameworkCore;

namespace driverBoard.API.Models
{
    public class DriverAppContext : DbContext
    {
        public DriverAppContext(DbContextOptions options) : base(options) { }

        DbSet<Vehicle> Vehicles { get; set; }
    }
}
