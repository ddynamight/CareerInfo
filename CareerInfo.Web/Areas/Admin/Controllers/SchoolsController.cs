using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CareerInfo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace CareerInfo.Web.Areas.Admin.Controllers
{
     [Area("Admin")]
     [Route("Admin/Schools/")]
     [Authorize()]
     public class SchoolsController : Controller
     {

          ApplicationDbContext db = new ApplicationDbContext();

          public async Task<IActionResult> Index()
          {
               #region DDL Stuff

               ViewData["stateDdl"] = new string[] { "Select a State", "Abia", "Adamawa", "Akwa Ibom", "Anambra", "Bauchi", "Bayelsa", "Benue", "Borno", "Cross River", "Delta", "Ebonyi", "Edo", "Ekiti", "Enugu", "Gombe", "Imo", "Jigawa", "Kaduna", "Kano", "Katsina", "Kebbi", "Kogi", "Kwara", "Lagos", "Nasarawa", "Niger", "Ogun", "Ondo", "Osun", "Oyo", "Plateau", "Rivers", "Sokoto", "Taraba", "Yobe", "Zamfara", "F.C.T" };

               #endregion

               return View(await db.Schools.ToListAsync());
          }

          [HttpPost]
          public async Task<IActionResult> Create(IFormCollection collection)
          {
               School school = new School();

               school.Name = collection["Name"];
               school.Description = collection["Description"];
               school.Address = collection["Address"];
               school.Email = collection["Email"];
               school.State = collection["State"];

               school.Tagname = school.Name.ToLower().Replace(" ", "-");

               if (ModelState.IsValid)
               {
                    db.Schools.Add(school);
                    db.Entry(school).State = EntityState.Added;
                    await db.SaveChangesAsync();
               }

               return RedirectToAction("Index");
          }

          [HttpGet("Edit/{tag}")]
          public async Task<IActionResult> Edit(string tag)
          {
               #region DDL Stuff

               ViewData["stateDdl"] = new string[] { "Select a State", "Abia", "Adamawa", "Akwa Ibom", "Anambra", "Bauchi", "Bayelsa", "Benue", "Borno", "Cross River", "Delta", "Ebonyi", "Edo", "Ekiti", "Enugu", "Gombe", "Imo", "Jigawa", "Kaduna", "Kano", "Katsina", "Kebbi", "Kogi", "Kwara", "Lagos", "Nasarawa", "Niger", "Ogun", "Ondo", "Osun", "Oyo", "Plateau", "Rivers", "Sokoto", "Taraba", "Yobe", "Zamfara", "F.C.T" };

               #endregion

               return View(await db.Schools.SingleAsync(e => e.Tagname.Equals(tag)));
          }


          [HttpPost("Edit/{tag}")]
          public async Task<IActionResult> Edit(School school, string tag)
          {
               #region DDL Stuff

               ViewData["stateDdl"] = new string[] { "Select a State", "Abia", "Adamawa", "Akwa Ibom", "Anambra", "Bauchi", "Bayelsa", "Benue", "Borno", "Cross River", "Delta", "Ebonyi", "Edo", "Ekiti", "Enugu", "Gombe", "Imo", "Jigawa", "Kaduna", "Kano", "Katsina", "Kebbi", "Kogi", "Kwara", "Lagos", "Nasarawa", "Niger", "Ogun", "Ondo", "Osun", "Oyo", "Plateau", "Rivers", "Sokoto", "Taraba", "Yobe", "Zamfara", "F.C.T" };

               #endregion

               if (ModelState.IsValid)
               {
                    db.Schools.Attach(school);
                    db.Entry(school).State = EntityState.Modified;
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