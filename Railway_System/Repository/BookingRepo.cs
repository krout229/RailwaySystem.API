using Microsoft.EntityFrameworkCore;
using RailwaySystem.API.Data;
using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public class BookingRepo : IBooking
    {
        private TrainDbContext _trainDb;
        public BookingRepo(TrainDbContext trainDb)
        {
            _trainDb = trainDb;
        }
        public string DeactBooking(int BookingId)
        {
            string Result = string.Empty;
            Booking delete = null;
            try
            {
                delete = _trainDb.bookings.Find(BookingId);
                if(delete!= null)
                {
                    delete.bookingStatus = "CANCELLED";
                    _trainDb.SaveChanges();
                    Result = "200";
                }

            }
            catch(Exception ex)
            {
                Result = "400";
            }
            return Result;
            
        }

        public List<Booking> GetAllBookings()
        {
            string Result = string.Empty;
            List<Booking> bookings = null;
            try
            {
                bookings = _trainDb.bookings.ToList();

            }
            catch (Exception ex)
            {

            }
            return bookings;
        }

        public Booking GetBooking(int BookingId)
        {
            Booking booking = null;
            try
            {
                booking = _trainDb.bookings.Find(BookingId);
            }
            catch (Exception ex)
            {

            }
            return booking;
        }

        public string SaveBooking(Booking booking)
        {
            string stCode = string.Empty;
            try
            {
                _trainDb.bookings.Add(booking);
                _trainDb.SaveChanges();
                stCode = "200";
            }
            catch (Exception ex)
            {
                stCode = "400";
            }
            return stCode;
        }

        public string UpdateBooking(Booking booking)
        {
            string stCode = string.Empty;
            try
            {
                _trainDb.Entry(booking).State = EntityState.Modified;
                _trainDb.SaveChanges();
                stCode = "200";
            }
            catch
            {
                stCode = "400";
            }
            return stCode;
        }
    }
}
