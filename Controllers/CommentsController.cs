using iranAttractions.data;
using iranAttractions.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iranAttractions.Controllers
{

    
    public class CommentsController : Controller
    {
        private readonly MyDbContext _db;

        public CommentsController(MyDbContext context)
        {
            _db = context;
        }
        public IActionResult DisplayComments()
        {
            var comment = _db.Comment.Where(c => c.State == 0).Include(s => s.Sightseeings).ThenInclude(c => c.City).Include(u=>u.Users).ToList();


            return View(comment);
        }

        public IActionResult DeleteComments(int id)
        {
            var comment = _db.Comment.Find(id);
            comment.State = 2;
            _db.Entry(comment).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("DisplayComments");
        }

        public IActionResult Edit(int id )
        {
            var comment = _db.Comment.Include(s => s.Sightseeings).ThenInclude(c => c.City).Include(u => u.Users).FirstOrDefault(s=>s.Id==id);

            return View(comment);

        }
        public IActionResult EditComments(Comment comment)
        {
            var com = _db.Comment.Include(s => s.Sightseeings).ThenInclude(c => c.City).Include(u => u.Users).FirstOrDefault(c => c.Id == comment.Id);
            com.Description = comment.Description;
            _db.Entry(com).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("DisplayComments");

        }

        public IActionResult ConfirmComments(int id)
        {
            var comment = _db.Comment.Find(id);
            comment.State = 1;
            _db.Entry(comment).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("DisplayComments");
        }
    }
}
