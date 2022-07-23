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
        public List<Route> GetAllStations()
        {
            List<Route> stations = null;
            try
            {
                stations = _trainDb.route.ToList();
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
        public Route GetStation(int RouteId)
        {
            Route route = null;
            try
            {
                route = _trainDb.route.Find(RouteId);
            }
            catch (Exception ex)
            {

            }
            return route;
           
        }
        #endregion

        #region Save Station
        public string SaveStation(Route route)
        {
            string stCode = string.Empty;
            try
            {
                _trainDb.route.Add(route);
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
        public string UpdateStation(Route route)
        {
            string stCode = string.Empty;
            try
            {
                _trainDb.Entry(route).State = EntityState.Modified;
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

        #region Deact Route
       

        public string DeactStation(int RouteId)
        {
            string Result = string.Empty;
            Route delete;

            try
            {
                delete = _trainDb.route.Find(RouteId);


                if (delete != null)
                {
                    //_TicketDb.TicketsDb.Remove(delete);
                    delete.isActive = false;
                    _trainDb.SaveChanges();
                    Result = "200";
                }
            }
            catch (Exception ex)
            {
                Result = "400";
            }
            finally
            {
                delete = null;
            }
            return Result;
        }
        #endregion
    }
}
