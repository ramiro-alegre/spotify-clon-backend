using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace spotify_clone_backend.Models
{
    public static class DbInitializer
    {
        public static void Initialize(SpotifyContext context)
        {
            if (!context.Tracks.Any())
            {
                var tracks = new Track[]
                {
                    new Track {
                        Name = "Getting Over",
                        Album = "One Love",
                        Cover = "https://jenesaispop.com/wp-content/uploads/2009/09/guetta_onelove.jpg",
                        Artist = new Artist
                        {
                            Name = "David Guetta",
                            Nickname = "David Guetta",
                            Nationality = "FR"
                        },
                        Duration = new Duration
                        {
                            Start = 0,
                            End = 333
                        },
                        Url = "../assets/songs/track.mp3"
                    },

                    new Track {
                        Name = "Snow Tha Product || BZRP Music Sessions #39",
                        Album = "BZRP Music Sessions",
                        Cover = "https://is5-ssl.mzstatic.com/image/thumb/Features125/v4/9c/b9/d0/9cb9d017-fcf6-28c6-81d0-e9ac5b0f359e/pr_source.png/800x800cc.jpg",
                        Artist = new Artist
                        {
                            Name = "Snow",
                            Nickname = "Snow",
                            Nationality = "US"
                        },
                        Duration = new Duration
                        {
                            Start = 0,
                            End = 333
                        },
                        Url = "../assets/songs/track-1.mp3"
                    },

                    new Track {
                        Name = "Calypso (Original Mix)",
                        Album = "Round Table Knights",
                        Cover = "https://cdns-images.dzcdn.net/images/cover/1db3f8f185e68f26feaf0b9d72ff1645/350x350.jpg",
                        Artist = new Artist
                        {
                            Name = "Round Table Knights",
                            Nickname = "Round Table Knights",
                            Nationality = "US"
                        },
                        Duration = new Duration
                        {
                            Start = 0,
                            End = 333
                        },
                        Url = "../assets/songs/track-2.mp3"
                    },

                    new Track {
                        Name = "Bad Habits",
                        Album = "Ed Sheeran",
                        Cover = "https://www.lahiguera.net/musicalia/artistas/ed_sheeran/disco/11372/tema/25301/ed_sheeran_bad_habits-portada.jpg",
                        Artist = new Artist
                        {
                            Name = "Ed Sheeran",
                            Nickname = "Ed Sheeran",
                            Nationality = "UK"
                        },
                        Duration = new Duration
                        {
                            Start = 0,
                            End = 333
                        },
                        Url = "../assets/songs/track-4.mp3"
                    },

                    new Track {
                        Name = "BEBE (Official Video)",
                        Album = "Giolì & Assia",
                        Cover = "https://i.scdn.co/image/ab67616d0000b27345ca41b0d2352242c7c9d4bc",
                        Artist = new Artist
                        {
                            Name = "Giolì & Assia",
                            Nickname = "Giolì & Assia",
                            Nationality = "IT"
                        },
                        Duration = new Duration
                        {
                            Start = 0,
                            End = 333
                        },
                        Url = "../assets/songs/track-3.mp3"
                    },

                    new Track {
                        Name = "T.N.T. (Live At River Plate, December 2009)",
                        Album = "AC/DC",
                        Cover = "https://cdns-images.dzcdn.net/images/cover/ba5eaf2f3a49768164d0728b7ba64372/500x500.jpg",
                        Artist = new Artist
                        {
                            Name = "AC/DC",
                            Nickname = "AC/DC",
                            Nationality = "US"
                        },
                        Duration = new Duration
                        {
                            Start = 0,
                            End = 333
                        },
                        Url = "../assets/songs/track-5.mp3"
                    },

                    new Track {
                        Name = "50 Cent - Candy Shop (feat. Olivia)",
                        Album = "50 Cent",
                        Cover = "https://i.scdn.co/image/ab67616d0000b27391f7222996c531b981e7bb3d",
                        Artist = new Artist
                        {
                            Name = "50 Cent",
                            Nickname = "50 Cent",
                            Nationality = "US"
                        },
                        Duration = new Duration
                        {
                            Start = 0,
                            End = 333
                        },
                        Url = "../assets/songs/track-6.mp3"
                    },

                    new Track {
                        Name = "Bésame💋",
                        Album = "Valentino Ft MTZ Manuel Turizo (Video Oficial)",
                        Cover = "https://i1.sndcdn.com/artworks-000247627460-1hqnjr-t500x500.jpg",
                        Artist = new Artist
                        {
                            Name = "Valentino",
                            Nickname = "Valentino",
                            Nationality = "CO"
                        },
                        Duration = new Duration
                        {
                            Start = 0,
                            End = 333
                        },
                        Url = "../assets/songs/track-7.mp3"
                    },

                };

                foreach (Track t in tracks)
                {
                    context.Tracks.Add(t);
                }
                context.SaveChanges();
            }
        }
    }
}
