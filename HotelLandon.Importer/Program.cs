using HotelLandon.Data;
using HotelLandon.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using static System.Console;

namespace HotelLandon.Importer
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using (var context = new HotelLandonContext())
            {
                if (!context.Rooms.Any())
                {
                    for (int floor = 0; floor < 5; floor++)
                    {
                        for (int number = 0; number < 10; number++)
                        {
                            var room = new Room
                            {
                                Number = floor * 100 + number,
                                Floor = floor
                            };
                            context.Rooms.Add(room);
                        }
                    }
                    var roomsAdded = await context.SaveChangesAsync();
                    WriteLine($"{roomsAdded} rooms added.");
                }
                else WriteLine("Rooms already added.");

                for (int i = 0; i < 10; i++)
                {
                    var customer = new Customer
                    {
                        FirstName = Faker.Name.FirstName(),
                        LastName = Faker.Name.LastName(),
                        BirthDate = Faker.Date.Birthday(18, 90)
                    };
                    context.Customers.Add(customer);
                }
                var addedCustomers = await context.SaveChangesAsync();
                WriteLine($"{addedCustomers} customers added.");

                var rooms = await context.Rooms.ToListAsync();
                foreach (var customer in await context
                    .Customers
                    .Include(x => x.Reservations)
                    .Where(c => !c.Reservations.Any())
                    .ToListAsync())
                {
                    var reservation = new Reservation
                    {
                        CustomerId = customer.Id,
                        RoomId = rooms.ElementAt(new Random().Next(0, rooms.Count)).Id,
                        Start = Faker.Date.Forward(1, 1),
                        End = Faker.Date.Forward(1, 2)
                    };
                    context.Reservations.Add(reservation);
                }
                var addedReservations = await context.SaveChangesAsync();
                WriteLine($"{addedReservations} reservations added.");
            }
            ReadLine();
        }
    }
}