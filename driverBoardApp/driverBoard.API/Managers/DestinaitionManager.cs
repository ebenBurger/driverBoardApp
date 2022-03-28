using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using driverBoard.API.Interface;
using driverBoard.API.Models;

namespace driverBoard.API.Managers
{
    public class DestinaitionManager : IDestinationManager

    {
        private readonly DriverAppContext _context;


        public DestinaitionManager(DriverAppContext context)
        {
            _context = context;
        }
        public List<Destination> GetAllDestination()
        {
            var destination = _context.Destinations.ToList();
            return destination;
        }

        public async Task<int> SaveDestination(Destination destination)
        {
            try
            {
                _context.Destinations.Add(destination);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            await _context.SaveChangesAsync();
            return destination.DestinationId;
        }
    }
}