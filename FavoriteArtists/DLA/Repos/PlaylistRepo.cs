using System.Linq;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public class PlaylistRepo : IPlaylistRepo
    {
        private static List<Playlist> _playlists = new List<Playlist>();

        public PlaylistRepo()
        {
            if (_playlists.Count == 0)
                InitData();
        }

        private void InitData()
        {
            var song1 = new Song() { Id = 18, AlbumId = 1, ArtistId = 1, Duration = 3.08, Name = "Mamacita" };
            var song2 = new Song() { Id = 19, AlbumId = 1, ArtistId = 1, Duration = 3.08, Name = "Uptown" };
            var song3 = new Song() { Id = 20, AlbumId = 1, ArtistId = 1, Duration = 3.08, Name = "Stronger" };
            var song4 = new Song() { Id = 21, AlbumId = 1, ArtistId = 1, Duration = 3.08, Name = "Atlantis" };
            var song5 = new Song() { Id = 22, AlbumId = 1, ArtistId = 1, Duration = 3.08, Name = "Animal" };

            var songs = new List<Song>() { song1, song2, song3, song4, song5};

            _playlists.Add(new Playlist() {Id = 1, Name = "Rage", Songs = songs });
        }

        public List<Playlist> GetAllPlaylists()
        {
            return _playlists;
        }

        public Playlist GetPlaylistById(int id)
        {
            return _playlists.FirstOrDefault(p=>p.Id == id);
        }

        public Playlist Create(Playlist playlist)
        {
            var exists = _playlists.FirstOrDefault(p => p.Id == playlist.Id);
            if(exists == null)
            {
                _playlists.Add(playlist);
                return playlist;
            }
            else
                return null;
        }

        public int GetNextId()
        {
            return _playlists.Count + 1;
        }
    }
}
