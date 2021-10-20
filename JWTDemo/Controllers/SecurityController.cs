
using JWTDemo.Model;
using JWTDemo.Security.JWTToken;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JWTDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        private readonly IJWTAuth jwtAuth;

        public SecurityController(IJWTAuth jwtAuth)
        {
            this.jwtAuth = jwtAuth;
        }

        [HttpPost("authentication")]
        public IActionResult Authentication([FromBody] UserCredential userCredential)
        {


            var token = jwtAuth.Authentication(userCredential.Username, userCredential.Password);
            if (token == null)
                return Unauthorized();
            return Ok(token);
        }

    }
}
