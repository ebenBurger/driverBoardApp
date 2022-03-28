using System;

namespace driverBoard.API.Models
{
    public class Package
    {
        public int PackageId { get; set; }
        public DateTime CollectionDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Volume { get; set; }
        public bool IsComplete { get; set; }

        public Destination Destination { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}