using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhoneBook.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DataController : ControllerBase
    {
        private readonly ISeedData _seedData = null;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="seedData"></param>
        public DataController(ISeedData seedData)
        {
            _seedData = seedData ?? throw new ArgumentNullException(nameof(seedData));
        }

        /// <summary>
        /// Method to seed data
        /// </summary>
        /// <returns></returns>        
        //[HttpPost("/seed")]
        [HttpGet("seed")]
        public async Task<ActionResult> SeedData()
        {
            //call method to seed the data
            
            var result = await _seedData.Seed();

            if(result == false)
            {
                return StatusCode(StatusCodes.Status304NotModified);
            }

            return StatusCode(StatusCodes.Status201Created, result);
        }
    }
}
