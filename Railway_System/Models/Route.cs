using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Models
{
    public class Route
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RouteId { get; set; }

        [ForeignKey("TrainId")]
        public int? TrainId { get; set; }
       
        public string ArrivalStation { get; set; }
        public string DepartureStation { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "MM/DD/YYYY Format")]
        public DateTime date { get; set; }
        
        public double distance { get; set; }
        public bool isActive { get; set; }
    }
}
