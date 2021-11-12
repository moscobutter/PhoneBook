using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PhoneBook.BL.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.BL.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly SignInManager<ML.User> _signInManager = null;
        private readonly UserManager<ML.User> _userManager = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="signInManager"></param>
        public AuthenticationService(SignInManager<ML.User> signInManager, UserManager<ML.User> userManager)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        /// <summary>
        /// Method to get logged in user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<ML.User> GetLoggedInUserAsync(string username)
        {
            return await _userManager.FindByNameAsync(username);
        }

        /// <summary>
        /// Method to log in the user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public async Task<bool> LoginAsync(string username, string password)
        {
            bool result = false;

            var user = await _userManager.FindByEmailAsync(_userManager.NormalizeKey(username));
            //var user = await _userManager.Users.FirstOrDefaultAsync(usr => usr.NormalizedEmail.Equals(username));

            if(user != null)
            {
                if(user.IsDeleted == false)
                {
                    result = await _userManager.CheckPasswordAsync(user, password);

                    //var res = await _signInManager.CheckPasswordSignInAsync(user, password, lockoutOnFailure: true);
                    
                }
            }

            return result;
        }

        /// <summary>
        /// Method to log out the user
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public async Task<bool> LogOutAsync(string username)
        {
            throw new System.NotImplementedException();
        }
    }

}
