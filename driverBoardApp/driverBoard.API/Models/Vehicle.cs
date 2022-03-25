using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace driverBoard.API.Models
{
    public class Vehicle
    {
        [ForeignKey("PickUpLocation")]
        public int VehicleId { get; set; }
        public string ModelVehicle { get; set; }
        public string MakeVehicle { get; set; }
        public string Location { get; set; }
        public int Odometer { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreated { get; set; }

        // Relationship setup
        public int OfficeId { get; set; }
        public Office Office { get; set; }
        public int PickUpLocationId { get; set; }
        public PickUpLocation PickUpLocation { get; set; }
    }
}
