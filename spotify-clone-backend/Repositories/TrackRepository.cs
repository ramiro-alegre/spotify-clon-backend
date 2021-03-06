using Microsoft.EntityFrameworkCore;
using spotify_clone_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify_clone_backend.Repositories
{
    public class TrackRepository : RepositoryBase<Track>, ITrackRepository
    {
        public TrackRepository(SpotifyContext repositoryContext) : base(repositoryContext)
        {

        }
        public IEnumerable<Track> GetAllTracks()
        {
            return FindAll(source => source.Include(track => track.Artist)
                                           .Include(track => track.Duration)
                                            ).ToList();
        }

        public void UploadTrack(Track track){
            Create(track);
            SaveChanges();
        }

        public Track GetTrackWithId(long id){
            return FindByCondition(track => track.Id == id)
                   .Include(track => track.Artist)
                   .Include(track => track.Duration)
                   .FirstOrDefault();
        }

        public void DeleteTrack(Track track){
           Remove(track);
           SaveChanges();
        }
    }
}
