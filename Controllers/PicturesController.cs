using iranAttractions.data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iranAttractions.Controllers
{
    [Authorize(policy: "Admin")]


    public class PicturesController : Controller
    {
        private readonly MyDbContext _db;

        public PicturesController(MyDbContext context)
        {
            _db = context;
        }
        public IActionResult DisplayPictures()
        {
            var pictures  = _db.Pictures.Where(p=>p.state==0).Include(p=>p.sightseeing).ThenInclude(p=>p.City).ToList();
            return View(pictures);
        }

        public IActionResult Confirm_pic(int Id)
        {
            var pic = _db.Pictures.Find(Id);
            pic.state = 1;
            _db.SaveChanges();
            return RedirectToAction("DisplayPictures");
        }
        public IActionResult Delete_pic(int Id)
        {
            var pic = _db.Pictures.Find(Id);
            pic.state = 2;
            _db.SaveChanges();
            return RedirectToAction("DisplayPictures");

        }

    }
}
