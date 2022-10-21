using Microsoft.AspNetCore.Mvc;
using webapp_travel_agency.Models;

namespace webapp_travel_agency.Controllers.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MessageController : Controller
    {

        private TravelAgencyContext _db;

        public MessageController()
        {
            _db = new TravelAgencyContext();
        }

        [HttpPost("{id}")]
        public IActionResult Send(int id, [FromBody] Message message)
        {
            message.TravelPackageId = id;
            _db.Messages.Add(message);
            _db.SaveChanges();
            return Ok();
        }
    }
}
