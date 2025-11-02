using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.BusinessLogicLayer.DTO
{
    public class BookingResponse
    {
        public string Reference { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public string GuestName { get; set; }
        public int HotelId { get; set; }
        public decimal TotalPrice { get; set; }
        public int RoomId { get; set; }
    }
}
