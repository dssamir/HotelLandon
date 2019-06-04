using HotelLandon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLandon.WebUI.Models
{
    public class ReservationViewModel
    {
        public string Id { get; set; }
        public Customer Customer { get; set; }
        public Room Room { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        public static explicit operator ReservationViewModel(Reservation reservation)
        => new ReservationViewModel
        {
            Customer = reservation.Customer,
            Room = reservation.Room,
            Start = reservation.Start,
            End = reservation.End
        };

        public static explicit operator Reservation(ReservationViewModel viewModel)
        => new Reservation
        {
            Customer = viewModel.Customer,
            CustomerId = viewModel.Customer.Id,
            Room = viewModel.Room,
            RoomId = viewModel.Room.Id,
            Id = viewModel.Id,
            End = viewModel.End,
            Start = viewModel.Start
        };
    }
}
