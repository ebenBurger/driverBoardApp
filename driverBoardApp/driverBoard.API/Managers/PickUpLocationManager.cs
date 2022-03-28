using System.Collections.Generic;
using System.Linq;
using driverBoard.API.Interface;
using driverBoard.API.Models;

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
    }
}