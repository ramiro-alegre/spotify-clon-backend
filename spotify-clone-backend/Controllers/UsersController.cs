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
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Users(){
            try{
                var AllUsers = _repository.GetAllUsers();
                return Ok(AllUsers);
            }catch(Exception e){
                return StatusCode(403, e.Message);
            }
        }

        [HttpDelete("/api/Users/{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteUser(long id){
            try{
                var user = _repository.GetUserWithId(id);
                _repository.DeleteUser(user);
                return Ok();
            }catch(Exception e){
                return StatusCode(500, e.Message);
            }



        }

        
    }
}