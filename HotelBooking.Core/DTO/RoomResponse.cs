using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.BusinessLogicLayer.DTO
{
    public class RoomResponse
    {
        public int Id { get; set; }
        public int HotelId { get; set; }
        public string RoomNumber { get; set; }
        public String RoomType { get; set; }
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
    }
}
