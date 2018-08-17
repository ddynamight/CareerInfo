using System;
using System.Collections.Generic;
using System.Text;

namespace CareerInfo.Model
{
     public class School
     {
          public School()
          {
               this.SchoolCourses = new HashSet<SchoolCourse>();
               //this.Tagname = Name.ToLower().Replace(" ", "-").Replace("/", "-") + "-" + Guid.NewGuid().ToString().ToLower().Substring(0, 10);
          }


          // Class Properties 

          public int Id { get; set; }
          public string Name { get; set; }
          public string Description { get; set; }
          public string Address { get; set; }
          public string Email { get; set; }
          public string State { get; set; }
          public string Tagname { get; set; }

          public IEnumerable<SchoolCourse> SchoolCourses { get; set; }



     }
}
