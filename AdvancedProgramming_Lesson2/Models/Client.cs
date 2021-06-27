using System;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Client
    {
        [Display(Name = "Identyfikator")]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Imię")]
        [Required(ErrorMessage = "Pole wymagane")]
        [StringLength(30, ErrorMessage = "Wpisany tekst nie może być dłuższy niż 30 znaków")]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Drugie imię")]
        [Required(ErrorMessage = "Pole wymagane")]
        [StringLength(30, ErrorMessage = "Wpisany tekst nie może być dłuższy niż 30 znaków")]
        public string SecondName { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Nazwisko")]
        [Required(ErrorMessage = "Pole wymagane")]
        [StringLength(30, ErrorMessage = "Wpisany tekst nie może być dłuższy niż 30 znaków")]
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Numer telefonu")]
        [Required(ErrorMessage = "Pole wymagane")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Ten adres email jest niepoprawny")]
        [Display(Name = "Adres email")]
        [Required(ErrorMessage = "Pole wymagane")]
        public string Email { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Niewłaściwy format daty")]
        [Display(Name = "Data urodzenia")]
        [Required(ErrorMessage = "Pole wymagane")]
        [CurrentDate(ErrorMessage = "Nie można podać daty z przyszłości")]
        public DateTime BirthDate { get; set; }
    }
}
