using CareerInfo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CareerInfo.Web.Controllers
{
     public class CoursesController : Controller
     {
          ApplicationDbContext db = new ApplicationDbContext();

          public async Task<IActionResult> Index(string tag)
          {
               if (tag != null)
               {
                    ViewData["search"] = tag + " Courses";

                    return View(await db.Courses.Include(c => c.Reviews).Include(c => c.SchoolCourses).ThenInclude(sc => sc.School).Where(e => e.Name.Contains(tag)).ToListAsync());
               }
               else
               {
                    return View(await db.Courses.Include(c => c.Reviews).Include(c => c.SchoolCourses).ThenInclude(sc => sc.School).ToListAsync());
               }
          }

          public async Task<IActionResult> Find(string tagOne, string tagTwo, string tagThree)
          {
               if (tagOne != null && tagTwo != null && tagThree != null)
               {
                    ViewData["search"] = "Available Courses";

                    return View(await db.Courses.Include(c => c.Reviews).Include(c => c.SchoolCourses).ThenInclude(sc => sc.School).Where(e => (e.Requirement.Jamb.Contains(tagOne) && e.Requirement.Jamb.Contains(tagTwo)) && e.Requirement.Jamb.Contains(tagThree)).ToListAsync());
               }
               else
               {
                    return View(await db.Courses.Include(c => c.Reviews).Include(c => c.SchoolCourses).ThenInclude(sc => sc.School).ToListAsync());
               }
               
          }

          public async Task<IActionResult> Details(string tag)
          {

               #region DDL Stuff

               ViewData["categoryDdl"] = new string[] { "Select Request Category", "Subjects for Course", "Financial Advice", "Profession/Industry", "Personal Skills", "Others" };

               #endregion

               ViewBag.RedirectUrl = "/Courses/Details/" + tag;
               ViewBag.CourseTag = tag;



               return View(await db.Courses.Include(c => c.Reviews).ThenInclude(c => c.ApplicationUser).Include(c => c.SchoolCourses).ThenInclude(sc => sc.School).Include(c => c.Requirement).Include(c => c.Profession).Include(c => c.Personality).SingleAsync(e => e.Tagname == tag));
          }

          protected override void Dispose(bool disposing)
          {
               db.Dispose();
               base.Dispose(disposing); 
          }
     }
}