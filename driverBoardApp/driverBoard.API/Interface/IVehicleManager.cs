using System.Collections.Generic;
using System.Threading.Tasks;
using driverBoard.API.Models;

namespace driverBoard.API.Interface
{
    public interface IVehicleManager
    {
        List<Vehicle> GetAllVehicles();
        Task<int> SaveVehicle(Vehicle vehicle);
        Vehicle GetVehicleById (int vehicleId);
        Task<Vehicle> UpdateVehicleDetails(Vehicle vehicle);
    }
}