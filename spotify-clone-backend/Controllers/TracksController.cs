using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using spotify_clone_backend.Models;
using spotify_clone_backend.Repositories;
using System;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace spotify_clone_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class TracksController : ControllerBase
    {
        private ITrackRepository _repository;

        public TracksController(ITrackRepository repository)
        {
            _repository = repository;
        }
        /// <summary>Get all tracks</summary>
        /// <response code="200">If get all songs correctly</response>
        /// <response code="401">If you not authenticate</response>
        /// <response code="500">If the server has a problem</response>
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
        /// <summary>Get track with Id</summary>
        /// <response code="200">If get all songs correctly</response>
        /// <response code="401">If you not authenticate</response>
        /// <response code="403">If you don't have authorization for use this method</response>
        /// <response code="500">If the server has a problem</response>
        [HttpGet("{id}")]
        [Authorize(Roles="Administrator")]
        public IActionResult GetTrack(long id){

            try{
                var track = _repository.GetTrackWithId(id);
                if(track == null)
                     return NotFound("Song with Id " + id + " doesnt exist" );
                return Ok(track);
                
            } catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
   
        }

        /// <summary>Upload a track</summary>
        /// <remarks>
        /// Sample request:
        ///      
        ///      POST /Tracks 
        ///      {
        ///        "id": 0,
        ///        "name": "Me estas tentando",
        ///        "album": "Me estas tentando",
        ///        <![CDATA["cover": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ9o_E4nq6SmI0U8Rfv0IV1t_eaTmBLbqnGzg&usqp=CAU",]]>
        ///        "artist": {
        ///          "id": 0,
        ///          <![CDATA["name": "Wisin & Yandel",]]>
        ///          <![CDATA["nickname": "Wisin & Yandel",]]>
        ///          "nationality": "PR"
        ///        },
        ///        "duration": {
        ///          "id": 0,
        ///          "start": 0,
        ///          "end": 333
        ///        },
        ///        "url": "../assets/songs/track-8.mp3"
        ///      }
        /// </remarks>
        /// <param name="track">Json of Track with Artist and Duration</param>
        /// <response code="200">If the song has correct uploaded</response>
        /// <response code="401">If you not authenticate</response>
        /// <response code="403">If you don't have authorization for use this method</response>
        /// <response code="500">If the server has a problem</response>
        [HttpPost]
        [Authorize(Roles ="Administrator")]
        public IActionResult UploadTrack([FromBody] Track track){
            try{
                _repository.UploadTrack(track);
                return Ok();
            }catch(Exception e){
                return StatusCode(500, e.Message);
            }
        }
        

        
        /// <summary>
        /// Delete a specific track.
        /// </summary>
        /// <param name="id">Specify Id for the song you want to delete</param>
        /// <response code="200">If the song has correct deleted</response>
        /// <response code="401">If you not authenticate</response>
        /// <response code="403">If you don't have authorization for use this method</response>
        /// <response code="404">If the song with the id you sent does not exist</response>
        /// <response code="500">If the server has a problem</response>
        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrator")]
        public IActionResult DeleteTrack(long id){
            try{
                var track = _repository.GetTrackWithId(id);
                if(track == null)
                    return NotFound("Song with Id " + id + " doesnt exist" );
                _repository.DeleteTrack(track);
                return Ok();
            }catch(Exception e){
                return StatusCode(500, e.Message);
            }
        }
         
        
    }
}
