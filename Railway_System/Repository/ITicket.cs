using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
   public interface ITicket
    {
        public string SaveTicket(int PassengerId, int BookingId, int TrainId);

        public IEnumerable<TicketModel> GetTicket(int PassengerId, int BookingId, int TrainId);
    }
}
