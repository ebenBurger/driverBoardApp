using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace driverBoard.API.Models
{
    public class License
    {
        [Key]
        public int LicenseId { get; set; }
        public bool CodeA { get; set; }
        public bool CodeA1 { get; set; }
        public bool CodeB { get; set; }
        public bool CodeC1 { get; set; }
        public bool CodeC { get; set; }
        public bool CodeEB { get; set; }
        public bool CodeEC1 { get; set; }
        public bool CodeEC { get; set; }

        public int DriverID { get; set; }
        public ICollection<Driver> Drivers { get; set; }
    }
}