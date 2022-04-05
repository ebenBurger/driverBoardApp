using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.AspNetCore.Components.Authorization;
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

        public Driver GetDriverById(int driverId)
        {
            try
            {
                var data = _context.Drivers.Single(a => a.DriverId == driverId);
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Driver> UpdateDriverDetails(Driver driver)
        {
            try
            {
                if (driver.DriverId == 0)
                {
                    throw new Exception("Invalid Driver Id");
                }

                _context.Drivers.Update(driver);
                await _context.SaveChangesAsync();
                return driver;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}