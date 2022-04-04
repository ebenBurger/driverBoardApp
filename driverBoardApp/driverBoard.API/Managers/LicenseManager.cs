using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<int> SaveLicense(License license)
        {
            try
            {
                _context.Licenses.Add(license);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            await _context.SaveChangesAsync();
            return license.LicenseId;
        }
    }
}