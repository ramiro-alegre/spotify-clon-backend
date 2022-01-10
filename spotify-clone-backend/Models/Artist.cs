using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify_clone_backend.Models
{
    public class Artist
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Nickname { get; set; }
        public string Nationality { get; set; }
    }
}
