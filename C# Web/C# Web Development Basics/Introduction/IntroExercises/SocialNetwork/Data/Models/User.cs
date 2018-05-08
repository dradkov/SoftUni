namespace SocialNetwork.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 4, ErrorMessage = "The lenght shoud be more than 4 symbols and less then 30")]
        public string Username { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 6)]
        [RegularExpression(@"(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[!@#$%^&*()_+<>?]).{6,}",
            ErrorMessage = "Characters are not allowed.")]
        public string Password { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9]+[._-]*@[A-Z0-9.-]+\.[A-Z]{2,}$")]
        public string Email { get; set; }

        public Picture ProfilePicture { get; set; }

        public DateTime RegisteredOn  { get; set; }

        public DateTime LastTimeLoggedIn { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }


        public int? FriendId { get; set; }

        public User Friend { get; set; }

        public ICollection<User> Firends { get; set; }  = new HashSet<User>();

        public ICollection<UserAlbum> Albums { get; set; } = new List<UserAlbum>();
    }
}
