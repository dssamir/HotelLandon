using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelLandon.Data;
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
            return View(_context.Rooms.ToList());
        }
    }
}