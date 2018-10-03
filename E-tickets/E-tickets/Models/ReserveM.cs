using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_tickets.Models
{
    public class ReserveM
    {
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        public int ticket_no { get; set; }

        [Required]
        public int routeId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public string phone_no { get; set; }

        [StringLength(6, MinimumLength = 4, ErrorMessage = "Must be at least 4 characters long.")]
        [Required]
        public string gender { get; set; }

        [Required]
        public int scheduleId { get; set; }

        [Required]
        public string email { get; set; }

        [Required]
        public string seat_no { get; set; }

    }
}