using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace driverBoard.API.Models
{
    public class DriverAppContext : DbContext
    {
        public DriverAppContext(DbContextOptions options) : base(options) { }

        public DbSet<AddressBook> AddressBooks { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<PickUpLocation> PickUpLocations { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }
}
