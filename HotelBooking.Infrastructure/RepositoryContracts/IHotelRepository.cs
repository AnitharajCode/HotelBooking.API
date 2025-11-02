using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.DataAccessLayer.Entities;

namespace HotelBooking.DataAccessLayer.RepositoryContracts
{
    public interface IHotelRepository
    {
        Task<IEnumerable<Hotel>> FindHotelByNameAsync(string? name);
         Task<List<Room>> FindAvailableRoomsAsync(
            int hotelId, DateTime checkIn, DateTime checkOut, int guests);
        Task<Booking> BookRoomAsync(
            int roomId, int hotelId, DateTime checkIn, DateTime checkOut, int guests, string guestName);
        Task<Booking> GetBookingDetailsAsync(string reference);
        Task<string> SeedData();
        Task<string> ResetData();
    }
}
