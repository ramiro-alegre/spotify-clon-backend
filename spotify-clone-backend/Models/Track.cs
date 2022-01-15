using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace spotify_clone_backend.Models
{
    public class Track
    {
        public long Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Album { get; set; }
        [Required]
        public string Cover { get; set; }
        [Required]
        public Artist Artist { get; set; }
        [Required]
        public Duration Duration { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
