using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsistTest.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace ConsistTest.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly ILogger<PersonController> _logger;
        private readonly IMapper _mapper;
        private IBusenessObject _bl;
        private IJWTAuthenticationManager _jwtAuthenticationManager;

        public PersonController(IMapper mapper, IBusenessObject bl, IJWTAuthenticationManager jwtAuthenticationManager, ILogger<PersonController> logger)
        {
            _mapper = mapper;
            _bl = bl;
            _jwtAuthenticationManager = jwtAuthenticationManager;
            _logger = logger;
        }

        [HttpPost]
        public async Task<IEnumerable<TreeItem<Person>>> Post([FromBody] List<Person> personsList)
        {            
            var res = _bl.BuildPersonsTree(personsList);                        
            var consistResponse = await _bl.CallConsistTestAPI(res);

            return res;
        }

        [AllowAnonymous]
        [HttpPost("GetToken")]
        public IActionResult GetToken([FromBody] string password )
        {
            var token = _jwtAuthenticationManager.Authenticate(password);
            if (token == null)
            {
                _logger.LogWarning($"Wrong password: {password}");
                return Unauthorized();
            }

            return Ok(token);
        }        
    }
}
