using CliReserve.Data;
using CliReserve.Dtos.Clir;
using CliReserve.Entities;
using CliReserve.Migrations;
using CliReserve.Models;
using CliReserve.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CliReserve.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "User")]
    public class ClirController : ControllerBase
    {
        private readonly CliReserveDbEntities _context;
        private readonly ClirBlobService _clirBlobService;
        private readonly UserManager<User> _userManager;
        public ClirController(CliReserveDbEntities context, ClirBlobService clirBlobService, UserManager<User> userManager)
        {
            _context = context;
            _clirBlobService = clirBlobService;
            _userManager = userManager;
        }
        [HttpPost("image")]
        public async Task<IActionResult> GetImage([FromBody] ImageRequestDto imageRequestDto)
        {
            if(!string.IsNullOrEmpty(imageRequestDto.SeatTypeId))
                return Ok(await _clirBlobService.GetSeatTypeImageAsync(imageRequestDto.SeatTypeId, imageRequestDto.ClirName));
            else
                return Ok(await _clirBlobService.GetClirImageAsync(imageRequestDto.ClirName));
        }

        //GET CLIRS
        [HttpGet]
        public async Task <IActionResult> GetClirs()
        {

            return Ok(_context.Clirs.Select(c => new ClirDto
            {
                ClirLocation = c.ClirLocation,
                ClirName = c.ClirName
            }));
        }

        //GET SEATTYPES
        [HttpGet("{clirName}")]
        public async Task<IActionResult> GetSeatTypes(string clirName)
        {
            
            try
            {
                var seatTypes = _context.SeatTypes.Where(st => st.Clir.ClirName == clirName).Include(st => st.Seats);
                if (seatTypes != null)
                {
                    return Ok(seatTypes.Select(st => new SeatTypeDto
                    {
                        TypeName = st.TypeName,
                        SeatTypeId = st.SeatTypeId,
                        ClirName = clirName,
                        SeatCount = st.Seats.Count
                    }));
                }
                return BadRequest($"\"{clirName} Clir\" does not exist");
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            } 
        }
        //GET SEATS
        [HttpGet("{clirName}/{typeId}")]
        public async Task<IActionResult> GetSeats(string clirName, string typeId)
        {
            var currentUser = await _userManager.FindByEmailAsync(User.FindFirst(ClaimTypes.Email)!.Value);
            try
            {

                var seats =  _context.Seats.Where(s => s.SeatTypeId == typeId);

                foreach (var seat in seats)
                {
                    foreach (var booking in seat.Bookings.Where(b => b.Approved == true && !b.Finished))
                    {
                        var endTime = booking.BookingDate.Add((TimeSpan)booking.EndTime);
                        if (DateTime.Now > endTime)
                        {
                            currentUser.BookingId = null;
                            currentUser.Booking = null;
                            _context.Bookings.First(b => b.BookingId == booking.BookingId).Finished = true;
                            
                        }
                    }
                }
                _context.SaveChanges();
                return Ok(seats.Select(s => new SeatDto
                {
                    SeatId = s.SeatId,
                    SeatTypeId = s.SeatTypeId,
                    TypeName = s.SeatType.TypeName,
                    Description = s.Description,
                    Capacity = s.Capacity,
                    BookedCount = s.Bookings.Count(b => b.Approved == true && !b.Finished),
                    IsAvailable = s.Bookings.Count(b => b.Approved == true && !b.Finished) >= s.Capacity ? false : true
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        //QR GET SEATS
        [HttpGet("qr/{clirName}/{seatId}")]
        public IActionResult GetSeatQR(string clirName, string seatId)
        {
            try
            {
                var seat = _context.Seats.Include(s => s.SeatType).FirstOrDefault(s => s.SeatId == seatId);

                var seats = _context.Seats.Where(s => s.SeatTypeId == seat.SeatTypeId);
                var seatTypes = _context.SeatTypes.Where(st => st.Clir.ClirName == clirName);
                

                if (seatTypes != null && seat != null)
                {
                    return Ok(new QrScanDto
                    {
                        SeatId = seatId,
                        
                        Seats = seats.Select(s => new SeatDto
                        {
                            SeatId = s.SeatId,
                            SeatTypeId = s.SeatTypeId,
                            TypeName = s.SeatType.TypeName,
                            Description = s.Description,
                            Capacity = s.Capacity,
                            BookedCount = s.Bookings.Count(b => b.Approved == true && !b.Finished),
                            IsAvailable =  s.IsAvailable
                        }),

                        SeatTypes = seatTypes.Select(st => new SeatTypeDto
                        {
                            TypeName = st.TypeName,
                            SeatTypeId = st.SeatTypeId,
                            ClirName = clirName,
                            SeatCount = st.Seats.Count
                        })
                    });
                }
                return BadRequest("Resource does not exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
