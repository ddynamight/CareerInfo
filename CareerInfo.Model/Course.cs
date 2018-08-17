using System;
using System.Collections.Generic;
using System.Text;

namespace CareerInfo.Model
{
     public class Course
     {
          public Course()
          {
               //this.Tagname = Name.ToLower().Replace(" ", "-").Replace("/", "-") + Guid.NewGuid().ToString().Substring(0, 10);
               this.SchoolCourses = new HashSet<SchoolCourse>();

               this.Reviews = new HashSet<Review>();
          }

          public int Id { get; set; }
          public string Name { get; set; }
          public string Description { get; set; }
          public string Details { get; set; }
          public string Image { get; set; }
          public string Tagname { get; set; }

          public virtual Personality Personality { get; set; }
          public virtual Profession Profession { get; set; }
          public virtual Requirement Requirement { get; set; }

          public IEnumerable<Review> Reviews { get; set; }
          public IEnumerable<SchoolCourse> SchoolCourses { get; set; }

     }
}
