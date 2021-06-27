using System;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Client
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "First name")]
        [Required(ErrorMessage = "Field required")]
        [StringLength(30, ErrorMessage = "Text max 30")]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Second name")]
        [Required(ErrorMessage = "Field required")]
        [StringLength(30, ErrorMessage = "Text max 30")]
        public string SecondName { get; set; }
        [DataType(DataType.Text)]
        [Display(Name = "Last name")]
        [Required(ErrorMessage = "Field required")]
        [StringLength(30, ErrorMessage = "Text max 30")]
        public string LastName { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "Field required")]
        public string PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress, ErrorMessage = "Email invalid")]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Field required")]
        public string Email { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        [Display(Name = "Birth date")]
        [Required(ErrorMessage = "Field required")]
        [CurrentDate(ErrorMessage = "Future date not allowed")]
        public DateTime BirthDate { get; set; }
    }
}
