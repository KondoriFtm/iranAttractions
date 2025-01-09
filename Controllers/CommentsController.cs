using iranAttractions.data;
using iranAttractions.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace iranAttractions.Controllers
{

    [Authorize(policy: "Admin")]

    //controller for managing the 
    //uplaoded comments sent for admin 

    //state =0 :comment is not confirmed by admin
    //state =1 :comment is confirmed by admin 
    //state = 2 : comment is deleted
    public class CommentsController : Controller
    {
        private readonly MyDbContext _db;

        public CommentsController(MyDbContext context)
        {
            _db = context;
        }

        //display the admin comment manager 
        //with the neede informations sent for desired view
        public IActionResult DisplayComments()
        {
            var comment = _db.Comment.Where(c => c.State == 0).Include(s => s.Sightseeings).ThenInclude(c => c.City).Include(u=>u.Users).ToList();
             

            return View(comment);
        }
        

        //delete a comment bu Id
        public IActionResult DeleteComments(int id)
        {
            var comment = _db.Comment.Find(id);
            comment.State = 2;
            _db.Entry(comment).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("DisplayComments");
        }

        //display the edit comment page
        //by sending the needed informations for it
        public IActionResult Edit(int id )
        {
            var comment = _db.Comment.Include(s => s.Sightseeings).ThenInclude(c => c.City).Include(u => u.Users).FirstOrDefault(s=>s.Id==id);

            return View(comment);

        }

        //edit comment by Id
        public IActionResult EditComments(Comment comment)
        {
            var com = _db.Comment.Include(s => s.Sightseeings).ThenInclude(c => c.City).Include(u => u.Users).FirstOrDefault(c => c.Id == comment.Id);
            com.Description = comment.Description;
            _db.Entry(com).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("DisplayComments");

        }

        //confirm a comment by Id
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
