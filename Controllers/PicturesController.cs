using Microsoft.AspNetCore.Mvc;

namespace iranAttractions.Controllers
{

    public class PicturesController : Controller
    {
        public IActionResult DisplayPictures()
        {
            return View();
        }


    }
}
