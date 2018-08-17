using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace CareerInfo.Model
{
     public class ApplicationUser : IdentityUser
     {
          public ApplicationUser()
          {
               this.Reviews = new HashSet<Review>();
               this.Requests = new HashSet<Request>();
          }

          public string Firstname { get; set; }
          public string Middlename  { get; set; }
          public string Lastname { get; set; }
          public DateTime DateOfBirth { get; set; }
          public string Sex { get; set; }
          public string Address { get; set; }
          public string LocalGovtArea { get; set; }
          public string State { get; set; }
          public override string PhoneNumber { get; set; }
          public string Country { get; set; }

          public virtual ICollection<Review> Reviews { get; set; }
          public virtual ICollection<Request> Requests { get; set; }
     }
}
