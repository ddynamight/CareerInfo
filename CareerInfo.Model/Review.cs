namespace CareerInfo.Model
{
     using System;

     public partial class Review
     {
          public Review()
          {
               this.Date = DateTime.Now;
          }

          public int Id { get; set; }
          public string Comment { get; set; }
          public short Rating { get; set; }
          public DateTime Date { get; set; }
          public string ApplicationUserId { get; set; }
          public int CourseId { get; set; }

          public virtual ApplicationUser ApplicationUser { get; set; }
          public virtual Course  Course { get; set; }
     }
}
