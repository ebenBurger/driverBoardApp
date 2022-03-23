using System.Collections.Generic;
using System.Linq;
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
    }
}