using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CareerInfo.Web.Models.ProfileViewModels
{
     public class AddDetailsViewModel
     {
          [Required]
          [Display(Name = "Firstname")]
          public string Firstname { get; set; }

          [Required]
          [Display(Name = "Middlename")]
          public string Middlename { get; set; }

          [Required]
          [Display(Name = "Lastname")]
          public string Lastname { get; set; }

          [Required]
          [Display(Name = "Date of Birth")]
          public DateTime DateOfBirth { get; set; }

          [Required]
          [Display(Name = "Sex")]
          public string Sex { get; set; }

          [Required]
          [Display(Name = "Address")]
          public string Address { get; set; }

          [Required]
          [Display(Name = "Local Govt Area")]
          public string LocalGovtArea { get; set; }

          [Required]
          [Display(Name = "State")]
          public string State { get; set; }

          [Required]
          [Display(Name = "Country")]
          public string Country { get; set; }

          [Required]
          [Phone]
          [Display(Name = "Phone Number")]
          public string PhoneNumber { get; set; }

     }
}
