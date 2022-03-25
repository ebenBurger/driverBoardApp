using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace driverBoard.API.Models
{
    public class Destination
    {
        [ForeignKey("PickUpLocation")]
        public int DestinationId { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int Weight { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Volume { get; set; }
        public bool IsComplete { get; set; }

        
        public PickUpLocation PickUpLocation { get; set; }
        
        public AddressBook AddressBook { get; set; }
    }
}