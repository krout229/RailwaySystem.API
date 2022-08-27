using Microsoft.EntityFrameworkCore;
using RailwaySystem.API.Data;
using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public class TicketRepo : ITicket
    {
        private TrainDbContext trainDb;
        public TicketRepo(TrainDbContext TicketDbContext)
        {
            trainDb = TicketDbContext;
        }
       

        #region GetTicket
        /// <summary>
        /// When this function is invocked we get the Tickets by Id
        /// </summary>
        /// <param name="TicketId"></param>
        /// <returns>Finds the Id of the Ticket</returns>
        public IEnumerable<TicketModel> GetTicket(int PassengerId,int BookingId,int TrainId)
        {
           
            List<TicketModel> Result;
           
                 Result = (from p in trainDb.passenger
                              join b in trainDb.bookings on p.PassengerId equals b.PassengerId
                              join t in trainDb.trains on b.TrainId equals t.TrainId
                              select new TicketModel
                              {
                                  TrainId = t.TrainId,
                                  Name = t.Name,
                                  ArrivalTime = t.ArrivalTime,
                                  DepartureTime = t.DepartureTime,
                                  ArrivalDate = t.ArrivalDate,
                                  DepartureDate = t.DepartureDate,
                                  ArrivalStation = t.ArrivalStation,
                                  DepartureStation=t.DepartureStation,
                                  BookingId=b.BookingId,
                                  fare=b.fare,
                                  Status=b.Status,
                                  SeatNum=b.SeatNum,
                                  PassengerId = p.PassengerId,
                                  PName = p.PName,
                                  Age = p.Age,
                                  gender = p.gender,
                                  Class = p.Class,
                              }).Where(q=>q.PassengerId==PassengerId && q.BookingId==BookingId && q.TrainId==TrainId).ToList();
              
            
          
            return Result;
        }
        #endregion

        #region AddTicket
        /// <summary>
        /// When this function is invoked we can Add a Ticket
        /// </summary>
        /// <param name="Ticket"></param>
        /// <returns></returns>
        public string SaveTicket(int PassengerId, int BookingId, int TrainId)
        {
            string stCode = string.Empty;
            try
            {
                trainDb.tickets.Add(new Tickets { TrainId = TrainId, PassengerId = PassengerId, BookingId = BookingId });
               
                trainDb.SaveChanges();
                stCode = "200";
            }
            catch (Exception ex)
            {
                stCode = "400";
            }
            return stCode;
        }

       
        #endregion


    }
}
