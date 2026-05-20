using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using UpGradEMS.DAL.Data;
using UpGradEMS.DAL.Models;
using System.Linq;

namespace UpGradEMS.Web.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly AppDbContext _context;

        public ParticipantController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult MyEvents()
        {
            var email = HttpContext.Session.GetString("UserEmail");

            var events = _context.ParticipantEvents
                .Where(e => e.ParticipantEmailId == email)
                .ToList();

            return View(events);
        }

        public IActionResult MarkAttendance(Guid id)
        {
            var record = _context.ParticipantEvents.Find(id);

            if (record != null)
            {
                record.IsAttended = true;
                _context.SaveChanges();
            }

            return RedirectToAction("MyEvents");
        }
    }
}