using CliReserve.Data;
using CliReserve.Dtos.Booking;
using CliReserve.Entities;
using CliReserve.Models;
using CliReserve.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using System.Security.Claims;

namespace CliReserve.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly CliReserveDbEntities _context;

        public BookController(CliReserveDbEntities context, IBookService bookService)
        {
            _bookService = bookService;
            _context = context;
        }

        [Authorize(Roles = "User")]
        [HttpGet("check/{BookingId}")]
        public async Task<IActionResult> CheckBooking(string BookingId)
        {
            var booking = await _context.Bookings.FindAsync(BookingId);
            if (booking != null)
            {
                return _bookService.Check(booking);
            }
            return NotFound("Booking ID does not exist");
        }
        [AllowAnonymous]
        [HttpPatch("approve/{BookingId}")]
        public async Task<IActionResult> ApproveBooking(string BookingId)
        {
            var booking = await _context.Bookings.FindAsync(BookingId);
            if(booking != null)
            { 
                return await _bookService.ApproveAsync(booking);
            }
            return NotFound("Booking ID does not exist");
        }

        [Authorize(Roles = "User")]
        [HttpPost("seat")]
        public async Task<IActionResult> CreateBooking([FromBody] NewBookingDto newBooking)
        {
            var seat = await _context.Seats.Include(s => s.Bookings).FirstAsync(s => s.SeatId == newBooking.SeatId);
            if(seat != null)
                return await _bookService.BookAsync(seat, newBooking.Duration);
            return NotFound($"SeatID\"{newBooking.SeatId}\" not found");
        }
        [Authorize(Roles = "User")]
        [HttpPatch("cancel")]
        public async Task<IActionResult> RemoveBooking()
        {
            return await _bookService.UnbookAsync();
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> GetBooking()
        {
            return await _bookService.GetBookingAsync();
        }

        [Authorize(Roles = "User")]
        [HttpGet("history")]
        public async Task<IActionResult> GetBookingHistory()
        {
            return await _bookService.GetBookingHistoryAsync();
        }
    }
}
