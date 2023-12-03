using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc.Core.Infrastructure;
using Zxcvbn;
using Service;
using Entities;
using DTO;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ex1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> logger;
        IUserService service;
        IMapper mapper;
        public UsersController(IUserService service, IMapper mapper, ILogger<UsersController> logger)
        {
            this.service = service;
            this.mapper = mapper;
            this.logger = logger;
        }
        // POST api/<Users>/login
        [HttpPost("login")]
        public async Task<ActionResult<UsersTbl>> Post([FromBody] UserLoginDTO userLogin)
        {
            UsersTbl user = await service.getUserByEmailAndPassword(userLogin);
            if (user == null)
                return NoContent();
            logger.LogInformation("user login");
            return Ok(user);
        }


        // GET api/<Users>/5
        [HttpGet("{id}")]
        public string Get()
        {
            return "value";
        }


        // POST api/<Users>
        
        [HttpPost]
        public async Task<CreatedAtActionResult> Post([FromBody] UserDTO userDTO )
        {
            UsersTbl user = mapper.Map< UserDTO,UsersTbl>(userDTO);
            UsersTbl newUser = await service.addUser(user);
            if (newUser == null)
            {
                return null;
            }
           
            return CreatedAtAction(nameof(Get), new { id = newUser.UserId }, newUser);

        }

        // PUT api/<Users>/5
        [HttpPut("{id}")]
        public async Task Put( [FromBody] UserDTO value)
        {
            UsersTbl user = mapper.Map<UserDTO, UsersTbl>(value);
                await service.updateUser(user);

        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }

        // POST api/<Users>
        [HttpPost("check")]
        public int Post([FromBody] string password)
        {
            return service.checkPassword(password);
        }
    }
}
