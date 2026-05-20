using Microsoft.AspNetCore.Mvc;
using UpGradEMS.DAL.Data;
using UpGradEMS.DAL.Models;

namespace UpGradEMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EventController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var events = _context.Events.ToList();
            return Ok(events);
        }

        [HttpPost]
        public IActionResult Create(EventDetails ev)
        {
            ev.EventId = Guid.NewGuid();
            _context.Events.Add(ev);
            _context.SaveChanges();

            return Ok(ev);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var ev = _context.Events.Find(id);
            if (ev == null) return NotFound();

            _context.Events.Remove(ev);
            _context.SaveChanges();

            return Ok();
        }
    }
}