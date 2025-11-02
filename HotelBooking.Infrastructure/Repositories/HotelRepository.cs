using HotelBooking.DataAccessLayer.Context;
using HotelBooking.DataAccessLayer.Entities;
using HotelBooking.DataAccessLayer.RepositoryContracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace HotelBooking.DataAccessLayer.Repositories
{
    public class HotelRepository:IHotelRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public HotelRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
       
        // 1. Find a hotel based on its name.
        public async Task<IEnumerable<Hotel>> FindHotelByNameAsync(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
               return await _dbContext.Hotels.ToListAsync();
            else
                return await _dbContext.Hotels.Where(h => h.Name == name).ToListAsync();
        }

        // 2. Find available rooms between two dates for a given number of people.
        public async Task<List<Room>> FindAvailableRoomsAsync(
            int hotelId, DateTime checkIn, DateTime checkOut, int guests)
        {
            // Step 1: Find all rooms in the specified hotel that meet the capacity.
            var rooms = await _dbContext.Rooms.Include(r => r.RoomType).ToListAsync();
            var potentialRooms = rooms
                .Where(r => r.HotelId == hotelId && r.RoomType.Capacity >= guests )
                .ToList();

            var roomIds = potentialRooms.Select(r => r.Id).ToList();

            // Step 2: Find all bookings that OVERLAP with the requested dates for these rooms.
            var overlappingBookings = await _dbContext.Bookings
                .Where(b => roomIds.Contains(b.RoomId) &&
                            // Check for overlap: Start before end AND End after start
                            checkIn < b.CheckOutDate && checkOut > b.CheckInDate)
                .Select(b => b.RoomId)
                .ToListAsync();

            // Step 3: Filter out rooms that have overlapping bookings.
            var availableRooms = potentialRooms
                .Where(r => !overlappingBookings.Contains(r.Id))
                .ToList();

            return availableRooms;
        }

        // 3. Book a room.
        public async Task<Booking> BookRoomAsync(
             int roomId, int hotelId, DateTime checkIn, DateTime checkOut, int guests, string guestName)
        {
            var room = await _dbContext.Rooms.Include(r=>r.RoomType).Where(r=>r.HotelId== hotelId && r.Id== roomId).FirstOrDefaultAsync();
            var prevBookings = await _dbContext.Bookings
                .Where(b => b.RoomId == roomId && 
                            checkIn < b.CheckOutDate && checkOut > b.CheckInDate)
                .Select(b => b.RoomId)
                .ToListAsync();
            if ((room == null || room.RoomType.Capacity < guests) || prevBookings.Count > 0) return null; // Validation

            // Calculate total price (Simplified)
            var duration = checkOut - checkIn;
            var nights = (int)duration.TotalDays;
            var totalPrice = nights * room.RoomType.PricePerNight;

            var newBooking = new Booking
            {
                RoomId = room.Id,
                HotelId = hotelId,
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                NumberOfGuests = guests,
                GuestName = guestName,
                TotalPrice = totalPrice
            };
           // room.IsBooked = true;
            _dbContext.Bookings.Add(newBooking);
           
            await _dbContext.SaveChangesAsync();

            return newBooking;
        }

        // 4. Find booking details based on a booking reference.
        public async Task<Booking> GetBookingDetailsAsync(string reference)
        {
            return await _dbContext.Bookings
                 //.Include(b => b.Room)
                // .ThenInclude(r => r.Hotel)
                  .FirstOrDefaultAsync(b => b.Reference == reference);
        }
        public async Task<string> SeedData()
        {
            // 1. Create a minimal set of Hotel and Room entities
            var hotel = new Hotel { Name = "Test Grand Hotel" };
            var hotel1 = new Hotel { Name = "IBIS" };
            _dbContext.Hotels.AddRange(hotel, hotel1);
            await _dbContext.SaveChangesAsync();
            int hotelId1 = _dbContext.Hotels.Where(h => h.Name == "Test Grand Hotel").Select(h => h.Id).FirstOrDefault();

            //Room Type
            //var roomType = new RoomTypes { HotelId=hotelId1, RoomType="Single",Capacity=1,PricePerNight=50 };
            //var roomType1 = new RoomTypes { HotelId = hotelId1, RoomType = "Double", Capacity = 2, PricePerNight = 100 };
            //var roomType2 = new RoomTypes { HotelId = hotelId1, RoomType = "Deluxe", Capacity = 4, PricePerNight = 180 };
            //_dbContext.RoomTypes.AddRange(roomType, roomType1, roomType2);
            //await _dbContext.SaveChangesAsync();
            var roomType = _dbContext.RoomTypes.Where(r => r.RoomType == "Single" && r.HotelId == 1).FirstOrDefault();
            var roomType1 = _dbContext.RoomTypes.Where(r => r.RoomType == "Double" && r.HotelId == 1).FirstOrDefault();
            var roomType2 = _dbContext.RoomTypes.Where(r => r.RoomType == "Deluxe" && r.HotelId == 1).FirstOrDefault();
            var h1Room1 = new Room
            {
                HotelId = hotelId1,
                RoomNumber = "101",              
                RoomTypeId = roomType.Id,              
                RoomType = roomType,
            };
            var h1Room2= new Room
            {
                HotelId = hotelId1, RoomNumber = "102", 
                RoomTypeId= roomType.Id                                                        
                ,RoomType = roomType
            };
            var h1Room3 = new Room
            {
                HotelId = hotelId1,
                RoomNumber = "101",
                RoomTypeId = roomType1.Id,
                RoomType = roomType1
            };
            var h1Room4 = new Room
            {
                HotelId = hotelId1,
                RoomNumber = "102",             
                RoomTypeId = roomType1.Id,
                RoomType = roomType1               
            };
            var h1Room5 = new Room
            {
                HotelId = hotelId1,
                RoomNumber = "201",               
                RoomTypeId = roomType2.Id,                
                RoomType = roomType2
            };
            var h1Room6 = new Room
            {
                HotelId = hotelId1,
                RoomNumber = "202",               
                RoomTypeId = roomType2.Id,
                RoomType = roomType2
                
            };
            var h2Room1 = new Room
            {
                HotelId = 2,
                RoomNumber = "101",
                RoomTypeId = roomType.Id,
                RoomType = roomType,
            };
            var h2Room2 = new Room
            {
                HotelId = 2,
                RoomNumber = "102",
                RoomTypeId = roomType.Id,
                RoomType = roomType
            };
           
            _dbContext.Rooms.AddRange(h1Room1, h1Room2, h1Room3, h1Room4, h1Room5, h1Room6);
            _dbContext.Rooms.AddRange(h2Room1, h2Room2);
            // 2. Add an existing booking for availability testing
            var testBooking = new Booking
            {              
                RoomId = h1Room1.Id,
                HotelId = hotelId1,
                Reference = "TEST-BOOK-123",
                CheckInDate = DateTime.Today.AddDays(1),
                CheckOutDate = DateTime.Today.AddDays(2),
                NumberOfGuests = 1,
                GuestName = "Test User",
                TotalPrice = 1* h1Room1.RoomType.PricePerNight
            };  
            
            _dbContext.Bookings.Add(testBooking);

            await _dbContext.SaveChangesAsync();
            return "Database seeded with test data.";
        }
       
        public async Task<string> ResetData()
        {
            // WARNING: This clears all data and resets identity columns!
          //  await _dbContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE RoomTypes;");
            await _dbContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Bookings;");
            await _dbContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Rooms;");
            await _dbContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Hotels;");
            return "Database tables have been reset.";
        }
    }
}
