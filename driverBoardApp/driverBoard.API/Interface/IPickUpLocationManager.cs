using System.Collections.Generic;
using System.Threading.Tasks;
using driverBoard.API.Models;

namespace driverBoard.API.Interface
{
    public interface IPickUpLocationManager
    {
        List<PickUpLocation> GetGetAllPickUpLocationsAll();
        Task<int> SavePickUpLocation(PickUpLocation pickUpLocation);
    }
}