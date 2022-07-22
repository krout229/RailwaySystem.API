using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RailwaySystem.API.Models
{
    public class BankCred
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BankId { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string BankName { get; set; }
        //public string CardNum { get; set; }
        //public string expiryDate { get; set; }
        //public string CVV { get; set; }
    }
}
