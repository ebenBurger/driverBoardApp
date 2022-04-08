using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using driverBoard.API.Interface;
using driverBoard.API.Managers;
using driverBoard.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace driverBoard.API.Controllers
{
    // [Authorize]
    [Microsoft.AspNetCore.Authorization.Authorize]
    [Route("[controller]")]
    [ApiController]

    /*public class VehicleController : Controller
    {
        private readonly IVehicleManager _vehicleManager;

        public VehicleController(IVehicleManager vehicleManager)
        {
            _vehicleManager = vehicleManager;
        }
        
        // GET
        [HttpGet("GetAll")]
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
                
                return Ok(data);
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
    }*/

    public class VehicleController : Controller
    {
        private readonly DriverAppContext _context;

        public VehicleController(DriverAppContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vehicle>>> GetVehicles()
        {
            return await _context.Vehicles.ToListAsync();
        }
    } 
}