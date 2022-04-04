using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using driverBoard.API.Interface;
using driverBoard.API.Models;

namespace driverBoard.API.Managers
{
    public class ContactManager : IContactManager
    {

        private readonly DriverAppContext _context;

        public ContactManager(DriverAppContext context)
        {
            _context = context;
        }
        
        public List<Contact> GetAllContacts()
        {
            var contact = _context.Contacts.ToList();
            return contact;
        }

        public async Task<int> SaveContact(Contact contact)
        {
            try
            {
                contact.DateCreated = Convert.ToDateTime(DateTime.Now.ToLocalTime()
                    .ToString(System.Globalization.CultureInfo.InvariantCulture));
                contact.DateCreated = contact.DateCreated;
                _context.Contacts.Add(contact);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            await _context.SaveChangesAsync();
            return contact.ContactId;
        }
    }
}