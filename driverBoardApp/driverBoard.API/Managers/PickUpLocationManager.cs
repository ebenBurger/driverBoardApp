using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace driverBoard.API.Managers
{
    public class PickUpLocationManager : IPickUpLocationManager
    {
        private readonly DriverAppContext _context;

        public PickUpLocationManager(DriverAppContext context)
        {
            _context = context;
        }
        

        public List<PickUpLocation> GetGetAllPickUpLocationsAll()
        {
            var pickUp = _context.PickUpLocations.ToList();
            return pickUp;
        }

        public async Task<int> SavePickUpLocation(PickUpLocation pickUpLocation)
        {
            try
            {
                _context.PickUpLocations.Add(pickUpLocation);
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            await _context.SaveChangesAsync();
            return pickUpLocation.PickUpLocationId;
        }
    }
}