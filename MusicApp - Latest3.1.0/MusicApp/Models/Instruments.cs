using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApp.Models
{
    public class Instruments
    {
        public int Id { get; set; }

        [Display(Name = "Instrument")]
        public string InstrumentName { get; set; }
    }
}
