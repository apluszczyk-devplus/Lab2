using System;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Book
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [Display(Name = "Tytuł")]
        [Required(ErrorMessage = "Pole wymagane")]
        [StringLength(50, ErrorMessage = "Wpisany tekst nie może być dłuższy niż 50 znaków")]
        public string Title { get; set; }
        [Display(Name = "Data wydania")]
        [DataType(DataType.Date, ErrorMessage = "Niewłaściwy format daty")]
        [Required(ErrorMessage = "Pole wymagane")]
        [CurrentDate(ErrorMessage = "Nie można podać daty z przyszłości")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Ocena")]
        [Required(ErrorMessage = "Pole wymagane")]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        [Range(0,10, ErrorMessage = "Dozwolona wartość między 0 a 10", ConvertValueInInvariantCulture = true, ParseLimitsInInvariantCulture = true)]
        public decimal Rating { get; set; }
        [Display(Name = "Autor")]
        [Required(ErrorMessage = "Pole wymagane")]
        [StringLength(60, ErrorMessage = "Wpisany tekst nie może być dłuższy niż 60 znaków")]
        public string Author { get; set; }
        [Display(Name = "Kraj")]
        [Required(ErrorMessage = "Pole wymagane")]
        [StringLength(30, ErrorMessage = "Wpisany tekst nie może być dłuższy niż 30 znaków")]
        public string Country { get; set; }
    }
}
