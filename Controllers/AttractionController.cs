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
        private readonly AttractionService _attractionService;
        public AttractionController(MyDbContext context, IWebHostEnvironment hostingEnvironment, AttractionService attractionService)
        {
            _hostingEnvironment = hostingEnvironment;
            _db = context;
            _attractionService = attractionService;
        }

        [HttpGet]
        public IActionResult DisplayInfoes(int id)
        {
            //find the sightseeing with the given Id
            var sightseeings =  _db.sightseeing
                                   .Include(s=>s.parts)
                                   .FirstOrDefault(s => s.Id == id);

            //extract all hotels and resturants in the city that the sightseeing is located
            var hotels = _db.Hotels.Where(H=>H.cityId==sightseeings.CityId).ToList();
            var resturants = _db.Resturants.Where(H => H.cityId == sightseeings.CityId).ToList();


            var hotelDistances = GetHotelDistances(sightseeings);
            var restaurantDistances = GetRestaurantDistances(sightseeings);

            //find all comments related to the desired sightseeing wich are confirmed(state=1)
            var comments = _db.Comment.Where(c=>c.SightseeingId == id&&c.State==1).Include(c=>c.Users).ToList();
            if (!comments.Any()) { comments = null; }

            //find all pictures related to the desired sightseeing wich are confirmed(state=1)
            var pictures = _db.Pictures.Where(p=>p.SightseeingId==id && p.state==1).ToList();
            if (!pictures.Any()) { pictures = null; }


            SightseeingViewModel model = new SightseeingViewModel()
            {
                Comments = comments,
                Pictures= pictures,
                sightseeing=sightseeings,
                Hot_Dis = hotelDistances,
                Res_Dis = restaurantDistances
            };
           

            return View(model);




            //var sightseeing =  _db.sightseeing.Where(s => s.CityId == id).Include(s => s.Comments).Include(s => s.parts).FirstOrDefaultAsync(); 
            //if (sightseeing == null) { return NotFound(); }
        }

        //method to get the distance between the all hotels
        //in the the sightseeing city and the sightseeing
        private List<HotelDistancesViewModel> GetHotelDistances(Sightseeing sightseeing)
        { 
            var hotels = _db.Hotels.Where(h => h.cityId == sightseeing.CityId).ToList();
            return _attractionService.CalculateHotelDistances(sightseeing, hotels); 
        }

        //method to get the distance between the all resturants
        //in the the sightseeing city and the sightseeing
        private List<ResturantDistancesViewModel> GetRestaurantDistances(Sightseeing sightseeing) 
        { 
            var restaurants = _db.Resturants.Where(r => r.cityId == sightseeing.CityId).ToList();
            return _attractionService.CalculateRestaurantDistances(sightseeing, restaurants);
        }

        [HttpPost]
        [Authorize]

        //method for save the user upluaded picture to database
        public IActionResult AddPicture(int Id, IFormFile Picture)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

                
                if (Picture != null && Picture.Length > 0)
                {

                    //extract the name of the uploaded picture
                    var fileName = Path.GetFileNameWithoutExtension(Picture.FileName);
                    var extension = Path.GetExtension(Picture.FileName);

                    //tryies to create a unique name using the picture name
                    var uniqueFileName = $"{fileName}_{System.Guid.NewGuid()}{extension}";

                    //and create the path for it in uploads folder
                    var path = Path.Combine(_hostingEnvironment.WebRootPath, "uploads", uniqueFileName);
                    if (!Directory.Exists(Path.Combine(_hostingEnvironment.WebRootPath, "uploads")))
                    {
                        Directory.CreateDirectory(Path.Combine(_hostingEnvironment.WebRootPath, "uploads"));
                    }
                    using (var stream = new FileStream(path, FileMode.Create)) {Picture.CopyTo(stream); }

                    //create a new instance of Picture 
                    //and save it to database
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
        //method for save the user upluaded comment to database
        public IActionResult AddComment(int SightseeingId, string Description, string UserName ,string picurl)
        {
            //find the userId of the logined user using the 
            //informations saved in the cookies
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();

            //whitch sightseeing to add the comment for it
            var sightseeing = _db.sightseeing.Include(s => s.Comments).ThenInclude(c => c.Users).FirstOrDefault(s => s.Id == SightseeingId);
            var user = _db.User.FirstOrDefault(u => u.Phonenumber == userId);
            if (user == null)
            {
                ViewBag.message = "the user is not found";
            }
            else
            {
                //create a new instance of Comment 
                //and save it to database
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
          

            [HttpPost]
            public IActionResult Like(int pictureId)
            {
                var picture = _db.Pictures.Find(pictureId);
                if (picture != null)
                {
                    picture.likecounts++;
                    _db.SaveChanges();
                }
                return Json(new { likes = picture.likecounts });
            }

            [HttpPost]
            public IActionResult Unlike(int pictureId)
            {
                var picture = _db.Pictures.Find(pictureId);
                if (picture != null && picture.likecounts > 0)
                {
                    picture.likecounts--;
                    _db.SaveChanges();
                }
                return Json(new { likes = picture.likecounts });
            }
         

    }
}





