using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.EntityFrameworkCore;

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
            var contact = _context.Contacts
                .Where(a => a.IsActive == true)
                .Include(b => b.Office)
                .ToList();
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

        public Contact GetContactById(int contactId)
        {
            try
            {
                var data = _context.Contacts
                    .Include(a => a.Office)
                    .Single(b => b.ContactId == contactId);
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Contact> UpdateContactDetails(Contact contact)
        {
            try
            {
                if (contact.ContactId == 0)
                {
                    throw new Exception("Invalid Contact Id");
                }

                _context.Contacts.Update(contact);
                await _context.SaveChangesAsync();
                return contact;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}