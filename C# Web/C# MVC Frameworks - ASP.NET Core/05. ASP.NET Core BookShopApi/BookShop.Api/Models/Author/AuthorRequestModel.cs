namespace BookShop.Api.Models.Author
{
    using System.ComponentModel.DataAnnotations;

    using static BookShop.Models.Helper.ModelConstants;

    public class AuthorRequestModel 
    {
        [Required]
        [MaxLength(AuthorNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(AuthorNameMaxLength)]
        public string LastName { get; set; }
    }
}
