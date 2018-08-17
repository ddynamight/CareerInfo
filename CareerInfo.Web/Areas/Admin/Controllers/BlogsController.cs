using CareerInfo.Model;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design.Internal;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace CareerInfo.Web.Areas.Admin.Controllers
{
     [Area("Admin")]
     [Route("Admin/Blogs/")]
     [Authorize()]
     public class BlogsController : Controller
     {
          ApplicationDbContext db = new ApplicationDbContext();

          private IHostingEnvironment _environment;

          public BlogsController(IHostingEnvironment environment)
          {
               _environment = environment;
          }

          public async Task<IActionResult> Index()
          {
               return View(await db.Blogs.ToListAsync());
          }


          [HttpPost]
          public async Task<IActionResult> Create(IFormCollection formCollection, IFormFile file)
          {
               Blog blog = new Blog();
               blog.Title = formCollection["Title"];
               blog.Description = formCollection["Description"];
               blog.Article = formCollection["Article"];
               blog.Status = "Published";

               blog.Tagname = blog.Title.Replace(" ", "-").ToLower() + "-" + Guid.NewGuid().ToString().ToLower().Substring(0, 10).Replace(" ", "-");


               string imgGuid = Guid.NewGuid().ToString().ToLower().Substring(0, 10);
               var directory = Path.Combine(_environment.WebRootPath, "BlogsImages");

               if (file.Length > 0)
               {
                    if (!Directory.Exists(directory))
                    {
                         Directory.CreateDirectory(directory);
                    }

                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.GetFullPath(directory);

                    using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create, FileAccess.ReadWrite))
                    {
                         await file.CopyToAsync(fileStream);
                         blog.Image = fileName;
                    }


                    if (ModelState.IsValid)
                    {
                         db.Blogs.Add(blog);
                         db.Entry(blog).State = EntityState.Added;
                         await db.SaveChangesAsync();
                    }
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