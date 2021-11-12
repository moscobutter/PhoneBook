using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneBook.VM
{
    public class UserViewModel
    {
        public string Username { get; set; }

        public string Fullname { get; set; }

        public bool IsLoginSuccessfull { get; set; }
        public string Token { get; set; }

        public PhoneBookViewModel PhoneBook { get; set; } 
    }
}
