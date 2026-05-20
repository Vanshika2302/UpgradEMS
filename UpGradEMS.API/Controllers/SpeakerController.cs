using Microsoft.AspNetCore.Mvc;
using UpGradEMS.DAL.Data;
using UpGradEMS.DAL.Models;

namespace UpGradEMS.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpeakerController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SpeakerController(AppDbContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.Speakers.ToList());
        }

        [HttpPost]
        public IActionResult Add(SpeakerDetails speaker)
        {
            speaker.SpeakerId = Guid.NewGuid();

            _context.Speakers.Add(speaker);
            _context.SaveChanges();

            return Ok(speaker);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var sp = _context.Speakers.Find(id);
            if (sp == null) return NotFound();

            _context.Speakers.Remove(sp);
            _context.SaveChanges();

            return Ok();
        }
    }
}