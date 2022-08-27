using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwaySystem.API.Models;
using RailwaySystem.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private TicketS ticketS;
        public TicketController(TicketS _ticketS)
        {
            ticketS = _ticketS;
        }
        [HttpGet("SaveTicket")]
        public IActionResult SaveTicket(int PassengerId, int BookingId, int TrainId)
        {
            return Ok(ticketS.SaveTicket(PassengerId, BookingId, TrainId));
        }
       [HttpGet("GetTicketModel")]
        public IEnumerable<TicketModel> GetTicket(int PassengerId, int BookingId, int TrainId)
        {
            return ticketS.GetTicket(PassengerId, BookingId, TrainId);
        }
    }
}

