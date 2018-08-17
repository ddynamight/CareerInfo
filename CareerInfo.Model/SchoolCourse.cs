using System;
using System.Collections.Generic;
using System.Text;

namespace CareerInfo.Model
{
    public class SchoolCourse
    {
          public int SchoolId { get; set; }
          public virtual School School  { get; set; }

          public int CourseId { get; set; }
          public virtual Course Course { get; set; }
     }
}
