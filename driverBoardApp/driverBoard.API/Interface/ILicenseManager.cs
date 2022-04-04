using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using License = driverBoard.API.Models.License;

namespace driverBoard.API.Interface
{
    public interface ILicenseManager
    {
        List<License> GetAllLicense();
        Task<int> SaveLicense(License license);
    }
}