using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using driverBoard.API.Interface;
using driverBoard.API.Models;

namespace driverBoard.API.Managers
{
    public class AddressBookManager : IAddressBookManager
    {

        private readonly DriverAppContext _context;

        public AddressBookManager(DriverAppContext context)
        {
            _context = context;
        }
        public List<AddressBook> GetAllAddresses()
        {
            var address = _context.AddressBooks.ToList();
            return address;
        }

        public async Task<int> SaveAddress(AddressBook addressBook)
        {
            try
            {
                _context.AddressBooks.Add(addressBook);
            }
            catch (Exception e)
            {
                throw;
            }

            await _context.SaveChangesAsync();
            return addressBook.AddressBookId;
        }
    }
}