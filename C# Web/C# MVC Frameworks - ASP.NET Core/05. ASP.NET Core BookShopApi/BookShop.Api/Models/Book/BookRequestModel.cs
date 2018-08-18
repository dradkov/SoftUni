namespace BookShop.Api.Models.Book
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using static BookShop.Models.Helper.ModelConstants;
    
    public class BookRequestModel
    {

        [Required]
        [MinLength(BookTitleMinLength)]
        [MaxLength(BookTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, double.MaxValue)]
        public int Copies { get; set; }

        public int? Edition { get; set; } = 1;

        public int? AgeRestriction { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? ReleaseDate { get; set; }

        public int AuthorId { get; set; }

    }
}
