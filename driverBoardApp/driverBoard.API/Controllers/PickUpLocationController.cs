using System;
using System.Linq;
using driverBoard.API.Interface;
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
    }
}