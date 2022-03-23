using System;
using driverBoard.API.Interface;
using driverBoard.API.Managers;
using Microsoft.AspNetCore.Mvc;

namespace driverBoard.API.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    
    public class VehicleController : Controller
    {
        private IVehicleManager _vehicleManager;

        public VehicleController(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }
        
        // GET
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _vehicleManager.GetAllVehicles();
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