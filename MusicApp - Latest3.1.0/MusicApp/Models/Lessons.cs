using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApp.Models
{
    public class Lessons
    {
        public int Id { get; set; }

        [ForeignKey("Students")]
        [Display(Name = "Student Name")]
        public int StudentsId { get; set; }
        public virtual Students Students { get; set; }

        [ForeignKey("Instrument")]
        [Display(Name = "Instrument")]
        public int InstrumentsId { get; set; }
        public virtual Instruments Instruments { get; set; }

        [ForeignKey("Tutor")]
        [Display(Name = "Tutor Name")]
        public int TutorsId { get; set; }
        public virtual Tutors Tutor { get; set; }

        [ForeignKey("LessonTY")]
        [Display(Name = "Term & Year")]
        public int LessonTYId { get; set; }
        public virtual LessonTY LessonTY { get; set; }

        [ForeignKey("LessonDT")]
        [Display(Name = "Date & Time")]
        public int LessonDTId { get; set; }
        public virtual LessonDT LessonDT { get; set; }

        [ForeignKey("Durations")]
        [Display(Name = "Duration")]
        public int DurationsId { get; set; }
        public virtual Durations Durations { get; set; }

        [ForeignKey("Letters")]
        [Display(Name = "Paid")]
        public int PaidId { get; set; }
        public virtual Boolean Paid { get; set; }
    }
}
