using System;

namespace driverBoard.API.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string ModelVehicle { get; set; }
        public string MakeVehicle { get; set; }
        public string Location { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        // Relationship setup
        public int OfficeId { get; set; }
        public Office Office { get; set; }
    }
}
