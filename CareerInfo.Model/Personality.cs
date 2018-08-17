using System;
using System.Collections.Generic;
using System.Text;

namespace CareerInfo.Model
{
    public class Personality
    {
          public int Id { get; set; }
          public string Details { get; set; }
          public int CourseId { get; set; }

          public virtual Course Course { get; set; }
     }
}
