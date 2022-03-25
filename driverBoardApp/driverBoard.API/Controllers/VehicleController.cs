using System;
using driverBoard.API.Interface;
using driverBoard.API.Managers;
using driverBoard.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace driverBoard.API.Controllers
{
    
    [Route("[controller]")]
    [ApiController]
    
    public class VehicleController : Controller
    {
        private readonly IVehicleManager _vehicleManager;

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
        
        //Save
        [HttpPost("Save")]
        public IActionResult SaveVehicle(Vehicle vehicle)
        {
            try
            {
                var data = _vehicleManager.SaveVehicle(vehicle);
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
        
        //getBy Id
        [HttpGet("get/{vehicleId}")]
        public IActionResult GetById(int vehicleId)
        {
            try
            {
                var data = _vehicleManager.GetVehicleById(vehicleId);
                if (data == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        
        //updated vehicle
        [HttpPost("Update")]
        public IActionResult UpdateVehicle(Vehicle vehicle)
        {
            try
            {
                var data = _vehicleManager.UpdateVehicleDetails(vehicle);
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