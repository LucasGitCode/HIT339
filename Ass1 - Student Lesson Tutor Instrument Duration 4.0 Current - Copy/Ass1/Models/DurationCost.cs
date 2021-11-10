using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ass1.Models
{
    public class DurationCost
    {
        public int Id { get; set; }

        [Display(Name = "Duration")]
        public int Duration { get; set; }

        [Display(Name = "Cost")]
        [DataType(DataType.Currency), Required]
        public int Cost { get; set; }
    }
}
