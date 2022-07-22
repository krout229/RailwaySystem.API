using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Models
{
    public class Station
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StationId { get; set; }
        [Column(TypeName = "varchar(25)")]
        [Required(ErrorMessage = "Station name can not be empty")]
        [MinLength(2, ErrorMessage = "Station name can not be less than 2")]
        public string Name { get; set; }

        public double distance { get; set; }
    }
}
