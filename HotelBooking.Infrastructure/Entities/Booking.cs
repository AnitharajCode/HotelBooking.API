using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HotelBooking.DataAccessLayer.Entities
{
    public class Booking
    {
        public int Id { get; set; }
        public int RoomId { get; set; }
         public decimal TotalPrice { get; set; }
        public int HotelId { get; set; }
        public string Reference { get; set; } = Guid.NewGuid().ToString().Substring(0, 8).ToUpper(); // Unique ID
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public int NumberOfGuests { get; set; }
        public string GuestName { get; set; }
              
        public Room Room { get; set; }
    }
}
