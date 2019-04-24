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
                _playlists = DataGenerator.GeneratePlaylist();
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
