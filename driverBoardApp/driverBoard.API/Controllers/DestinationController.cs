using System;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace driverBoard.API.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    
    
    public class DestinationController : Controller
    {

        private readonly IDestinationManager _destinationManager;

        public DestinationController(IDestinationManager destinationManager)
        {
            _destinationManager = destinationManager;
        }
        
        // GET
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _destinationManager.GetAllDestination();
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
        
        //Save
        [HttpPost("Save")]
        public IActionResult SaveDestiniation(Destination destination)
        {
            try
            {
                var data = _destinationManager.SaveDestination(destination);
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