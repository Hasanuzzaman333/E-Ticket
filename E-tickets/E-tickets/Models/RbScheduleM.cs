using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace E_tickets.Models
{
    public class RbScheduleM
    {
        [RegularExpression(@"([0-9]+)", ErrorMessage = "Must be a Number.")]
        public int sid { get; set; }

        [Required]
        public int rid { get; set; }

        [Required]
        public int bid { get; set; }

        [Required]
        public int fare { get; set; }

        [Required]
        public DateTime departure_date { get; set; }

        [Required]
        public TimeSpan departure_time { get; set; }

    }
}