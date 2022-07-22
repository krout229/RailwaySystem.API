using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
   public interface IStation
    {
        public string SaveStation(Station station);
        public string UpdateStation(Station station);
        Station GetStation(int StationId);
        List<Station> GetAllStations();
    }
}
