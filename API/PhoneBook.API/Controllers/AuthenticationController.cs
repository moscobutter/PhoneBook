using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using PhoneBook.BL.Interfaces;
using PhoneBook.VM;
using System;
using System.Threading.Tasks;

namespace PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService = null;
        private readonly IPhoneBookService _phoneBookService = null;
        private readonly IMapper _mapper = null;
        private readonly IOptions<Configs.AppSettings> _options = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="authenticationService"></param>
        /// <param name="mapper"></param>
        /// <param name="options"></param>
        /// <param name="phoneBookService"></param>
        public AuthenticationController(IAuthenticationService authenticationService, IPhoneBookService phoneBookService, IMapper mapper, IOptions<Configs.AppSettings> options)
        {
            _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));
            _phoneBookService = phoneBookService ?? throw new ArgumentNullException(nameof(phoneBookService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _options = options ?? throw new ArgumentNullException(nameof(options));
        }

        /// <summary>
        /// Method to login a user
        /// </summary>
        /// <param name="loginRequest"></param>
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestViewModel loginRequest) 
        {
            if (ModelState.IsValid)
            {
                bool result = await _authenticationService.LoginAsync(loginRequest.Username, loginRequest.Password);

                if (result)
                {
                    var user = await _authenticationService.GetLoggedInUserAsync(username: loginRequest.Username);

                    if(user != null)
                    {
                        var phoneBook = await _phoneBookService.GetPhoneBookByUserIdAsync(user.Id);

                        var phoneBookMapped = _mapper.Map<PhoneBookViewModel>(phoneBook);

                        var userResult = new UserViewModel()
                        {
                            IsLoginSuccessfull = true,
                            Username = user.UserName,
                            PhoneBook = phoneBookMapped,
                            Token = Helpers.TokenGenerator.GenerateUserToken(user, _options.Value)
                        };

                        return StatusCode(StatusCodes.Status200OK, userResult);

                    }
                }
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }
    }
}
