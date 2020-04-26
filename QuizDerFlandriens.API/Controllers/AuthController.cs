using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using QuizDerFlandriens.API.Models;
using QuizDerFlandriens.Models;

namespace QuizDerFlandriens.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private SignInManager<Person> _signInManager;
        private IConfiguration configuration;
        private IPasswordHasher<Person> hasher;
        private UserManager<Person> userManager;
        private ILogger<AuthController> logger;

        public AuthController(SignInManager<Person> signInManager, IConfiguration configuration,
            IPasswordHasher<Person> hasher, UserManager<Person> userManager, ILogger<AuthController> logger
            )
        {
            this._signInManager = signInManager;
            this.configuration = configuration;
            this.hasher = hasher;
            this.userManager = userManager;
            this.logger = logger;
        }

        [HttpPost("token")]
        [AllowAnonymous]
        public async Task<IActionResult> Token([FromBody] Login_DTO
        identityDTO)
            {
                try
                {
                    var jwtsvc = new JWTServices<Person>(configuration,
                    logger, userManager, hasher);
                    var token = await jwtsvc.GenerateJwtToken(identityDTO);
                    return Ok(token);
                }
                catch (Exception exc)
                {
                    logger.LogError($"Exception thrown when creating JWT: {exc}");
                }
                //Bij niet succesvolle authenticatie wordt een Badrequest (=zo weinig mogelijke info) teruggeven.
                return BadRequest("Failed to generate JWT token");
            }
        }
}
