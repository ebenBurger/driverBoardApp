using System;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace driverBoard.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    
    
    public class DriverController : Controller
    {
        private readonly IDriverManager _driverManager;

        public DriverController(IDriverManager driverManager)
        {
            _driverManager = driverManager;
        }
        
        //Get
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            try
            {
                var data = _driverManager.GetAll();
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
        public IActionResult SaveDriver(Driver driver)
        {
            try
            {
                var data = _driverManager.SaveDriver(driver);
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

        [HttpGet("Get/{driverId}")]
        public IActionResult GetById(int driverId)
        {
            try
            {
                var data = _driverManager.GetDriverById(driverId);
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
        public IActionResult UpdateDriver(Driver driver)
        {
            try
            {
                var data = _driverManager.UpdateDriverDetails(driver);

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