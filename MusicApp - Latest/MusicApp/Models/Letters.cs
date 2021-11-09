using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MusicApp.Models
{
    public class Letters
    {
        public enum SemesterType
        {
            Semester1,
            Semester2
        }
        public int Id { get; set; }
        

        //StudentFk
        [ForeignKey("Students")]
        public int StudentsId { get; set; }
        public virtual Students Students { get; set; }

        //LessonTYFk
        [ForeignKey("LessonTY")]
        [Display(Name = "Term & Year")]
        public int LessonTYId { get; set; }
        public virtual LessonTY LessonTY { get; set; }

        //LessonDTfk
        [ForeignKey("LessonDT")]
        [Display(Name = "Start & End Date")]
        public int LessonDTId { get; set; }
        public virtual LessonDT LessonDT { get; set; }

        //Semester
        [Display(Name = "Semester")]
        public SemesterType Semester { get; set; }

        //Payment Details
        //Bank Details
        [Display(Name = "Bank")]
        public string BankId { get; set; }

        [Display(Name = "Account Name")]
        public string AccName { get; set; }

        [Display(Name = "BSB Number")]
        public int BSBNo { get; set; }

        [Display(Name = "Account Number")]
        public int AccNo { get; set; }

        [Display(Name = "Cost")]
        [DataType(DataType.Currency), Required]
        public int Cost { get; set; }

        [Display(Name = "Paid")]
        public Boolean Paid { get; set; }

        [Display(Name = "Signature")]
        public string Signature { get; set; }
    }
}
