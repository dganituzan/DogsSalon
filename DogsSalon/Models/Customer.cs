using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DogsSalon.Models
{
    public class Customer
    {
        public int id { get; set; }
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }
    }
}
