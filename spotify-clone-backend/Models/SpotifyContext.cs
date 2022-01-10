using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify_clone_backend.Models
{
    public class SpotifyContext : DbContext
    {
        public SpotifyContext(DbContextOptions<SpotifyContext> options)
           : base(options)
        {
        }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Duration> Durations { get; set; }
    }
}
