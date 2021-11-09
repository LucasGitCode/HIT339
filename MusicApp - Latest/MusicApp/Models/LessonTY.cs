using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace MusicApp.Models
{
    public enum TermType
    {
        Term1,
        Term2,
        Term3,
        Term4
    }

    public enum YearType
    {
        Year2022,
        Year2023,
        Year2024,
        Year2025
    }

    public class LessonTY
    {
        public int Id { get; set; }

        [Display(Name = "Term")]
        public TermType Term { get; set; }

        [Display(Name = "Year")]
        public YearType Year { get; set; }
    }
}
