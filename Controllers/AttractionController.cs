using iranAttractions.data;
using iranAttractions.Models;
using iranAttractions.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace iranAttractions.Controllers
{
    public class AttractionController : Controller
    {
        private readonly MyDbContext _db;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public AttractionController(MyDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
            _db = context;
        }

        public IActionResult DisplayInfoes(int id)
        {
            var sightseeing =  _db.sightseeing
                                   .Include(s=>s.parts)
                                   .FirstOrDefault(s => s.Id == id);

            var comments = _db.Comment.Where(c=>c.SightseeingId == id).Include(c=>c.Users).ToList();
            var pictures = _db.Pictures.Where(p=>p.SightseeingId==id).ToList();

            SightseeingViewModel model = new SightseeingViewModel()
            {
                Comments = comments,
                Pictures= pictures
            };
            if (sightseeing == null)
            {
                return NotFound();
            }

            return View(model);




            //var sightseeing =  _db.sightseeing.Where(s => s.CityId == id).Include(s => s.Comments).Include(s => s.parts).FirstOrDefaultAsync(); 
            //if (sightseeing == null) { return NotFound(); }
        }

        [HttpPost]
        //it most done with admin
        //so it must be placed in admin controller
        //and add a Role Admin To it

        public IActionResult AddBook(PIctureViewModel model)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            if (ModelState.IsValid)
            {
                if (model.Picture != null && model.Picture.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(model.Picture.FileName);
                    var extension = Path.GetExtension(model.Picture.FileName);
                    var uniqueFileName = $"{fileName}_{System.Guid.NewGuid()}{extension}";
                    var path = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", uniqueFileName);
                    if (!Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "uploads")))
                    {
                        Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "uploads"));
                    }
                    using (var stream = new FileStream(path, FileMode.Create)) { model.Picture.CopyTo(stream); }

                    Picture pic = new Picture()
                    {
                        FilePath = path,
                        dateImported = DateTime.Now,
                        likecounts =0 ,
                        SightseeingId = model.SightseeingId,
                        UserPhonenumber = userId
                 
                    };

                    return RedirectToAction();
                }
            }

            return View();
        }

    

        [HttpPost]
        [Authorize]
        public IActionResult AddComment(int SightseeingId, string Description, string UserName)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            var sightseeing = _db.sightseeing.Include(s => s.Comments).ThenInclude(c => c.Users).FirstOrDefault(s => s.Id == SightseeingId);
            var user = _db.User.FirstOrDefault(u => u.Phonenumber == userId);
            if (user == null)
            {
                ViewBag.message = "the user is not found";
            }
            else
            {
                var com = new Comment
                {
                    Date = DateTime.Now,
                    State = 0,
                    SightseeingId = SightseeingId,
                    Description = Description,
                    UserPhonenumber = userId,
                    Users = user,
                    Sightseeings = sightseeing
                };

                _db.Add(com);
                _db.SaveChanges();
            }

            return RedirectToAction("DisplayInfoes", new { id = SightseeingId });

        }

    }
}





