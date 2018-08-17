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
     [Route("Admin/Requests/")]
     [Authorize()]
     public class RequestsController : Controller
     {
          ApplicationDbContext db = new ApplicationDbContext();

          public async Task<IActionResult> Index()
          {
               return View(await db.Requests.Include(e => e.ApplicationUser).ToListAsync());
          }


          [HttpPost]
          public async Task<IActionResult> Create(Request request)
          {
               if (ModelState.IsValid)
               {
                    db.Requests.Add(request);
                    db.Entry(request).State = EntityState.Added;
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