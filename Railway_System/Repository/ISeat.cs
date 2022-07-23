using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public interface ISeat
    {
        public string SaveSeat(Seat seat);
        public string UpdateSeat(Seat seat);
        Seat GetSeat(int SeatId);
        List<Seat> GetAllSeats();
    }
}
