namespace MyLibrary.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BorrowHistory
    {
        public BorrowHistory()
        {
            this.BorrowDate = DateTime.Now;
        }

        public int Id { get; set; }

        [Required]
        public int BookId { get; set; }

        [Required]
        public Book Book { get; set; }

        [Required]
        public int BorrowerId { get; set; }

        [Required]
        public Borrower Borrower { get; set; }

        [DataType(DataType.Date)]
        public DateTime BorrowDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }
    }
}
