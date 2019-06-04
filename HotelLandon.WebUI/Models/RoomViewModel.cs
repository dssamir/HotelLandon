using HotelLandon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLandon.WebUI.Models
{
    public class RoomViewModel
    {
        public string Id { get; set; }
        public int Number { get; set; }
        public int Floor { get; set; }
        public IList<ReservationViewModel> Reservations { get; set; }

        public static explicit operator RoomViewModel(Room room)
        => new RoomViewModel
        {
            Floor = room.Floor,
            Id = room.Id,
            Number = room.Number,
            Reservations = new List<ReservationViewModel>(room.Reservations.Select(r => (ReservationViewModel)r))
        };

        public static explicit operator Room(RoomViewModel viewModel)
        => new Room
        {
            Floor = viewModel.Floor,
            Id = viewModel.Id,
            Number = viewModel.Number,
            Reservations = new HashSet<Reservation>(viewModel.Reservations.Select(r => (Reservation)r))
        };
    }
}
