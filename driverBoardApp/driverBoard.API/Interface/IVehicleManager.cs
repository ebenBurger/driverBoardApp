using System.Collections.Generic;
using driverBoard.API.Models;

namespace driverBoard.API.Interface
{
    public interface IVehicleManager
    {
        List<Vehicle> GetAllVehicles();
    }
}