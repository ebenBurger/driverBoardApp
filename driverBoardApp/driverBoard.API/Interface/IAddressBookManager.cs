using System.Collections.Generic;
using System.Threading.Tasks;
using driverBoard.API.Models;

namespace driverBoard.API.Interface
{
    public interface IAddressBookManager
    {
        List<AddressBook> GetAllAddresses();
        Task<int> SaveAddress(AddressBook addressBook);
    }
}