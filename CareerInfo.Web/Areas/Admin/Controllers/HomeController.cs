using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CareerInfo.Model;
using Microsoft.AspNetCore.Authorization;

namespace CareerInfo.Web.Areas.Admin.Controllers
{
     [Area("Admin")]
     [Authorize()]
     public class HomeController : Controller
     {
          ApplicationDbContext db = new ApplicationDbContext();

          //GET: /Admin/Home/Index
          public IActionResult Index()
          {
               #region Dashboard Item Count 

               ViewData["courseCount"] = db.Courses.Count();
               ViewData["schoolCount"] = db.Schools.Count();
               ViewData["userCount"] = db.ApplicationUsers.Count(e => e.UserName != "admin@careerinfo.com.ng");
               ViewData["requestCount"] = db.Requests.Count();
               ViewData["reviewCount"] = db.Reviews.Count();
               #endregion

               return View();
          }

          protected override void Dispose(bool disposing)
          {
               db.Dispose();
               base.Dispose(disposing);
          }

     }
}