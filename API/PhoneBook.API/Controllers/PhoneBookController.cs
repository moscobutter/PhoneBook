using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PhoneBook.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class PhoneBookController : ControllerBase
    {
        private readonly IPhoneBookService _phoneBookService = null;
        private readonly IMapper _mapper = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="phoneBookService"></param>
        public PhoneBookController(IPhoneBookService phoneBookService, IMapper mapper)
        {
            _phoneBookService = phoneBookService ?? throw new ArgumentNullException(nameof(phoneBookService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        /// <summary>
        /// Method to search for phonebook entries for a phonebook
        /// </summary>
        /// <param name="phoneBookId"></param>
        /// <param name="searchText"></param>
        /// <returns></returns>
        [HttpGet("{phoneBookId}/{searchText}")]
        public async Task<IActionResult> SearchEntriesForPhoneBookAsync(int phoneBookId, string searchText)
        {
            if (phoneBookId == 0)
            {
                ModelState.AddModelError(string.Empty, "Please provide valid phone book to search against");
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            if (string.IsNullOrEmpty(searchText))
            {
                ModelState.AddModelError(string.Empty, "Please provide valid search text");
                return StatusCode(StatusCodes.Status400BadRequest);
            }

            List<ML.Entry>  entries = await _phoneBookService.SearchEntriesForPhoneBookAsync(phoneBookId, searchText);

            if(entries.Any() == false)
            {
                ModelState.AddModelError(string.Empty, string.Format("No entries found containing {0} for the phone book with Id = {1}", searchText, phoneBookId));

                return StatusCode(StatusCodes.Status404NotFound);
            }

            List<VM.EntryViewModel>  result = _mapper.Map<List<VM.EntryViewModel>>(entries);

            return StatusCode(StatusCodes.Status200OK, result);

        }

        /// <summary>
        /// Method to  add etry to the database
        /// </summary>
        /// <param name="entryRequest"></param>
        /// <returns></returns>
        [HttpPost("AddEntry")]
        public async Task<IActionResult> AddEntryAsync(VM.EntryViewModel entryRequest)
        {
            if(ModelState.IsValid)
            {
                var entry = _mapper.Map<ML.Entry>(entryRequest);

                var entryResponse = await _phoneBookService.AddEntryAsync(entry);

                if(entryResponse.Id > 0)
                {
                    var entryResult = _mapper.Map<VM.EntryViewModel>(entryResponse);

                    return StatusCode(StatusCodes.Status201Created, entryResult);
                }
            }

            return StatusCode(StatusCodes.Status400BadRequest);
        }

    }
}
