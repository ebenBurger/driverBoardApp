using System;
using System.ComponentModel.DataAnnotations;

namespace driverBoard.API.Models
{
    public class PickUpLocation
    {
        [Key]
        public int PickUpLocationId { get; set; }
        public DateTime CollectionDate { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Volume { get; set; }
        public bool IsComplete { get; set; }

        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        
        public Office Office { get; set; }

        public Vehicle Vehicle { get; set; }

        public Destination Destination { get; set; }
    }
}