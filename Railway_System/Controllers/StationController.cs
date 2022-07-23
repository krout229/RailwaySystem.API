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
    public class StationController : ControllerBase
    {
        private StationS _stationS;
        public StationController(StationS stationS)
        {
            _stationS = stationS;
        }
        [HttpPost("SaveStation")]
        public IActionResult SaveStation(Route station)
        {
            return Ok(_stationS.SaveStation(station));
        }
        [HttpPut("UpdateStation")]
        public IActionResult UpdateStation(Route station)
        {
            return Ok(_stationS.UpdateStation(station));
        }
        [HttpGet("GetStation")]
        public IActionResult GetStation(int StationId)
        {
            return Ok(_stationS.GetStation(StationId));
        }

        [HttpGet("GetAllStations")]
        public List<Route> GetAllStationss()
        {
            return _stationS.GetAllStations();
        }
    }
}
