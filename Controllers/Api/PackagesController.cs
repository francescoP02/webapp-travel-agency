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
        public IActionResult Get(string? search)
        {
            List<TravelPackage> packages;
            if (search != null && search != "")
            {
                packages = _db.TravelPackages.Where(package => package.Name.Contains(search) || package.Description.Contains(search)).ToList();
            }
            else
            {
                packages = _db.TravelPackages.ToList();
            }
            return Ok(packages);
        }

        [HttpGet("{id}")]
        public IActionResult Show(int id)
        {
            TravelPackage package = _db.TravelPackages.Where(p => p.Id == id).FirstOrDefault();

            if (package == null)
            {
                return NotFound();
            }
            return Ok(package);
        }
    }
}
