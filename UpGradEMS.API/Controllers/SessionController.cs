using Microsoft.AspNetCore.Mvc;
using UpGradEMS.DAL.Data;
using UpGradEMS.DAL.Models;

namespace UpGradEMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SessionController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddSession(SessionInfo session)
        {
            session.SessionId = Guid.NewGuid();

            _context.Sessions.Add(session);
            _context.SaveChanges();

            return Ok(session);
        }

        [HttpGet("{eventId}")]
        public IActionResult GetSessions(Guid eventId)
        {
            var sessions = _context.Sessions
                .Where(s => s.EventId == eventId)
                .ToList();

            return Ok(sessions);
        }

        [HttpPut("assign-speaker")]
        public IActionResult AssignSpeaker(Guid sessionId, Guid speakerId)
        {
            var session = _context.Sessions.Find(sessionId);
            if (session == null) return NotFound();

            session.SpeakerId = speakerId;

            _context.SaveChanges();

            return Ok("Speaker assigned");
        }
    }
}