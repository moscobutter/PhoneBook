using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.BL.Interfaces
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(string username, string password);
        Task<bool> LogOutAsync(string username);
        Task<ML.User> GetLoggedInUserAsync(string username);
    }
}
