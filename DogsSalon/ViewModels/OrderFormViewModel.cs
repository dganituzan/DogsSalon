using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogsSalon.Models;

namespace DogsSalon.ViewModels
{
    public class OrderFormViewModel
    {
        public Customer customer { get; set; }
        public Order order { get; set; }

    }
}
