using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CareerInfo.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace CareerInfo.Web.Controllers
{
     [Authorize()]
     public class RequestsController : Controller
     {
          ApplicationDbContext db = new ApplicationDbContext();

          public IActionResult Index()
          {
               return View();
          }

          public async Task<IActionResult> Create(IFormCollection collection)
          {
               Request request = new Request();
               var returnUrl = collection["returnUrl"];

               request.ApplicationUser = await db.ApplicationUsers.SingleAsync(e => e.UserName == User.Identity.Name);

               request.Date = DateTime.Now;
               request.Comment = collection["Comment"];
               request.Category = collection["Category"];

               if (ModelState.IsValid)
               {
                    db.Requests.Add(request);
                    db.Entry(request).State = EntityState.Added;
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