using System;
using System.Collections.Generic;
using System.Text;

namespace Kittens.App.Models.Users
{
    using System.ComponentModel.DataAnnotations;

    public class LoginViewModel
    {
        [MinLength(3)]
        [MaxLength(10)]
        public string  Username { get; set; }

        [MinLength(3)]
        public string  Password { get; set; }
    }
}
