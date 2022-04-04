using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace driverBoard.API.Managers
{
    public class LicenseManager : ILicenseManager
    {
        private readonly DriverAppContext _context;

        public LicenseManager(DriverAppContext context)
        {
            _context = context;
        }


        public List<License> GetAllLicense()
        {
            var license = _context.Licenses
                .Include(a => a.Drivers)
                .ToList();

            return license;
        }
    }
}