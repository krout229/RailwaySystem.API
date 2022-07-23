using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Repository
{
    public interface IUser
    {
        public string SaveUser(User user);
        public string UpdateUser(User user);
        User GetUser(int UserId);
        List<User> GetAllUser();
    }
}
