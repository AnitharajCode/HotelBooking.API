using HotelBooking.BusinessLogicLayer.ServiceContracts;
using HotelBooking.DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using HotelBooking.BusinessLogicLayer.DTO;
namespace HotelBooking.API.Controllers
{
    [Route("api/[controller]")] //api/Account
    [ApiController]
    public class HotelController : Controller
    {

        private readonly IHotelService _hotelService;
        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;
        }
        [HttpGet()]
        [HttpGet("find/{name}")]
        public async Task<IActionResult> FindHotel(string? name)
        {
            var hotel = await _hotelService.FindHotelByNameAsync(name);
            if (hotel == null) return NotFound("Hotel not found.");
            return Ok(hotel);
        }
       
        //POST api/hotel/availability      
        [HttpPost("availability")]
        public async Task<IActionResult> GetAvailability([FromBody] AvailabilityQuery query)
        {
            var rooms = await _hotelService.FindAvailableRoomsAsync(
                query.HotelId, query.CheckIn, query.CheckOut, query.Guests);
            return Ok(rooms);
        }
        
        //POST api/hotel/book        
        [HttpPost("book")]
        public async Task<IActionResult> BookRoom([FromBody] BookingRequest request)
        {
            var booking = await _hotelService.BookRoomAsync(
                request.RoomId,request.HotelId, request.CheckIn, request.CheckOut, request.Guests, request.GuestName);

            if (booking == null) return BadRequest("Booking failed. Room is unavailable or capacity exceeded.");

            return CreatedAtAction(nameof(GetBooking), new { reference = booking.Reference }, booking);
        }

        // GET api/hotel/booking/ABC1234
        [HttpGet("booking/{reference}")]
        public async Task<IActionResult> GetBooking(string reference)
        {
            var booking = await _hotelService.GetBookingDetailsAsync(reference);
            if (booking == null) return NotFound("Booking reference not found.");
            return Ok(booking);
        }

        [HttpPost("seed")]
        public async Task<IActionResult> SeedData()
        {
            return Ok(await _hotelService.SeedData());
        }
        [HttpPost("reset")]
        public async Task<IActionResult> ResetData()
        {
            return Ok(await _hotelService.ResetData());
        }
    }
}

