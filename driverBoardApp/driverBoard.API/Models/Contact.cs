using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace driverBoard.API.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mobile { get; set; }
        public string Landline { get; set; }
        public string Email { get; set; }
        public string Building { get; set; }
        public string OfficePark { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }
        public string Provence { get; set; }

        public List<PickUpLocation> PickUpLocations { get; set; }
    }
}