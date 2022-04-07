using System.ComponentModel.DataAnnotations;
using driverBoard.API.Authentication;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace driverBoard.API.Models
{
    public class DriverAppContext : IdentityDbContext<ApplicationUser>
    {
        public DriverAppContext(DbContextOptions options) : base(options) { }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

    }
}
