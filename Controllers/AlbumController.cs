using Microsoft.AspNetCore.Mvc;

namespace iranAttractions.Controllers
{
    public class AlbumController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
