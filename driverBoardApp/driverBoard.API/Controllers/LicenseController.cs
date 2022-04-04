using System;
using driverBoard.API.Interface;
using Microsoft.AspNetCore.Mvc;

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
    }
}