using CareerInfo.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CareerInfo.Web.Controllers
{
     public class HomeController : Controller
     {
          ApplicationDbContext db = new ApplicationDbContext();

          public async Task<IActionResult> Index()
          {
               ViewData["latestNews"] = await db.News.OrderByDescending(e => e.Date).FirstOrDefaultAsync();
               ViewData["latestBlog"] = await db.Blogs.OrderByDescending(e => e.Date).FirstOrDefaultAsync();

               return View();
          }


          protected override void Dispose(bool disposing)
          {
               db.Dispose();
               base.Dispose(disposing);
          }
     }
}