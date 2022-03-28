using System;
using System.Linq;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace driverBoard.API.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    
    
    public class PickUpLocationController : Controller
    {

        private readonly IPickUpLocationManager _pickUpLocationManager;

        public PickUpLocationController(IPickUpLocationManager pickUpLocationManager)
        {
            _pickUpLocationManager = pickUpLocationManager;
        }
        
        
        // GET
        [HttpGet("GetAll")]
        public IActionResult GetAllPickUpLocations()
        {
            try
            {
                var data = _pickUpLocationManager.GetGetAllPickUpLocationsAll();
                if (data == null)
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

        [HttpPost("Save")]
        public IActionResult SavePickUpLocation(PickUpLocation pickUpLocation)
        {
            try
            {
                var data = _pickUpLocationManager.SavePickUpLocation(pickUpLocation);

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