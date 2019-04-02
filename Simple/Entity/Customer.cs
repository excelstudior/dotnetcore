using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Simple.Entity
{
    public class Customer
    {
        //[Key]
        //public Guid Id { get; set; }
        //[Required]
        //[MaxLength(100)]
        //public string Name { get; set; }

        
        public Guid Id { get; set; }
        public string Name { get; set; }
        //Add hirechy later
    }
}
