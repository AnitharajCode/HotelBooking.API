using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.BusinessLogicLayer.DTO
{
    public record AvailabilityQuery(int HotelId, DateTime CheckIn, DateTime CheckOut, int Guests);
    public record BookingRequest(int RoomId, int HotelId, DateTime CheckIn, DateTime CheckOut, int Guests, string GuestName);
}
