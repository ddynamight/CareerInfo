using System;
using System.Collections.Generic;
using System.Text;

namespace CareerInfo.Model
{
    public class Requirement
    {
          public int Id { get; set; }
          public string Olevel { get; set; }
          public string Jamb { get; set; }
          public int JambScore { get; set; }
          public string Alevel { get; set; }
          public int PostUtme { get; set; }
          public int CourseId { get; set; }

          public virtual Course Course { get; set; }
     }
}
