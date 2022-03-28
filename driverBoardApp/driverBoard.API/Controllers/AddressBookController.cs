using System;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace driverBoard.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class AddressBookController : Controller
    {
        private readonly IAddressBookManager _addressBookManager;

        public AddressBookController(IAddressBookManager addressBookManager)
        {
            _addressBookManager = addressBookManager;
        }
        // GET
        [HttpGet("GetAll")]
        public IActionResult GetAllAddresses()
        {
            try
            {
                var data = _addressBookManager.GetAllAddresses();
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
        public IActionResult SaveAddress(AddressBook addressBook)
        {
            try
            {
                var data = _addressBookManager.SaveAddress(addressBook);

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