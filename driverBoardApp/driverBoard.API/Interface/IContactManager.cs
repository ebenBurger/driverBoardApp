using System.Collections.Generic;
using System.Threading.Tasks;
using driverBoard.API.Models;

namespace driverBoard.API.Interface
{
    public interface IContactManager
    {
        List<Contact> GetAllContacts();
        Task<int> SaveContact(Contact contact);
        Contact GetContactById(int contactId);
        Task<Contact> UpdateContactDetails(Contact contact);
    }
}