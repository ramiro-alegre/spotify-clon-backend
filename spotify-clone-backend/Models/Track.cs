using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify_clone_backend.Models
{
    public class Track
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Album { get; set; }
        public string Cover { get; set; }
        public Artist Artist { get; set; }
        public Duration Duration { get; set; }
        public string Url { get; set; }
    }
}
