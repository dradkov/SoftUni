namespace MyLibrary.App.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class BookStatusViewModel
    {
        [DataType(DataType.Date)]
        [Required]
        public DateTime BorrowDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ReturnDate { get; set; }

        [Required]
        public string BorrowerName { get; set; }
    }
}
