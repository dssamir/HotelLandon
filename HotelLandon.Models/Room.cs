using System.Collections.Generic;

namespace HotelLandon.Models
{
    public class Room : EntityBase
    {
        public int Number { get; set; }
        public int Floor { get; set; }
        public HashSet<Reservation> Reservations { get; set; }
    }
}
