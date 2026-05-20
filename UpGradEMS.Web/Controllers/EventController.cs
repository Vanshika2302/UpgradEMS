using Microsoft.AspNetCore.Mvc;
using UpGradEMS.DAL.Models;
using UpGradEMS.DAL.Repository;
using UpGradEMS.DAL.Data;

namespace UpGradEMS.Web.Controllers
{
    public class EventController : Controller
    {
        private readonly IEventRepository _repo;
        private readonly AppDbContext _context;

        public EventController(IEventRepository repo, AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        public IActionResult Index()
        {
            var events = _repo.GetAll()
                .Where(e => e.Status == "Active")
                .ToList();

            return View(events);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(EventDetails ev)
        {
            if (ModelState.IsValid)
            {
                _repo.Add(ev);
                return RedirectToAction("Index");
            }
            return View(ev);
        }

        public IActionResult Join(Guid id)
        {
            var email = HttpContext.Session.GetString("UserEmail");

            if (string.IsNullOrEmpty(email))
                return RedirectToAction("Login", "Account");

            var record = new ParticipantEventDetails
            {
                ID = Guid.NewGuid(),
                EventId = id,
                ParticipantEmailId = email,
                IsAttended = false
            };

            _context.ParticipantEvents.Add(record);
            _context.SaveChanges();

            return RedirectToAction("MyEvents", "Participant");
        }

        public IActionResult Delete(Guid id)
        {
            _repo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}