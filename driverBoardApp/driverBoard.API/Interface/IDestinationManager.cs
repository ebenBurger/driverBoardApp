using System.Collections.Generic;
using System.Threading.Tasks;
using driverBoard.API.Models;

namespace driverBoard.API.Interface
{
    public interface IDestinationManager
    {
        List<Destination> GetAllDestination();

        Task<int> SaveDestination(Destination destination);
    }
}