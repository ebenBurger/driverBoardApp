using System.Collections.Generic;
using System.Threading.Tasks;
using driverBoard.API.Models;

namespace driverBoard.API.Interface
{
    public interface IOfficeManager
    {
        List<Office> GetAll();
        Task<int> SaveOffice(Office office);
    }
}