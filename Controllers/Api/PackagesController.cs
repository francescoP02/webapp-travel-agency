using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/packages")]
    [ApiController]
    public class PackagesController : Controller
    {

        private TravelAgencyContext _db;

        public PackagesController()
        {
            _db = new TravelAgencyContext();
        }
        [HttpGet]
        public IActionResult Get()
        {
            IQueryable<TravelPackage> Packages = _db.TravelPackages;
            return Ok(Packages.ToList());
        }
    }
}
