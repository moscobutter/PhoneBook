using System;
using System.ComponentModel.DataAnnotations;

namespace PhoneBook.VM
{
    public class LoginRequestViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
