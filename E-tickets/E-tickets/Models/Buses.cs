using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_tickets.Models
{
    public class Buses
    {
        
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        public int Busid { get; set; }

        [Required]
        public string BusName { get; set; }

        [Required]
        //[RegularExpression(@"(42|28)", ErrorMessage = "Must be 40 or 28.")]
        //[Range(28, 42)]
        public int MaxSeat { get; set; }

        [Required]
        public string BusType { get; set; }
    }
}