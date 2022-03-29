using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace driverBoard.API.Models
{
    public class Vehicle
    {
        public int VehicleId { get; set; }
        public string ModelVehicle { get; set; }
        public string MakeVehicle { get; set; }
        public string Location { get; set; }
        public int Odometer { get; set; }
        public int Year { get; set; }
        public bool IsAvailable { get; set; }
        public bool? IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        
        public int OfficeId { get; set; }
        public  Office Office { get; set; }

        public ICollection<Driver> Drivers { get; set; }
    }
}
