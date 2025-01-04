using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iranAttractions.Controllers
{
  
    public class AdminController : Controller
    {
        [Authorize(policy: "Admin")]

        public IActionResult admin()
        {
            return View();
        }
       
    }
}
