using iranAttractions.data;
using iranAttractions.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iranAttractions.Controllers
{
    public class AlbumController : Controller
    {
        private readonly MyDbContext _db;

        public AlbumController(MyDbContext context)
        {
            _db = context;
        }

        public IActionResult PictureList(string searchQuery)
        {
            var query = _db.Pictures
                .Include(p => p.sightseeing)
                    .ThenInclude(s => s.City)
                .AsQueryable();

            // فیلتر براساس جستجو در نام جاذبه یا نام استان
            if (!string.IsNullOrWhiteSpace(searchQuery))
            {
                query = query.Where(p =>p.state==1 && (p.sightseeing.Name.Contains(searchQuery) || p.sightseeing.City.Name.Contains(searchQuery)) );
            }

            // ساخت ViewModel
            var pictureList = query
                .Select(p => new PictureListViewModel
                {
                    PictureId = p.Id,
                    AttractionId  = p.sightseeing.Id,
                    FilePath = p.FilePath,
                    SightseeingName = p.sightseeing.Name,
                    ProvinceName = p.sightseeing.City.Name,
                    DateImported = p.dateImported
                })
                .ToList();

            return View(pictureList);
        }
    
}
}
