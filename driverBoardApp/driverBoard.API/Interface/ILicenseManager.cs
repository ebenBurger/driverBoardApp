using System.Collections.Generic;
using driverBoard.API.Models;

namespace driverBoard.API.Interface
{
    public interface ILicenseManager
    {
        List<License> GetAllLicense();
    }
}