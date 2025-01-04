using iranAttractions.data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace iranAttractions.Controllers
{
    [Authorize(policy: "Admin")]


    public class UserController : Controller
    {
        private readonly MyDbContext _db;
        public UserController(MyDbContext context)
        {
            _db = context;
        }

        public IActionResult DisplayUsers()
        {
            var users  = _db.User.ToList();
            return View(users);
        }

        public IActionResult DeleteUSer(string phonenumber)
        {
            var user = _db.User.SingleOrDefault(u => u.Phonenumber == phonenumber);
            _db.User.Remove(user);
            _db.SaveChanges();
            return RedirectToAction("DisplayUsers");
        }

        public IActionResult SearrchUser()
        {
            return RedirectToAction();
        }
    }
}
