using System;
using driverBoard.API.Interface;
using driverBoard.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace driverBoard.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class LicenseController : Controller
    {
        private readonly ILicenseManager _licenseManager;

        public LicenseController(ILicenseManager licenseManager)
        {
            _licenseManager = licenseManager;
        }
        
        // GET
        [HttpGet("GetAll")]
        public IActionResult GetAllLicenses()
        {
            try
            {
                var data = _licenseManager.GetAllLicense();

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
        public IActionResult SaveNewLicense(License license)
        {
            try
            {
                var data = _licenseManager.SaveLicense(license);
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