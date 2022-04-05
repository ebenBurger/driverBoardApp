using System.Collections.Generic;
using System.Threading.Tasks;
using driverBoard.API.Models;

namespace driverBoard.API.Interface
{
    public interface IDriverManager
    {
        List<Driver> GetAll();
        Task<int> SaveDriver(Driver driver);
        Driver GetDriverById(int driverId);
        Task<Driver> UpdateDriverDetails(Driver driver);
    }
}