using Microsoft.EntityFrameworkCore;
using RailwaySystem.API.Data;
using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public class StationRepo : IStation
    {
        private TrainDbContext _trainDb;
        public StationRepo(TrainDbContext trainDbContext)
        {
            _trainDb = trainDbContext;
        }
        #region Get All Stations
        /// <summary>
        /// When this fuction is invoked we get all stations
        /// </summary>
        /// <returns>List of all the stations</returns>
        public List<Station> GetAllStations()
        {
            List<Station> stations = null;
            try
            {
                stations = _trainDb.station.ToList();
            }
            catch (Exception ex)
            {
                
            }
            return stations;
        }
        #endregion

        #region Get Station by Id
        /// <summary>
        /// 
        /// </summary>
        /// <param name="StationId"></param>
        /// <returns></returns>
        public Station GetStation(int StationId)
        {
            Station station = null;
            try
            {
                station = _trainDb.station.Find(StationId);
            }
            catch (Exception ex)
            {

            }
            return station;
           
        }
        #endregion

        #region Save Station
        public string SaveStation(Station station)
        {
            string stCode = string.Empty;
            try
            {
                _trainDb.station.Add(station);
                _trainDb.SaveChanges();
                stCode = "200";
            }
            catch (Exception ex)
            {
                stCode = "400";
            }
            return stCode;
            
        }
        #endregion

        #region Update Station
        public string UpdateStation(Station station)
        {
            string stCode = string.Empty;
            try
            {
                _trainDb.Entry(station).State = EntityState.Modified;
                _trainDb.SaveChanges();
                stCode = "200";
            }
            catch
            {
                stCode = "400";
            }
            return stCode;
           
        }
        #endregion
    }
}
