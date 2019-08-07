using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DogsSalon.Models
{
    public class User : IdentityUser
    {
        public User() : base() { }
        public string name { get; set; }
    }
}
