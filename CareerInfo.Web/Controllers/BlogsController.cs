using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CareerInfo.Model;
using Microsoft.EntityFrameworkCore;

namespace CareerInfo.Web.Controllers
{
     public class BlogsController : Controller
     {
          ApplicationDbContext db = new ApplicationDbContext();

          public async Task<IActionResult> Index()
          {
               return View(await db.Blogs.ToListAsync());
          }

          public async Task<IActionResult> Details(string tag)
          {
               return View(await db.Blogs.SingleAsync(e => e.Tagname == tag));
          }


          protected override void Dispose(bool disposing)
          {
               db.Dispose();
               base.Dispose(disposing);
          }
     }
}