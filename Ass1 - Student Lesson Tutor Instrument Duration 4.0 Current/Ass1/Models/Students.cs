using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ass1.Models
{
    public enum GenderType
    {
        Male,
        Female,
        Nonbinary
    }

    public class Students
    {
        public int Id { get; set; }

        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Display(Name = "Student Name")]
        public string FullName { get { return FirstName + ' ' + LastName; } }

        [DataType(DataType.Date)]
        [Display(Name = "Date of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Age")]
        public int Age { get; set; }

        [Required]
        [Display(Name = "Gender")]
        public GenderType Gender { get; set; }

        [Required, StringLength(200)]
        [Display(Name = "Parent/Guardian")]
        public string ParentGuardian { get; set; }

        [Required]
        [Display(Name = "Contact Email")]
        public string ContactEmail { get; set;}

        [Required]
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set;}
    }
}