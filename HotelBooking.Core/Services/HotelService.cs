using HotelBooking.BusinessLogicLayer.ServiceContracts;
using HotelBooking.DataAccessLayer.Entities;
using HotelBooking.DataAccessLayer.RepositoryContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.BusinessLogicLayer.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;
        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }
        
        // 1. Find a hotel based on its name.
        public async Task<IEnumerable<Hotel>> FindHotelByNameAsync(string? name)
        {
            return await _hotelRepository.FindHotelByNameAsync(name);
        }

        // 2. Find available rooms between two dates for a given number of people.
        public async Task<List<DTO.RoomResponse>> FindAvailableRoomsAsync(
            int hotelId, DateTime checkIn, DateTime checkOut, int guests)
        {
            var rooms= await _hotelRepository.FindAvailableRoomsAsync(hotelId, checkIn, checkOut, guests);
            List <DTO.RoomResponse> availableRooms = new List<DTO.RoomResponse> ();
            foreach (var currentRoom in rooms)
            {
                DTO.RoomResponse room = new DTO.RoomResponse();
                room.Id = currentRoom.Id;
                room.HotelId = currentRoom.HotelId;
                room.RoomNumber= currentRoom.RoomNumber;
                room.RoomType = currentRoom.RoomType.RoomType;
                room.Capacity = currentRoom.RoomType.Capacity;
                room.PricePerNight=currentRoom.RoomType.PricePerNight;
                availableRooms.Add(room);

            }
            return availableRooms;
        }

        // 3. Book a room.
        public async Task<DTO.BookingResponse> BookRoomAsync(
             int roomId, int hotelId, DateTime checkIn, DateTime checkOut, int guests, string guestName)
        {
            var booking= _hotelRepository.BookRoomAsync(roomId,  hotelId, checkIn, checkOut, guests, guestName);
            DTO.BookingResponse currentBooking = new DTO.BookingResponse();
            if (booking != null&& booking.Result != null)
            {
                currentBooking.Reference = booking.Result.Reference;
                currentBooking.HotelId = booking.Result.HotelId;
                currentBooking.GuestName = booking.Result.GuestName;
                currentBooking.CheckOutDate = booking.Result.CheckOutDate;
                currentBooking.CheckInDate = booking.Result.CheckInDate;
                currentBooking.NumberOfGuests = booking.Result.NumberOfGuests;
                currentBooking.TotalPrice = booking.Result.TotalPrice;
                currentBooking.RoomId = booking.Result.Room.Id;
                return currentBooking;
            }
            return null;
        }

        // 4. Find booking details based on a booking reference.
        public async Task<Booking> GetBookingDetailsAsync(string reference)
        {
            return await _hotelRepository.GetBookingDetailsAsync(reference);
        }
        public async Task<string> SeedData()
        {
            return await _hotelRepository.SeedData();
        }
        public async Task<string> ResetData()
        {
            return await _hotelRepository.ResetData();
        }
    }
}
