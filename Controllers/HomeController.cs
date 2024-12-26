using iranAttractions.data;
using iranAttractions.Models;
using iranAttractions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public IActionResult Index()
        {
            var mainviewModel = new MainViewModel
            {
                Cities = _db .City.ToList(),
                sightseeings = _db.sightseeing.ToList()
            };
            return View(mainviewModel);
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
