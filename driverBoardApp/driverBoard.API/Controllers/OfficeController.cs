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
        
        //Get
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
    }
}