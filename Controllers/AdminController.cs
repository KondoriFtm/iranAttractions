using Microsoft.AspNetCore.Mvc;

namespace iranAttractions.Controllers
{
  
    public class AdminController : Controller
    {
        public IActionResult admin()
        {
            return View();
        }
    }
}
