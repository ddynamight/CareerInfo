using CareerInfo.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CareerInfo.Web.Areas.Admin.Controllers
{
     [Area("Admin")]
     [Route("Admin/Courses/")]
     [Authorize()]
     public class CoursesController : Controller
     {
          ApplicationDbContext db = new ApplicationDbContext();

          private IHostingEnvironment _environment;

          public CoursesController(IHostingEnvironment environment)
          {
               _environment = environment;
          }

          public async Task<IActionResult> Index()
          {
               #region Ddl Stuff

               ViewData["schoolId"] = new MultiSelectList(db.Schools.OrderBy(e => e.Name), "Id", "Name");

               #endregion

               return View(await db.Courses.Include(c => c.SchoolCourses).ThenInclude(SchoolCourse => SchoolCourse.School).ToListAsync());
          }

          [HttpPost]
          public async Task<IActionResult> Create(IFormCollection collection, IFormFile file)
          {
               IList<School> schools = await db.Schools.ToListAsync();

               // Declaring Entities
               Course course = new Course();
               Personality personality = new Personality();
               Profession profession = new Profession();
               Requirement requirement = new Requirement();

               // Collecting Course Values
               course.Name = collection["Name"];
               course.Description = collection["Description"];
               course.Details = collection["Details"];
               course.Tagname = course.Name.ToLower().Replace(" ", "-").Replace("/", "-") + "-" + Guid.NewGuid().ToString().Substring(0, 8);

               // Collecting Other Entity Values
               personality.Details = collection["Personality.Details"];
               profession.Details = collection["Profession.Details"];
               requirement.Alevel = collection["Requirement.Alevel"];
               requirement.Jamb = collection["Requirement.Jamb"];
               requirement.JambScore = Int32.Parse(collection["Requirement.JambScore"]);
               requirement.Olevel = collection["Requirement.Olevel"];
               requirement.PostUtme = Int32.Parse(collection["Requirement.PostUtme"]);

               var schoolsCount = collection["Schools"].Count();
               var selectedValues = collection["Schools"].ToString().Split(',');
               var schoolCourses = new SchoolCourse[selectedValues.Count()];

               // Mapping Related Entities
               course.Personality = personality;
               course.Profession = profession;
               course.Requirement = requirement;

               string imgGuid = Guid.NewGuid().ToString().ToLower().Substring(0, 10);
               var directory = Path.Combine(_environment.WebRootPath, "CoursesImages");

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
                         course.Image = fileName;
                    }

                    //course.Image = file.FileName;

                    for (int i = 0; i < selectedValues.Count(); i++)
                    {
                         var school = new SchoolCourse()
                         {
                              Course = course,
                              School = schools.Single(e => e.Id == Int32.Parse(selectedValues[i]))
                         };
                         schoolCourses[i] = school;
                         db.Entry(school).State = EntityState.Added;
                    }


                    if (ModelState.IsValid)
                    {
                         db.Courses.Add(course);
                         db.SchoolCourses.AddRange(schoolCourses);
                         db.Personalities.Add(course.Personality);
                         db.Professions.Add(course.Profession);
                         db.Requirements.Add(course.Requirement);
                         db.Entry(course).State = EntityState.Added;
                         db.Entry(course.Personality).State = EntityState.Added;
                         db.Entry(course.Profession).State = EntityState.Added;
                         db.Entry(course.Requirement).State = EntityState.Added;

                         await db.SaveChangesAsync();
                    }
               }

               return RedirectToAction("Index");
          }


          [HttpGet("Edit/{tag}")]
          public async Task<IActionResult> Edit(string tag)
          {
               #region Ddl Stuff

               ViewData["schoolId"] = new MultiSelectList(db.Schools.OrderBy(e => e.Name), "Id", "Name");

               #endregion

               return View(await db.Courses.Include(e => e.Personality).Include(e => e.Profession).Include(e => e.Requirement).SingleAsync(e => e.Tagname == tag));
          }

          [HttpPost("Edit/{tag}")]
          public async Task<IActionResult> Edit(Course course, string tag, IFormFile file)
          {

               string imgGuid = Guid.NewGuid().ToString().ToLower().Substring(0, 10);
               var directory = Path.Combine(_environment.WebRootPath, "CoursesImages");

               if (file != null && file.Length > 0)
               {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.GetFullPath(directory);

                    using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create, FileAccess.ReadWrite))
                    {
                         await file.CopyToAsync(fileStream);
                         course.Image = fileName;
                    }
               }

               if (ModelState.IsValid)
               {
                    db.Courses.Attach(course);
                    db.SchoolCourses.AttachRange(course.SchoolCourses);
                    db.Personalities.Attach(course.Personality);
                    db.Professions.Attach(course.Profession);
                    db.Requirements.Attach(course.Requirement);
                    db.Entry(course).State = EntityState.Modified;
                    db.Entry(course.Personality).State = EntityState.Modified;
                    db.Entry(course.Profession).State = EntityState.Modified;
                    db.Entry(course.Requirement).State = EntityState.Modified;
                    await db.SaveChangesAsync();

                    return RedirectToAction("Index");
               }

               return View(course);
          }


          protected override void Dispose(bool disposing)
          {
               db.Dispose();
               base.Dispose(disposing);
          }
     }
}