using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace DogsSalon.Models
{
    public class Role : IdentityRole
    {

        public Role() : base() { }

        public Role(string roleName) : base(roleName) { }
        
        public Role(string roleName , DateTime creationDate) : base(roleName ) { }

        public DateTime creationDate { get; set;  }
    }
}
