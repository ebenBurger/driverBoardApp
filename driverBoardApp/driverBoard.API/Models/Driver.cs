using System.ComponentModel.DataAnnotations;

namespace driverBoard.API.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Location { get; set; }

        public License License { get; set; }

        public int VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }

    }
}