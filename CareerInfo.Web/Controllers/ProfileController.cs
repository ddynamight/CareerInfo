using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CareerInfo.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using CareerInfo.Web.Models.ProfileViewModels;

namespace CareerInfo.Web.Controllers
{
     [Authorize()]
     public class ProfileController : Controller
     {
          ApplicationDbContext db = new ApplicationDbContext();

          public async Task<IActionResult> Index()
          {
               return View(await db.ApplicationUsers.SingleAsync(e => e.UserName == User.Identity.Name));
          }

          public async Task<IActionResult> Create()
          {
               #region DDL Stuff Here

               string[] countryArray = { "Select Country", "Cameroon", "England", "France", "Ghana", "Nigeria", "South Africa" };
               string[] sexArray = { "Select Sex", "Male", "Female" };
               string[] titleArray = { "Select Title", "Engr", "Dr", "Miss", "Mr", "Mrs", "Pharm", "Prof" };

               ViewData["ddlCountry"] = new SelectList(countryArray);
               ViewData["ddlTitle"] = new SelectList(titleArray);
               ViewData["ddlSex"] = new SelectList(sexArray);

               #endregion

               return View();
          }
          
          [HttpPost]
          public async Task<IActionResult> Create(AddDetailsViewModel model)
          {
               #region DDL Stuff Here

               string[] countryArray = { "Select Country", "Cameroon", "England", "France", "Ghana", "Nigeria", "South Africa" };
               string[] sexArray = { "Select Sex", "Male", "Female" };
               string[] titleArray = { "Select Title", "Engr", "Dr", "Miss", "Mr", "Mrs", "Pharm", "Prof" };

               ViewData["ddlCountry"] = new SelectList(countryArray);
               ViewData["ddlTitle"] = new SelectList(titleArray);
               ViewData["ddlSex"] = new SelectList(sexArray);

               #endregion

               var user = await db.ApplicationUsers.SingleAsync(e => e.UserName == User.Identity.Name);

               user.Firstname = model.Firstname;
               user.Middlename = model.Middlename;
               user.Lastname = model.Lastname;
               user.DateOfBirth = model.DateOfBirth;
               user.Sex = model.Sex;
               user.Address = model.Address;
               user.LocalGovtArea = model.LocalGovtArea;
               user.State = model.State;
               user.Country = model.Country;
               user.PhoneNumber = model.PhoneNumber;

               if (ModelState.IsValid)
               {
                    db.ApplicationUsers.Attach(user);
                    db.Entry(user).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    return Redirect("/Home");
               }

               return View(model);
          }

          protected override void Dispose(bool disposing)
          {
               db.Dispose();
               base.Dispose(disposing);
          }
     }
}