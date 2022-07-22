using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Models
{
    public class Seat
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SeatsId { get; set; }
        public int FirstAC { get; set; }
        public int SecondAC { get; set; }
        public int Sleeper { get; set; }
        public int total { get; set; }
    }
}
