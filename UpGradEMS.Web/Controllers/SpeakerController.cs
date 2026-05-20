using Microsoft.AspNetCore.Mvc;
using UpGradEMS.DAL.Data;
using UpGradEMS.DAL.Models;

public class SpeakerController : Controller
{
    private readonly AppDbContext _context;

    public SpeakerController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        return View(_context.Speakers.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(SpeakerDetails s)
    {
        _context.Speakers.Add(s);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }

    public IActionResult Delete(Guid id)
    {
        var s = _context.Speakers.Find(id);

        if (s != null)  
        {
            _context.Speakers.Remove(s);
            _context.SaveChanges();
        }

        return RedirectToAction("Index");
    }
}