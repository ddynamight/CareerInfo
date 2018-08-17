using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CareerInfo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace CareerInfo.Web.Areas.Admin.Controllers
{
     [Area("Admin")]
     [Route("Admin/Users/")]
     [Authorize()]
     public class UsersController : Controller
     {
          ApplicationDbContext db = new ApplicationDbContext();

          public async Task<IActionResult> Index()
          {
               return View(await db.ApplicationUsers.Where(e => !e.UserName.Equals("admin@careerinfo.com.ng ")).ToListAsync());
          }

          [HttpPost]
          public async Task<IActionResult> Create(ApplicationUser user)
          {
               if (ModelState.IsValid)
               {
                    db.ApplicationUsers.Add(user);
                    db.Entry(user).State = EntityState.Added;
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