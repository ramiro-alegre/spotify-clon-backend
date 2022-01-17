using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using spotify_clone_backend.Models;
using spotify_clone_backend.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace spotify_clone_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUserRepository _repository;
        private IConfiguration _config;
        public LoginController(IUserRepository repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }
        /// <response code="200">If login correctly</response>
        /// <response code="404">If user doesnt exist</response>
        /// <response code="500">If the server has a problem</response>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody] UserDTO user)
        {
            try
            {
                //Devuelve != null si existe y los datos son correctos
                var UserDatabase = _repository.GetUserWithEmail(user.Email, user.Password);

                if(UserDatabase != null)
                {
                    var token = Generate(UserDatabase);
                    //Implementación hecha porque el Front recibia un "HttpErrorResponse",
                    //que aun no pude solucionar
                    ResponseCode objResponseCode = new ResponseCode {
                        Code= 200,
                        Result = token
                    };

                    return StatusCode(200, objResponseCode);
                }
                return NotFound("User or password invalid");   
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }
        //Función para generer el JWT
        private string Generate(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role)
            };

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Audience"],
              claims,
              expires: DateTime.Now.AddMinutes(15),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
