using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CareerInfo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;

namespace CareerInfo.Web.Areas.Admin.Controllers
{
     [Area("Admin")]
     [Route("Admin/News/")]
     [Authorize()]
     public class NewsController : Controller
     {
          ApplicationDbContext db = new ApplicationDbContext();

          private IHostingEnvironment _environment;

          public NewsController(IHostingEnvironment environment)
          {
               _environment = environment;
          }

          public async Task<IActionResult> Index()
          {
               return View(await db.News.ToListAsync());
          }

          [HttpPost]
          public async Task<IActionResult> Create(IFormCollection formCollection, IFormFile file)
          {
               News news = new News();
               news.Title = formCollection["Title"];
               news.Description = formCollection["Description"];
               news.Article = formCollection["Article"];
               news.Status = "Published";

               news.Tagname = news.Title.Replace(" ", "-").ToLower() + "-" + Guid.NewGuid().ToString().ToLower().Substring(0, 10).Replace(" ", "-");


               string imgGuid = Guid.NewGuid().ToString().ToLower().Substring(0, 10);
               var directory = Path.Combine(_environment.WebRootPath, "NewsImages");

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
                         news.Image = fileName;
                    }


                    if (ModelState.IsValid)
                    {
                         db.News.Add(news);
                         db.Entry(news).State = EntityState.Added;
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