using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelLandon.Data;
using HotelLandon.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelLandon.WebUI.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HotelLandonContext _context;
        public RoomsController(HotelLandonContext context)
            => _context = context;
        public IActionResult Index()
        {
            var rooms = _context.Rooms.Select(a => (RoomViewModel)a);
            return View(new List<RoomViewModel>(rooms));
        }
    }
}