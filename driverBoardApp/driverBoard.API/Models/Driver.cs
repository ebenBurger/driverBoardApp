using System;
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
        public Office Office { get; set; }

    }
}