﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CareerInfo.Model
{
    public class News
    {
          public News()
          {
               this.Date = DateTime.Now;
          }


          public int Id { get; set; }
          public string Title { get; set; }
          public string Description { get; set; }
          public string Article { get; set; }
          public string Image { get; set; }
          public string Status { get; set; }
          public DateTime Date { get; set; }
          public string Tagname { get; set; }
     }
}
