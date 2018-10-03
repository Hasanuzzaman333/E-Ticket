using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_tickets.Models
{
    public class RouteM
    {
        
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        public int Routeid { get; set; }

        [Required]
        public string FromLocation { get; set; }

        [Required]
        public String ToLocation { get; set; }

        
    }
}