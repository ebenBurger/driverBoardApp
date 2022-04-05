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
        public bool CodeA { get; set; }
        public bool CodeA1 { get; set; }
        public bool CodeB { get; set; }
        public bool CodeC1 { get; set; }
        public bool CodeC { get; set; }
        public bool CodeEB { get; set; }
        public bool CodeEC1 { get; set; }
        public bool CodeEC { get; set; }
        public DateTime DateCreated { get; set; }
        
        public int OfficeId { get; set; }
        public  Office Office { get; set; }

    }
}
