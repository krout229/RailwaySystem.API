using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
   public interface IStation
    {
        public string SaveStation(Route route);
        public string UpdateStation(Route route);
        public string DeactStation(int RouteId);
        Route GetStation(int RouteId);
        List<Route> GetAllStations();
    }
}
