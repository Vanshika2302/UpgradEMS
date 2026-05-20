using Microsoft.AspNetCore.Mvc;
using UpGradEMS.DAL.Models;

public class AccountController : Controller
{
    private readonly UserRepository _repo;

    public AccountController(UserRepository repo)
    {
        _repo = repo;
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(UserInfo user)
    {
        if (ModelState.IsValid)
        {
            _repo.Register(user);
            return RedirectToAction("Login");
        }
        return View(user);
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string email, string password)
    {
        var user = _repo.Login(email, password);

        if (user != null)
        {
            HttpContext.Session.SetString("UserEmail", user.EmailId);
            HttpContext.Session.SetString("Role", user.Role);

            if (user.Role == "Admin")
                return RedirectToAction("Dashboard", "Admin");
            else
                return RedirectToAction("Dashboard", "Participant"); 
        }
        ViewBag.Error = "Invalid credentials";
        return View();
    }
}