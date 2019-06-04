using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelLandon.Models
{
    public class Customer : EntityBase
    {
        [MinLength(2), Required]
        public string FirstName { get; set; }
        [MaxLength(50)]
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public HashSet<Reservation> Reservations { get; set; }
    }
}
