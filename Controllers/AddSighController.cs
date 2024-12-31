using iranAttractions.data;
using iranAttractions.Models;
using iranAttractions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace iranAttractions.Controllers
{
    public class AddSighController : Controller
    {
        private readonly MyDbContext _db;
        public AddSighController(MyDbContext context)
        {
            _db = context;
        }
        public IActionResult displayAdd()
        {
            AddSightViewModel sight = new AddSightViewModel()
            {
                CityLists = new List<SelectListItem> {
                new SelectListItem { Value = "1", Text = "اصفهان" },
                    new SelectListItem { Value = "2", Text = "شیراز" },
                    new SelectListItem { Value = "3", Text = "تهران" },
                }
            };
            return View(sight);
        }

        [HttpPost]
        public IActionResult AddSight(AddSightViewModel sight)
        {
           var city =  _db.City.SingleOrDefault(c => c.Id == sight.CityId);
            Sightseeing newSight = new Sightseeing()
            {
                Name = sight.Name,
                Description = sight.Description,
                lat = sight.lat,
                lon = sight.lon,
                CityId = sight.CityId,
                City = city

            };

            _db.sightseeing.Add(newSight);
            _db.SaveChanges();
            return RedirectToAction("displayAdd");
        }
    }
}
