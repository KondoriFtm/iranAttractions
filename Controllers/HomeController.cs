using iranAttractions.data;
using iranAttractions.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace iranAttractions.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private  MyDbContext _db;
        public HomeController(ILogger<HomeController> logger, MyDbContext myDb)
        {
            _logger = logger;
            _db = myDb;
        }

        public IActionResult DisplayBoxes()
        {
            var cms = _db.Comment.ToList();
            return View();
        }

        public IActionResult Search()
        {
            return View();
        }


        public IActionResult Login()
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
