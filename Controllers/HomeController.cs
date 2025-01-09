using iranAttractions.data;
using iranAttractions.Models;
using iranAttractions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Diagnostics;

namespace iranAttractions.Controllers
{
    //controller for the main page
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

        //when the user searches the query is sent for this action first
        //it will search for query through the city names
        public IActionResult SearchResultCity(string query)
        {
            var resultCity = _db.City.SingleOrDefault(e => e.Name == query)
          ;
            var resultSightseeing = _db.sightseeing.Include(s=>s.City).Where(e => e.City.Name.Contains(query) || e.Name.Contains(query))
                .ToList();
            if (resultCity !=null) //if no city was available with this name 
                                    // try to serach through the sightseeings name
            {

                return RedirectToAction("DisplayProvince", "Province", new { ItemId = resultCity.Id });

            }

            return RedirectToAction("SearchResultSightseeing", new { query = query });


        }

        //search the query through the sightseeings name

        public IActionResult SearchResultSightseeing(string query)
        {
            var resultSightseeng = _db.sightseeing.Include(s => s.City)
                                                  .Where(e => e.City.Name.Contains(query) || e.Name.Contains(query))
                                                  .ToList();

            if (resultSightseeng.Any()) // Check if the list is not empty
            {
                return View(resultSightseeng);
            }
            else
            {
                ViewBag.searchresult = "نتیجه ای یافت نشد";
                return View(resultSightseeng);
            }
            return Content("نتیجه ای یافت نشد");
        }

       

       


       

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
