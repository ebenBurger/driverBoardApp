using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.EntityFrameworkCore;

namespace driverBoard.API.Managers
{
    public class OfficeManager : IOfficeManager
    {
        private readonly DriverAppContext _context;

        public OfficeManager(DriverAppContext context)
        {
            _context = context;
        }


        public List<Office> GetAll()
        {
            var office = _context.Offices
                .Include(a => a.Vehicles)
                .ToList();
            return office;
        }

        public async Task<int> SaveOffice(Office office)
        {
            try
            {
                office.DateCreated = Convert.ToDateTime(DateTime.Now.ToLocalTime()
                    .ToString(System.Globalization.CultureInfo.InvariantCulture));
                office.DateCreated = office.DateCreated;
                _context.Offices.Add(office);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            await _context.SaveChangesAsync();
            return office.OfficeId;
        }
    }
}