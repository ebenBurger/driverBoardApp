using System;
using System.Linq;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace driverBoard.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class OfficeController : Controller
    {
        private readonly IOfficeManager _officeManager;

        public OfficeController(IOfficeManager officeManager)
        {
            _officeManager = officeManager;
        }
        
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _officeManager.GetAll();

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
        public IActionResult SaveOffice(Office office)
        {
            try
            {
                var data = _officeManager.SaveOffice(office);
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

        [HttpGet("Get/{officeId}")]
        public IActionResult GetById(int officeId)
        {
            try
            {
                var data = _officeManager.GetOfficeById(officeId);
                
                if (officeId == 0)
                {
                    return NotFound();
                }

                return Ok(data);

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpPost("Update")]
        public IActionResult UpdateOffice(Office office)
        {
            try
            {
                var data = _officeManager.UpdateOfficeDetails(office);
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