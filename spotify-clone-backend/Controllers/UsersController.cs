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
        ///<summary>Get all users</summary>
        /// <response code="200">If get all users correctly</response>
        /// <response code="401">If you not authenticate</response>
        /// <response code="403">If you don't have authorization for use this method</response>
        /// <response code="500">If the server has a problem</response>
        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public IActionResult Users(){
            try{
                var AllUsers = _repository.GetAllUsers();
                return Ok(AllUsers);
            }catch(Exception e){
                return StatusCode(500, e.Message);
            }
        }
        ///<summary>Get a specific user</summary>
        /// <response code="200">If get a users correctly</response>
        /// <response code="401">If you not authenticate</response>
        /// <response code="403">If you don't have authorization for use this method</response>
        /// <response code="404">If user doesnt exist</response>
        /// <response code="500">If the server has a problem</response>
        [HttpGet("{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult GetUser(long id){
            try{
                var user = _repository.GetUserWithId(id);
                if(user == null)
                    return NotFound("User with Id " + id + " doesnt exist" );
                return Ok(user);
            }catch(Exception e){
                return StatusCode(500, e.Message);
            }
        }
         ///<summary>Get user with id</summary>
        /// <response code="200">If get a user correctly</response>
        /// <response code="401">If you not authenticate</response>
        /// <response code="403">If you don't have authorization for use this method</response>
        /// <response code="404">If user doesnt exist</response>
        /// <response code="500">If the server has a problem</response>
        [HttpDelete("/api/Users/{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteUser(long id){
            try{
                var user = _repository.GetUserWithId(id);
                if(user == null)
                     return NotFound("User with Id " + id + " doesnt exist" );
                _repository.DeleteUser(user);
                return Ok();
            }catch(Exception e){
                return StatusCode(500, e.Message);
            }



        }

        
    }
}