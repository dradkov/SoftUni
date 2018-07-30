namespace MyLibrary.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Book
    {
        public Book()
        {
            this.Borrowers = new List<BorrowersBooks>();
            this.History = new List<BorrowHistory>();
            this.Status = "At home";
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(1500)]
        public string Content { get; set; }

        [Required]
        public int AuthorId { get; set; }

        [Required]
        public Author Author { get; set; }

        [MinLength(2)]
        [MaxLength(10)]
        public string Status { get; set; }

        public ICollection<BorrowHistory> History { get; set; }

        [Required]
        [Url]
        public string ImageUrl { get; set; }

        public ICollection<BorrowersBooks> Borrowers { get; set; }
    }
}
