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
    public class TracksController : ControllerBase
    {
        private ITrackRepository _repository;

        public TracksController(ITrackRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try{

                var tracks = _repository.GetAllTracks();   
                return Ok(tracks);

            }catch(Exception e){

                return StatusCode(500, e.Message);

            }      
        }

        [HttpPut]
        [Authorize(Roles ="Administrator")]
        public IActionResult UploadTrack([FromBody] Track track){
            try{
                _repository.UploadTrack(track);
                return Ok();
            }catch(Exception e){
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("/api/Tracks/{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteTrack(long id){
            try{
                var track = _repository.GetTrackWithId(id);
                _repository.DeleteTrack(track);
                return Ok();
            }catch(Exception e){
                return StatusCode(500, e.Message);
            }
        }
        
    }
}
