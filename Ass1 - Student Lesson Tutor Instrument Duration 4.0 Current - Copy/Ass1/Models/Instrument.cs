using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ass1.Models
{
    public class Instrument
    {
        public int Id { get; set; }
       
        [Display(Name = "Instrument")]
        public string InstrumentName { get; set; }
    }
}
