using HotelLandon.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelLandon.WebUI.Models
{
    public class CustomerViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthdate { get; set; }
        public List<ReservationViewModel> Reservations { get; set; }

        public static explicit operator CustomerViewModel(Customer customer)
        => new CustomerViewModel
        {
            Birthdate = customer.BirthDate,
            FirstName = customer.FirstName,
            Id = customer.Id,
            LastName = customer.LastName
        };

        public static explicit operator Customer(CustomerViewModel viewModel)
        => new Customer
        {
            LastName = viewModel.LastName,
            Id = viewModel.Id,
            BirthDate = viewModel.Birthdate,
            FirstName = viewModel.FirstName,
            Reservations = new HashSet<Reservation>(viewModel.Reservations.Select(r => (Reservation)r))
        };
    }
}
