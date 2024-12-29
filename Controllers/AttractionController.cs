using iranAttractions.data;
using iranAttractions.Models;
using iranAttractions.Services;
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
            var sightseeings =  _db.sightseeing
                                   .Include(s=>s.parts)
                                   .FirstOrDefault(s => s.Id == id);
            var hotels = _db.Hotels.Where(H=>H.cityId==sightseeings.CityId).ToList();
            
            List<HotelDistancesViewModel> hotelDistances = new List<HotelDistancesViewModel>();
            foreach(var hotel in hotels )
            {
                double dis = DistanceCalculator.CalculateDistance(sightseeings.lat, sightseeings.lon, hotel.lat, hotel.lon);
                dis =  Math.Round(dis, 5);
                hotelDistances.Add(new HotelDistancesViewModel() { distance = dis,Hotel=hotel });
            }

            hotelDistances = hotelDistances.OrderBy(h => h.distance).ToList();

            var resturants = _db.Resturants.Where(H => H.cityId == sightseeings.CityId).ToList();

            List<ResturantDistancesViewModel> ResturantDistances = new List<ResturantDistancesViewModel>();
            foreach (var resturant in resturants)
            {
                double dis = DistanceCalculator.CalculateDistance(sightseeings.lat, sightseeings.lon, resturant.lat, resturant.lon);
                dis = Math.Round(dis, 5);
                ResturantDistances.Add(new ResturantDistancesViewModel() { distance = dis, resturant = resturant });
            }

            ResturantDistances = ResturantDistances.OrderBy(h => h.distance).ToList();
            var comments = _db.Comment.Where(c=>c.SightseeingId == id&&c.State==1).Include(c=>c.Users).ToList();
            if (!comments.Any()) { comments = null; }
            var pictures = _db.Pictures.Where(p=>p.SightseeingId==id && p.state==1).ToList();
            if (!pictures.Any()) { pictures = null; }
            SightseeingViewModel model = new SightseeingViewModel()
            {
                Comments = comments,
                Pictures= pictures,
                sightseeing=sightseeings,
                Hot_Dis = hotelDistances,
                Res_Dis = ResturantDistances
            };
           

            return View(model);




            //var sightseeing =  _db.sightseeing.Where(s => s.CityId == id).Include(s => s.Comments).Include(s => s.parts).FirstOrDefaultAsync(); 
            //if (sightseeing == null) { return NotFound(); }
        }

        [HttpPost]
        [Authorize]
        //it most done with admin
        //so it must be placed in admin controller
        //and add a Role Admin To it

        public IActionResult AddPicture(int Id, IFormFile Picture)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

           
                if (Picture != null && Picture.Length > 0)
                {
                    var fileName = Path.GetFileNameWithoutExtension(Picture.FileName);
                    var extension = Path.GetExtension(Picture.FileName);
                    var uniqueFileName = $"{fileName}_{System.Guid.NewGuid()}{extension}";
                    var path = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", uniqueFileName);
                    if (!Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "uploads")))
                    {
                        Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "uploads"));
                    }
                    using (var stream = new FileStream(path, FileMode.Create)) {Picture.CopyTo(stream); }

                    Picture pic = new Picture()
                    {
                        FilePath = uniqueFileName,
                        dateImported = DateTime.Now,
                        likecounts =0 ,
                        SightseeingId = Id,
                        UserPhonenumber = userId,
                        state=0
                 
                    };
                _db.Pictures.Add(pic);
                _db.SaveChanges();

                    return RedirectToAction("DisplayInfoes", new { id = Id });
                }
            return RedirectToAction("DisplayInfoes", new { id =Id });

        }





        [HttpPost]
        [Authorize]
        public IActionResult AddComment(int SightseeingId, string Description, string UserName ,string picurl)
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
                    Sightseeings = sightseeing,
                    picurl = picurl
                };

                _db.Add(com);
                _db.SaveChanges();
            }

            return RedirectToAction("DisplayInfoes", new { id = SightseeingId });

        }

    }
}





