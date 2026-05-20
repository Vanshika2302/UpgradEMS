using Microsoft.AspNetCore.Mvc;
using UpGradEMS.DAL.Data;
using UpGradEMS.DAL.Models;

namespace UpGradEMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParticipantController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ParticipantController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public IActionResult Register(string email, Guid eventId)
        {
            var record = new ParticipantEventDetails
            {
                ID = Guid.NewGuid(),
                ParticipantEmailId = email,
                EventId = eventId,
                IsAttended = false
            };

            _context.ParticipantEvents.Add(record);
            _context.SaveChanges();

            return Ok(record);
        }

        [HttpGet("{email}")]
        public IActionResult GetRegistered(string email)
        {
            var data = _context.ParticipantEvents
                .Where(p => p.ParticipantEmailId == email)
                .ToList();

            return Ok(data);
        }
    }
}