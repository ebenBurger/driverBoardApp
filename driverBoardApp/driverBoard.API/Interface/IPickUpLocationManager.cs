using System.Collections.Generic;
using driverBoard.API.Models;

namespace driverBoard.API.Interface
{
    public interface IPickUpLocationManager
    {
        List<PickUpLocation> GetGetAllPickUpLocationsAll();
    }
}