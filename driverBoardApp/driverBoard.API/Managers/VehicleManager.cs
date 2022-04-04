using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.EntityFrameworkCore;

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
            var vehicle = _context.Vehicles
                .Where(a => a.IsActive == true)
                .Include(a => a.Office)
                // .Include(b => b.Drivers)
                .ToList();
            return vehicle;
        }

        public async Task<int> SaveVehicle(Vehicle vehicle)
        {
            try
            {
                vehicle.DateCreated = Convert.ToDateTime(DateTime.Now.ToLocalTime()
                        .ToString(System.Globalization.CultureInfo.InvariantCulture));
                    vehicle.DateCreated = vehicle.DateCreated;
                    _context.Vehicles.Add(vehicle);
            }
            catch (Exception err)
            {
                throw;
            }

            await _context.SaveChangesAsync();
            return vehicle.VehicleId;
        }

        public Vehicle GetVehicleById (int vehicleId)
        {
            try
            {
                var data = _context.Vehicles.Single(a => a.VehicleId == vehicleId);
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Vehicle> UpdateVehicleDetails(Vehicle vehicle)
        {
            try
            {
                if (vehicle.VehicleId == 0)
                {
                    throw new Exception("Invalid Vehicle ID");
                }

                _context.Vehicles.Update(vehicle);
                await _context.SaveChangesAsync();
                return vehicle;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}