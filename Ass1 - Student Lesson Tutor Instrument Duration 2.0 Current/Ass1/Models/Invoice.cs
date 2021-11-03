using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ass1.Models
{
    
    public enum TermsType
    {
        Term1,
        Term2,
        Term3,
        Term4
    }
    public class Invoice
    {
        public int Id { get; set; }

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

        [Display(Name = "Term")]
        public TermType Term { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}