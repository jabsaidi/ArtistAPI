using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public static class DataGenerator
    {
        private static Cover _cover = new Cover() { PlayListId = null, ImagePath = "Images/Astroworld.jpg", Id = 1, ArtistId = 1, AlbumId = 1, IsProfilePicture = false};
        private static Cover _profileCover = new Cover() { PlayListId = null, ImagePath = "Images/Travis.jpg", Id = 2, ArtistId = 1, IsProfilePicture = true};

        public static List<Artist> GenerateArtists()
        {
            List<Artist> artists = new List<Artist>();
            artists.Add(new Artist() { Id = 1, Name = "Travis Scott", IsGroup = false, Style = "His own", Description = "GOAT. No cap." });
            artists.Add(new Artist() { Id = 2, Name = "Pnl", IsGroup = true, Style = "Cloud Rap", Description = "French cloud rapers" });
            artists.Add(new Artist() { Id = 3, Name = "Brayden & $erna", IsGroup = true, Style = "Hip-Hop", Description = "Upcoming artists from Sherbrooke City." });
            artists.Add(new Artist() { Id = 4, Name = "DISIZ", IsGroup = false, Style = "Rap", Description = "Un daron du rap francais." });
            artists.Add(new Artist() { Id = 5, Name = "Chris Brown", IsGroup = false, Style = "R&B", Description = "Greatest overall artist of all time, but also the most hated of all time." });
            artists.Add(new Artist() { Id = 6, Name = "Dinos", IsGroup = false, Style = "Rap", Description = "Jeune rapeur francais. PUNCHLINES!" });
            return artists;
        }

        public static List<Playlist> GeneratePlaylist()
        {
            List<Playlist> playlists = new List<Playlist>();
            var song1 = new Song() { Id = 18, AlbumId = 1, ArtistId = 1, Duration = 3.08, Name = "Mamacita" };
            var song2 = new Song() { Id = 19, AlbumId = 1, ArtistId = 1, Duration = 3.18, Name = "Uptown" };
            var song3 = new Song() { Id = 20, AlbumId = 1, ArtistId = 1, Duration = 4.04, Name = "Stronger" };
            var song4 = new Song() { Id = 21, AlbumId = 1, ArtistId = 1, Duration = 5.35, Name = "Atlantis" };
            var song5 = new Song() { Id = 22, AlbumId = 1, ArtistId = 1, Duration = 3.46, Name = "Animal" };
            var songsList = new List<Song>() { song1, song2, song3, song4, song5 };
            playlists.Add(new Playlist() { Id = 1, Name = "Rage", Songs = songsList });
            return playlists;
        }

        public static List<Album> GenerateAlbum()
        {
            List<Album> albums = new List<Album>();
            albums.Add(new Album() { Id = 1, ArtistId = 1, Name = "Astroworld" });
            return albums;
        }

        public static List<Song> GenerateSongs()
        {
            List<Song> songs = new List<Song>();
            songs.Add(new Song() { Id = 1, Name = "Stargazing", ArtistId = 1, Duration = 4.31, AlbumId = 1 });
            songs.Add(new Song() { Id = 2, Name = "Carousel", ArtistId = 1, Duration = 3, AlbumId = 1 });
            songs.Add(new Song() { Id = 3, Name = "Sicko Mode", ArtistId = 1, Duration = 5.13, AlbumId = 1 });
            songs.Add(new Song() { Id = 4, Name = "R.I.P Screw", ArtistId = 1, Duration = 3.06, AlbumId = 1 });
            songs.Add(new Song() { Id = 5, Name = "Stop Trying To Be God", ArtistId = 1, Duration = 5.38, AlbumId = 1 });
            songs.Add(new Song() { Id = 6, Name = "No Bystanders", ArtistId = 1, Duration = 3.38, AlbumId = 1 });
            songs.Add(new Song() { Id = 7, Name = "Skeletons", ArtistId = 1, Duration = 2.26, AlbumId = 1 });
            songs.Add(new Song() { Id = 8, Name = "Wake Up", ArtistId = 1, Duration = 3.52, AlbumId = 1 });
            songs.Add(new Song() { Id = 9, Name = "5% Tint", ArtistId = 1, Duration = 3.16, AlbumId = 1 });
            songs.Add(new Song() { Id = 10, Name = "NC-17", ArtistId = 1, Duration = 2.37, AlbumId = 1 });
            songs.Add(new Song() { Id = 11, Name = "Astrothunder", ArtistId = 1, Duration = 2.23, AlbumId = 1 });
            songs.Add(new Song() { Id = 12, Name = "Yosemite", ArtistId = 1, Duration = 2.30, AlbumId = 1 });
            songs.Add(new Song() { Id = 13, Name = "Can't Say", ArtistId = 1, Duration = 3.18, AlbumId = 1 });
            songs.Add(new Song() { Id = 14, Name = "Who? What!", ArtistId = 1, Duration = 2.57, AlbumId = 1 });
            songs.Add(new Song() { Id = 15, Name = "ButterFly Effect", ArtistId = 1, Duration = 3.11, AlbumId = 1 });
            songs.Add(new Song() { Id = 16, Name = "Houstonfornication", ArtistId = 1, Duration = 3.38, AlbumId = 1 });
            songs.Add(new Song() { Id = 17, Name = "Coffee Bean", ArtistId = 1, Duration = 3.29, AlbumId = 1 });
            return songs;
        }

        public static List<Cover> GenerateCovers()
        {
            List<Cover> covers = new List<Cover>();
            covers.Add(_cover);
            covers.Add(_profileCover);
            return covers;
        }
    }
}
