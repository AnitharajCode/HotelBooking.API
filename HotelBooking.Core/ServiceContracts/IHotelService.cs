using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.DataAccessLayer.Entities;

namespace HotelBooking.BusinessLogicLayer.ServiceContracts
{
    public interface IHotelService
    {
        Task<IEnumerable<Hotel>> FindHotelByNameAsync(string? name);
        Task<List<DTO.RoomResponse>> FindAvailableRoomsAsync(int hotelId, DateTime checkIn, DateTime checkOut, int guests);
        Task<DTO.BookingResponse> BookRoomAsync(int roomId, int hotelId, DateTime checkIn, DateTime checkOut, int guests, string guestName);
        Task<Booking> GetBookingDetailsAsync(string reference);
        Task<string> SeedData();
        Task<string> ResetData();
    }
}
