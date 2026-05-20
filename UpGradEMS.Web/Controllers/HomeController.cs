using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UpGradEMS.Web.Models;
using UpGradEMS.DAL.Repository;        
using UpGradEMS.DAL.Models;          

namespace UpGradEMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IEventRepository _repo;   

        public HomeController(ILogger<HomeController> logger, IEventRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        public IActionResult Index()
        {
            var events = _repo.GetAll();   
            return View(events);           
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}