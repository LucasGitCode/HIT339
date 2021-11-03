using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ass1.Models
{
    
    public class Letter
    {
        public int Id { get; set; }

        [ForeignKey("Students")]
        [Display(Name = "Student Name")]
        public int StudentsId { get; set; }
        public virtual Students Students { get; set; }

        [ForeignKey("DurationCost")]
        [Display(Name = "Duration")]
        public int DurationCostId { get; set; }
        public virtual DurationCost DurationCost { get; set; }

        public Boolean paid { get; set; }

        [Display(Name = "Signature")]
        public string Signature { get; set; }



    }
}
