using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace driverBoard.API.Models
{
    public class Office
    {
        [Key]
        public int OfficeId { get; set; }
        public string Building { get; set; }
        public string OfficePark { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Provence { get; set; }
        public string Location { get; set; }
        public string TellNumber { get; set; }
        public DateTime DateCreated { get; set; }

        // relationship added- Navigation property
        public Vehicle Vehicles { get; set; }
        public AddressBook AddressBooks { get; set; }
    }
}