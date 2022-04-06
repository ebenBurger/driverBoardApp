using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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
                .Where(a => a.IsActive == true)
                .Include(a => a.Vehicles)
                .Include(b => b.Drivers)
                .Include(c=> c.Contacts)
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

        public Office GetOfficeById(int officeId)
        {
            try
            {
                var data = _context.Offices.Single(a => a.OfficeId == officeId);
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        public async Task<Office> UpdateOfficeDetails(Office office)
        {
            try
            {
                if (office.OfficeId == 0)
                {
                    throw new Exception("Invalid Office ID");
                }

                _context.Offices.Update(office);
                await _context.SaveChangesAsync();
                return office;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}