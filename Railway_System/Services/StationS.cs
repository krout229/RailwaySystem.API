using RailwaySystem.API.Models;
using RailwaySystem.API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Services
{
    public class StationS
    {
        private IStation _Istation;
        public StationS(IStation Istation)
        {
            _Istation = Istation;
        }
        public string SaveStation(Station station)
        {
            return _Istation.SaveStation(station);
        }
        public string UpdateStation(Station station)
        {
            return _Istation.UpdateStation(station);
        }
        public Station GetStation(int StationId)
        {
            return _Istation.GetStation(StationId);
        }
        public List<Station> GetAllStations()
        {
            return _Istation.GetAllStations();
        }
    }
}
