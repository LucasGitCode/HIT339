using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ass1.Models
{
    public enum YearType
    {
        Year2021,
        Year2022,
        Year2023,
        Year2024
    }

    public enum TermsType
    {
        Term1,
        Term2,
        Term3,
        Term4
    }
    public class Letter
    {
        public int Id { get; set; }

        [ForeignKey("Students")]
        [Display(Name = "Student Name")]
        public int StudentsId { get; set; }
        public virtual Students Students { get; set; }

        [Display(Name = "Term")]
        public TermsType Term { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Display(Name = "Year")]
        public YearType Year { get; set; }

        [ForeignKey("DurationCost")]
        public int DurationCostId { get; set; }
        public virtual DurationCost DurationCost { get; set; }

        [Display(Name = "Ref#")]
        public int RefNo { get; set; }

        [Display(Name = "Bank")]
        public string BankId { get; set; }

        [Display(Name = "Account Name")]
        public string AccName { get; set; }

        [Display(Name = "BSB Number")]
        public int BSBNo { get; set; }

        [Display(Name = "Account Number")]
        public int AccNo { get; set; }

        [Display(Name = "Signature")]
        public string Signature { get; set; }



    }
}
