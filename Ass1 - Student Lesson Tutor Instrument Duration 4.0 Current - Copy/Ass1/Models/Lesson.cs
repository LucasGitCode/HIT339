using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ass1.Models
{
    public enum TermType
    {
        Term1,
        Term2,
        Term3,
        Term4
    }
    public class Lesson
    {
        public int Id { get; set; }

        [ForeignKey("Students")]
        [Display(Name = "Student Name")]
        public int StudentsId { get; set; }
        public virtual Students Students { get; set; }

        [ForeignKey("Instrument")]
        [Display(Name = "Instrument")]
        public int InstrumentId { get; set; }
        public virtual Instrument Instrument { get; set;}

        [ForeignKey("Tutor")]
        [Display(Name = "Tutor Name")]
        public int TutorId { get; set; }
        public virtual Tutor Tutor { get; set; }

        [ForeignKey("DurationCost")]
        [Display(Name = "Duration")]
        public int DurationCostId { get; set; }
        public virtual DurationCost DurationCost { get; set; }

        [Display(Name ="Term")]
        public TermType Term { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        
    }
}
