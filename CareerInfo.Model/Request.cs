using System;
using System.Collections.Generic;
using System.Text;

namespace CareerInfo.Model
{
     public class Request
     {
          public Request()
          {
               this.Date = DateTime.Now;
          }


          // Single Properties
          public int Id { get; set; }
          public string Category { get; set; }
          public string Comment { get; set; }
          public DateTime Date { get; set; }
          public string ApplicationUserId { get; set; }

          public virtual ApplicationUser ApplicationUser { get; set; }
     }
}
