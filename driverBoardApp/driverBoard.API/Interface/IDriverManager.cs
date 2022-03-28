using System.Collections.Generic;
using System.Threading.Tasks;
using driverBoard.API.Models;

namespace driverBoard.API.Interface
{
    public interface IDriverManager
    {
        List<Driver> GetAll();
        Task<int> SaveDriver(Driver driver);
    }
}