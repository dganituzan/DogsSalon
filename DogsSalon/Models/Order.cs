using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DogsSalon.Models
{
    public class Order
    {
        public int id { get; set; }
        public Customer customer { get; set; }
        [Required]
        public int customerId { get; set; }
        public DateTime? createDate { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? timeOfOrder { get; set; }

    }
}
