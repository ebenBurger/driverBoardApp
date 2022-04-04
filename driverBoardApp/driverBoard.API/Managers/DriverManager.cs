using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.EntityFrameworkCore;

namespace driverBoard.API.Managers
{
    public class DriverManager : IDriverManager

    {
        private readonly DriverAppContext _context;

        public DriverManager(DriverAppContext context)
        {
            _context = context;
        }


        public List<Driver> GetAll()
        {
            var driver = _context.Drivers
                .Include(b => b.Office)
                .ToList();
            return driver;
        }

        public async Task<int> SaveDriver(Driver driver)
        {
            try
            {
                driver.DateCreated = Convert.ToDateTime(DateTime.Now.ToLocalTime()
                    .ToString(System.Globalization.CultureInfo.InvariantCulture));
                driver.DateCreated = driver.DateCreated;
                _context.Drivers.Add(driver);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            await _context.SaveChangesAsync();
            return driver.DriverId;
        }
    }
}