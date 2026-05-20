using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UpGradEMS.DAL.Data;
using UpGradEMS.DAL.Models;

public class SessionController : Controller
{
    private readonly AppDbContext _context;

    public SessionController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var sessions = _context.Sessions.ToList();
        return View(sessions);
    }

    public IActionResult Create()
    {
        ViewBag.Events = new SelectList(_context.Events, "EventId", "EventName");
        ViewBag.Speakers = new SelectList(_context.Speakers, "SpeakerId", "SpeakerName");

        return View();
    }

    [HttpPost]
    public IActionResult Create(SessionInfo session)
    {
        if (session.SessionStart >= session.SessionEnd)
        {
            ModelState.AddModelError("", "Start time must be less than End time");
        }

        if (ModelState.IsValid)
        {
            session.SessionId = Guid.NewGuid();

            _context.Sessions.Add(session);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        ViewBag.Events = new SelectList(_context.Events, "EventId", "EventName");
        ViewBag.Speakers = new SelectList(_context.Speakers, "SpeakerId", "SpeakerName");

        return View(session);
    }
}