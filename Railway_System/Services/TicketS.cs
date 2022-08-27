using RailwaySystem.API.Models;
using RailwaySystem.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Services
{
    public class TicketS
    {
        private ITicket _ITicket;
        public TicketS(ITicket ITicket)
        {
            _ITicket = ITicket;
        }
        public string SaveTicket(int PassengerId, int BookingId, int TrainId)
        {
            return _ITicket.SaveTicket(PassengerId, BookingId, TrainId);
        }

        public IEnumerable<TicketModel> GetTicket(int PassengerId, int BookingId, int TrainId)
        {
            return _ITicket.GetTicket(PassengerId,BookingId,TrainId);
        }
    }
}

