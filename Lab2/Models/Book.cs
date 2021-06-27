using System;
using System.ComponentModel.DataAnnotations;

namespace Lab2.Models
{
    public class Book
    {
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Title")]
        [Required(ErrorMessage = "Field required")]
        [StringLength(50, ErrorMessage = "Text max 50")]
        public string Title { get; set; }
        [Display(Name = "Release date")]
        [DataType(DataType.Date, ErrorMessage = "Invalid date format")]
        [Required(ErrorMessage = "Field required")]
        [CurrentDate(ErrorMessage = "Nie można podać daty z przyszłości")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Rating")]
        [Required(ErrorMessage = "Field required")]
        [DisplayFormat(DataFormatString = "{0:N}", ApplyFormatInEditMode = true)]
        [Range(0,10, ErrorMessage = "Zero to ten allowed", ConvertValueInInvariantCulture = true, ParseLimitsInInvariantCulture = true)]
        public decimal Rating { get; set; }
        [Display(Name = "Author")]
        [Required(ErrorMessage = "Field required")]
        [StringLength(60, ErrorMessage = "Text max 60")]
        public string Author { get; set; }
        [Display(Name = "Country")]
        [Required(ErrorMessage = "Field required")]
        [StringLength(30, ErrorMessage = "Text max 30")]
        public string Country { get; set; }
    }
}
