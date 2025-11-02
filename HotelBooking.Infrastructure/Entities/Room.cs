using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HotelBooking.DataAccessLayer.Entities
{
        public class Room
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }
        
        public int RoomTypeId { get; set; }
        public bool IsBooked { get; set; }
        public RoomTypes RoomType { get; set; }
       
    }
}
