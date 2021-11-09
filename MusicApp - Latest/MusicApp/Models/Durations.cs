using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApp.Models
{
    public class Durations
    {
        public int Id { get; set; }

        [Display(Name = "Duration in Minutes")]
        public int Duration { get; set; }

        [Display(Name = "Cost")]
        [DataType(DataType.Currency), Required]
        public int Cost { get; set; }
    }
}
