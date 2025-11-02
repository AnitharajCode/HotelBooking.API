using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.DataAccessLayer.Entities
{
    public  class RoomTypes
    {
        [Key]
        public int Id { get; set; }
        public String RoomType  { get; set; }
        public int Capacity { get; set; }
        public int HotelId { get; set; }
        public decimal PricePerNight { get; set; }
    }
}
