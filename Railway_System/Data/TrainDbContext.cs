using Microsoft.EntityFrameworkCore;
using RailwaySystem.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Data
{
    public class TrainDbContext:DbContext
    {
        public TrainDbContext(DbContextOptions<TrainDbContext> options) : base(options)
        {

        }
        public DbSet<Train> trainsDb { get; set; }
        public DbSet<Station> station { get; set; }
        public DbSet<Quota> quotas { get; set; }
        public DbSet<Booking> bookings { get; set; }
        public DbSet<Tickets> tickets { get; set; }
    }
}
