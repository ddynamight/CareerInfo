using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CareerInfo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;

namespace CareerInfo.Web.Areas.Admin.Controllers
{
     [Area("Admin")]
     [Route("Admin/Reviews/")]
     [Authorize()]
     public class ReviewsController : Controller
     {
          ApplicationDbContext db = new ApplicationDbContext();

          public async Task<IActionResult> Index()
          {
               return View(await db.Reviews.Include(e => e.ApplicationUser).ToListAsync());
          }

          [HttpPost]
          public async Task<IActionResult> Create(Review review)
          {
               if (ModelState.IsValid)
               {
                    db.Reviews.Add(review);
                    db.Entry(review).State = EntityState.Added;
                    await db.SaveChangesAsync();
               }

               return RedirectToAction("Index");
          }

          protected override void Dispose(bool disposing)
          {
               db.Dispose();
               base.Dispose(disposing);
          }
     }
}