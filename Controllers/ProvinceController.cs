using iranAttractions.data;
using iranAttractions.Models;
using iranAttractions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iranAttractions.Controllers
{
    public class ProvinceController : Controller
    {
        private readonly MyDbContext _db;

        public ProvinceController(MyDbContext db)
        {
            _db = db;
        }

        public IActionResult DisplayProvince(int ItemId)
        {
            // دریافت اطلاعات استان همراه با جاذبه‌ها، هتل‌ها و رستوران‌ها
            var province = _db.City
                .Include(c => c.sightseeings)
                .Include(c => c.hotels)
                .Include(c=>c.resturants)
                .FirstOrDefault(c => c.Id == ItemId);

            if (province == null)
            {
                return NotFound(); // اگر استان پیدا نشود
            }

           

            return View(province);
        }
    }
}
