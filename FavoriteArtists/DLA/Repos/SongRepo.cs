using System.Linq;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public class SongRepo : ISongRepo
    {
        private static List<Song> _songs = new List<Song>();

        public SongRepo()
        {
            if (_songs.Count == 0)
                InitData();
        }

        public void InitData()
        {
            _songs.Add(new Song() { Id = 1, Name = "Stargazing", ArtistId = 1, Duration = 4.31, AlbumId = 1 });
            _songs.Add(new Song() { Id = 2, Name = "Carousel", ArtistId = 1, Duration = 3, AlbumId = 1 });
            _songs.Add(new Song() { Id = 3, Name = "Sicko Mode", ArtistId = 1, Duration = 5.13, AlbumId = 1 });
            _songs.Add(new Song() { Id = 4, Name = "R.I.P Screw", ArtistId = 1, Duration = 3.06, AlbumId = 1 });
            _songs.Add(new Song() { Id = 5, Name = "Stop Trying To Be God", ArtistId = 1, Duration = 5.38, AlbumId = 1 });
            _songs.Add(new Song() { Id = 6, Name = "No Bystanders", ArtistId = 1, Duration = 3.38, AlbumId = 1 });
            _songs.Add(new Song() { Id = 7, Name = "Skeletons", ArtistId = 1, Duration = 2.26, AlbumId = 1 });
            _songs.Add(new Song() { Id = 8, Name = "Wake Up", ArtistId = 1, Duration = 3.52, AlbumId = 1 });
            _songs.Add(new Song() { Id = 9, Name = "5% Tint", ArtistId = 1, Duration = 3.16, AlbumId = 1 });
            _songs.Add(new Song() { Id = 10, Name = "NC-17", ArtistId = 1, Duration = 2.37, AlbumId = 1 });
            _songs.Add(new Song() { Id = 11, Name = "Astrothunder", ArtistId = 1, Duration = 2.23, AlbumId = 1 });
            _songs.Add(new Song() { Id = 12, Name = "Yosemite", ArtistId = 1, Duration = 2.30, AlbumId = 1 });
            _songs.Add(new Song() { Id = 13, Name = "Can't Say", ArtistId = 1, Duration = 3.18, AlbumId = 1 });
            _songs.Add(new Song() { Id = 14, Name = "Who? What!", ArtistId = 1, Duration = 2.57, AlbumId = 1 });
            _songs.Add(new Song() { Id = 15, Name = "ButterFly Effect", ArtistId = 1, Duration = 3.11, AlbumId = 1 });
            _songs.Add(new Song() { Id = 16, Name = "Houstonfornication", ArtistId = 1, Duration = 3.38, AlbumId = 1 });
            _songs.Add(new Song() { Id = 17, Name = "Coffee Bean", ArtistId = 1, Duration = 3.29, AlbumId = 1 });
        }
        public Song Create(Song newSong)
        {
            if (newSong.Duration != 0 && NotNull(newSong.Name) && newSong.ArtistId != 0)
            {
                _songs.Add(newSong);
                return newSong;
            }
            else
                return null;
        }

        public List<Song> GetAll()
        {
            return _songs;
        }

        public bool NotNull(params string[] inputs)
        {
            bool notNull = true;
            foreach(string input in inputs)
            {
                if(input == null)
                {
                    notNull = false;
                    break;
                }
            }
            return notNull;
        }

        public List<Song> GetSongsByArtistId(int id)
        {
            List<Song> songs = new List<Song>();

            foreach (Song song in _songs)
            {
                if (song.ArtistId == id)
                    songs.Add(song);
            }
            return songs;
        }

        public int GetNextId()
        {
            return _songs.Count + 1;
        }

        public List<Song> GetSongsByAlbumId(int id)
        {
            List<Song> songs = new List<Song>();

            foreach (Song song in _songs)
            {
                if (song.ArtistId == id)
                    songs.Add(song);
                if (song.AlbumId == 0)
                    GetSingles();
            }
            return songs;
        }

        public List<Song> GetSingles()
        {
            var singles = new List<Song>();

            foreach(Song song in _songs)
            {
                if (song.AlbumId == 0)
                    singles.Add(song);
            }
            return singles;
        }
    }
}
