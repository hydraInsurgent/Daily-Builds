using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RoutingCoreMVC.Models;

namespace RoutingCoreMVC.Controllers
{
    [Route("Home")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        [HttpGet("/")]
        [HttpGet("Index")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet("Details/{id?}")]
        public IActionResult Details(int id)
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpGet("~/About")]
        public string About(int id)
        {
            return "About() Action Method of HomeController";
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
