using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spotify_clone_backend.Models;
using spotify_clone_backend.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace spotify_clone_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class RegisterController : ControllerBase
    {
        private IUserRepository _repository;

        public RegisterController(IUserRepository repository)
        {
            _repository = repository;
        }
        [AllowAnonymous]
        [HttpPut]
        public IActionResult Register(User user){
            try{
                if(ValidateUser(user)){
                    user.Role = "User";
                    _repository.Save(user);
                    return StatusCode(201);
                }else{
                    return StatusCode(403, "Email or password are Invalid");
                }
            }catch(Exception e){
                return StatusCode(500, e.Message);
            }
        }

        private Boolean ValidateUser(User user){

            if(string.IsNullOrEmpty(user.Email)){
                return false;
            }
            if(string.IsNullOrEmpty(user.Password)){
                return false;
            }

            return true;
        }


        
    }
}