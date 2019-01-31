using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EF.Data
{
    public class Person // going to be an entity
    {
        [Key]
        public int PersonId { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string  LastName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

    }
}
