using System;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace driverBoard.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    
    public class ContactController : Controller
    {

        private readonly IContactManager _contactManager;

        public ContactController(IContactManager contactManager)
        {
            _contactManager = contactManager;
        }
        // GET
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _contactManager.GetAllContacts();
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost("Save")]
        public IActionResult SaveContact(Contact contact)
        {
            try
            {
                var data = _contactManager.SaveContact(contact);
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpGet("Get/{contactId}")]
        public IActionResult GetById(int contactId)
        {
            try
            {
                var data = _contactManager.GetContactById(contactId);
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }

        [HttpPost("Update")]
        public IActionResult UpdateContact(Contact contact)
        {
            try
            {
                var data = _contactManager.UpdateContactDetails(contact);
                if (data == null)
                {
                    return NotFound();
                }

                return Ok(data);
            }
            catch (Exception e)
            {
                return Problem(e.Message);
            }
        }
    }
}