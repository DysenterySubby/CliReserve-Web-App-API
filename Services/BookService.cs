using CliReserve.Data;
using CliReserve.Dtos.Auth;
using CliReserve.Dtos.Booking;
using CliReserve.Entities;
using CliReserve.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Operations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Azure;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace CliReserve.Services
{
    public interface IBookService
    {
        public Task<IActionResult> BookAsync(Seat seatId, int stayDuration);
        public IActionResult Check(Booking booking);
        public Task<IActionResult> ApproveAsync(Booking booking);
        public Task<IActionResult> GetBookingAsync();
        public Task<IActionResult> GetBookingHistoryAsync();
        public Task<IActionResult> UnbookAsync();
    }
    public class BookService : IBookService
    {
        private readonly CliReserveDbEntities _context;
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public BookService(CliReserveDbEntities context, ITokenService tokenService, UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _tokenService = tokenService;
            _userManager = userManager;
            _context = context;

            _httpContextAccessor = httpContextAccessor; 
        }

        public async Task<IActionResult> ApproveAsync(Booking booking)
        {
            
            if (!booking.Approved)
            {
                var seat = await _context.Seats.Include(s => s.Bookings).FirstAsync(s => s.SeatId == booking.SeatId);
                if(seat.Bookings.Where(b => b.Approved && !b.Finished).Count() < seat.Capacity)
                {
                    booking.Approved = true;
                    booking.Finished = false;
                    booking.StartTime = DateTime.Now.TimeOfDay;
                    booking.EndTime = DateTime.Now.AddMinutes(booking.Duration).TimeOfDay;

                    var currentUser = await _userManager.FindByIdAsync(booking.UserId);
                    currentUser.BookingId = booking.BookingId;
                    currentUser.Booking = booking;
                    _context.SaveChanges();
                    return new ObjectResult($"Booking ID \"{booking.BookingId}\" has been approved") { StatusCode = 200 };
                }
                return new ObjectResult($"The seat is currently full, try again later") { StatusCode = 409 };
            }
            return new ObjectResult("Booking already processed") { StatusCode = 400 };
        }

        public async Task<IActionResult> BookAsync(Seat seat, int stayDuration)
        {
            var currentUser = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.Email)!.Value);
            var booking = _context.Bookings.Where(b => b.BookingId == currentUser!.BookingId).FirstOrDefault();

            if (currentUser != null && booking == null)
            {
                if(seat.Bookings.Where(b => b.Approved && !b.Finished).Count() < seat.Capacity)
                {
                    Booking newBooking = new Booking
                    {
                        BookingId = $"{currentUser.StudentNumber}-{DateTime.Now.ToString("dd-MM-yyyy-hh-mm")}",
                        BookingDate = DateTime.Now.Date,
                        Duration = stayDuration,
                        Approved = false,
                        User = currentUser,
                        UserId = currentUser.Id,
                        Seat = await _context.Seats.FindAsync(seat.SeatId),
                    };
                    currentUser.BookingId = newBooking.BookingId;
                    currentUser.Booking = newBooking;
                    _context.Bookings.Add(newBooking);
                    await _context.SaveChangesAsync();
                    return new ObjectResult(newBooking.BookingId) { StatusCode = 200 };
                }
                return new ObjectResult($"The seat is currently full, try again later") { StatusCode = 409 };
            }
            return currentUser == null ? new ObjectResult("User not found") { StatusCode = 404 } : new ObjectResult(booking.BookingId) { StatusCode = 409 };
        }

        public IActionResult Check(Booking booking)
        {
            if (!booking.Approved)
            {
                return new ObjectResult("Unapproved!") { StatusCode = 202 };
            }
            return new ObjectResult("Approved!") { StatusCode = 200 };
        }

        public async Task<IActionResult> GetBookingAsync()
        {
            var currentUser = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.Email)!.Value);
            var booking = currentUser.BookingId != null ? await _context.Bookings.FirstAsync(b => b.BookingId == currentUser!.BookingId) : null;

            if(currentUser != null && booking != null)
            {
                if (booking.Approved)
                {
                    var endTime = booking.BookingDate.Add((TimeSpan)booking.EndTime);

                    if(DateTime.Now > endTime)
                    {
                        currentUser.BookingId = null;
                        currentUser.Booking = null;
                        _context.SaveChanges();
                        return new ObjectResult("Booking expired") { StatusCode = 404 };
                    }
                }
                var bookingRequest = new BookingDto
                {
                    BookingId = booking.BookingId,
                    BookingDate = booking.BookingDate,
                    Approved = booking.Approved,
                    StartTime = booking.StartTime,
                    EndTime = booking.EndTime,
                    SeatId = booking.SeatId
                };
                return new ObjectResult(bookingRequest) { StatusCode = 200 };
            }
            return currentUser == null ? new ObjectResult("User not found") { StatusCode = 404 } : new ObjectResult("Booking not found") { StatusCode = 404 };
        }

        public async Task<IActionResult> GetBookingHistoryAsync()
        {
            var currentUser = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.Email)!.Value);
            var bookings = _context.Bookings.Where(b => b.UserId == currentUser!.Id && b.Finished == true).OrderBy(b => b.BookingDate);

            var bookingHistoryList = new List<BookingHistoryDto>();
            List<DateTime> bookingDates = new List<DateTime>();

            DateTime prevDate = new DateTime();

            foreach (var booking in bookings)
            {
                if(bookingDates.Count < 1)
                {
                    prevDate = booking.BookingDate;
                    bookingDates.Add(booking.BookingDate);
                }
                if (booking.BookingDate != prevDate)
                {
                    bookingDates.Add(booking.BookingDate);
                    prevDate = booking.BookingDate;
                }
            }

            foreach(var date in bookingDates)
            {
                var bookHistory = new BookingHistoryDto
                {
                    BookingDate = date,
                    Bookings = bookings.Where(b => b.BookingDate == date).Select(b => new BookingHistoryData
                    {
                        TypeName = _context.SeatTypes.Where(st => st.Seats.Any(s => s.SeatId == b.SeatId)).FirstOrDefault().TypeName,
                        SeatId = b.SeatId,
                        BookingId = b.SeatId,
                        StartTime = b.StartTime,
                        EndTime = b.EndTime
                    }).ToList()
                };

                bookingHistoryList.Add(bookHistory);
            }
            return new ObjectResult(bookingHistoryList) { StatusCode = 200 };
        }

        public async Task<IActionResult> UnbookAsync()
        {
            var currentUser = await _userManager.FindByEmailAsync(_httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.Email)!.Value);
            if (currentUser.BookingId == null)
                return new ObjectResult($"User has no booking") { StatusCode = 404 };
            var booking = await _context.Bookings.FirstAsync(b => currentUser.BookingId == b.BookingId);
            if(booking != null)
            {
                booking.Finished = true;
                currentUser.Booking = null;
                currentUser.BookingId = null;
                if (!booking.Approved)
                    _context.Bookings.Remove(booking);
        
                await _context.SaveChangesAsync();
                return new ObjectResult($"Booking with ID \"{booking.BookingId}\" removed") { StatusCode = 200 };
            }
            return new ObjectResult($"Booking with ID \"{booking.BookingId}\" not found") { StatusCode = 404 };
        }
    }
}
