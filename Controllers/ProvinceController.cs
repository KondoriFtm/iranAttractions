using iranAttractions.Models;
using Microsoft.AspNetCore.Mvc;

namespace iranAttractions.Controllers
{
    public class ProvinceController : Controller
    {
        public IActionResult DisplayProvince()
        {
            return View();
        }

        public IActionResult Search()
        {
            return RedirectToAction();
        }


    }
}
