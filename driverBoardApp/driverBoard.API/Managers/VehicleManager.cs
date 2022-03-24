using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using driverBoard.API.Interface;
using driverBoard.API.Models;

namespace driverBoard.API.Managers
{
    
    
    public class VehicleManager : IVehicleManager
    {
        
        private readonly DriverAppContext _context;

        public VehicleManager(DriverAppContext context)
        {
            _context = context;
        }
        public List<Vehicle> GetAllVehicles()
        {
            var vehicle = _context.Vehicles.ToList();
            return vehicle;
        }

        public async Task<int> SaveVehicle(Vehicle vehicle)
        {
            try
            {
                if (vehicle.Id != 0)
                {
                    _context.Vehicles.Update(vehicle);
                }
                else
                {
                    vehicle.DateCreated = Convert.ToDateTime(DateTime.Now.ToLocalTime()
                        .ToString(System.Globalization.CultureInfo.InvariantCulture));
                    vehicle.DateCreated = vehicle.DateCreated;
                    _context.Vehicles.Add(vehicle);
                }
            }
            catch (Exception err)
            {
                throw;
            }

            await _context.SaveChangesAsync();
            return vehicle.Id;
        }
    }
}