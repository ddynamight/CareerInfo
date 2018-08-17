using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CareerInfo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CareerInfo.Web.Controllers
{
     [Authorize()]
     public class ReviewsController : Controller
     {
          ApplicationDbContext db = new ApplicationDbContext();

          public IActionResult Index()
          {
               return View();
          }

          public async Task<IActionResult> Create(IFormCollection collection)
          {
               Review review = new Review();
               var returnUrl = collection["returnUrl"];
               var courseTag = collection["courseTag"];

               review.ApplicationUser = await db.ApplicationUsers.SingleAsync(e => e.UserName == User.Identity.Name);
               review.Course = await db.Courses.SingleAsync(e => e.Tagname.Equals(courseTag));


               review.Date = DateTime.Now;
               review.Comment = collection["Comment"];
               review.Rating = (short)Int32.Parse(collection["Rating"]);



               if (ModelState.IsValid)
               {
                    db.Reviews.Add(review);
                    db.Entry(review).State = EntityState.Added;
                    await db.SaveChangesAsync();
               }

               return Redirect(returnUrl);
          }

          protected override void Dispose(bool disposing)
          {
               db.Dispose();
               base.Dispose(disposing);
          }
     }
}