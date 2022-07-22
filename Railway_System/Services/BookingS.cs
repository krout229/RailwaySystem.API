using RailwaySystem.API.Models;
using RailwaySystem.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Services
{
    public class BookingS
    {
        private IBooking _Ibooking;
        public BookingS(IBooking Ibooking)
        {
            _Ibooking = Ibooking;
        }
        public string SaveBooking(Booking Booking)
        {
            return _Ibooking.SaveBooking(Booking);
        }
        public string DeactBooking(int BookingId)
        {
            return _Ibooking.DeactBooking(BookingId);
        }
        public string UpdateBooking(Booking Booking)
        {
            return _Ibooking.UpdateBooking(Booking);
        }
        public Booking GetBooking(int BookingId)
        {
            return _Ibooking.GetBooking(BookingId);
        }
        public List<Booking> GetAllBookings()
        {
            return _Ibooking.GetAllBookings();
        }
    }
}
