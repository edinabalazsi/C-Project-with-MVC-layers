using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TeaHouse.Web.Models
{
    public class Extra
    {
        [Display(Name = "Extra id")]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Extra name")]
        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string ExtraName { get; set; }

        [Display(Name = "Category")]
        [Required]
        [StringLength(10, MinimumLength = 5)]
        public string Category { get; set; }

        [Display(Name = "Allergen")]
        [Required]
        [StringLength(10, MinimumLength = 4)]
        public string Allergen { get; set; }

        [Display(Name = "Available")]
        [Required]
        public bool Available { get; set; }

        [Display(Name ="Price")]
        [Required]
        public int Price { get; set; }

    }
}