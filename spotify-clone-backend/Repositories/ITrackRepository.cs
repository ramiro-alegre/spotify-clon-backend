using spotify_clone_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify_clone_backend.Repositories
{
    public interface ITrackRepository
    {
        IEnumerable<Track> GetAllTracks();
        void UploadTrack(Track track);
        Track GetTrackWithId(long id);
        void DeleteTrack(Track track);
    }
}
