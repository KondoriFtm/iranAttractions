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

        public IActionResult privacy()
        {
            var mainviewModel = new MainViewModel
            {
                Cities = _db.City.ToList(),
                sightseeings = _db.sightseeing.ToList()
            };
            return View(mainviewModel);
        }
        public IActionResult DisplayBoxes()
        {
            var mainviewModel = new MainViewModel
            {
                Cities = _db.City.ToList(),
                sightseeings = _db.sightseeing.ToList()
            };
            return View(mainviewModel);
        }
        [HttpPost]
        public IActionResult SearchResultCity(string query)
        {
            var resultCity = _db.City.Where(e => e.Name == query)
            .ToList();
            var resultSightseeing = _db.sightseeing.Include(s=>s.City).Where(e => e.City.Name.Contains(query) || e.Name.Contains(query))
                .ToList();
            if (resultCity.Count > 0)
            {

                return RedirectToAction("DisplayProvince", "Province", new { queryResult = resultCity });

            }

            return RedirectToAction("SearchResultSightseeing", new { query = query });


        }
        public IActionResult SearchResultSightseeing(string query)
        {
            var resultSightseeng = _db.sightseeing.Include(s=>s.City).SingleOrDefault(e => e.City.Name.Contains(query) || e.Name.Contains(query))
               ;
            if (resultSightseeng!=null)
            {
                return RedirectToAction("DisplayInfoes", "Attraction", new { id = resultSightseeng.Id });

            }
            return Content("نتیجه ای یافت نشد");

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
