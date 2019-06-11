using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenAPI.Domain.Entities;
using GenAPI.DomainServices.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService _userService) => userService = _userService;
        [HttpGet]
        public IActionResult Get()
        {
            var result = userService.GetUsers();
            return Ok(result);
        }        
        [HttpPost]
        public IActionResult Insert([FromBody] User user)
        {          
            if(userService.SearchUserByName(user.Username))
                return Conflict("User Alredy Exist");

            var result = userService.InsertUser(ref user);

            return CreatedAtAction("Get", user);

        }
    }
}