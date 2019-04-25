using FavoriteArtists.DLA.Models;
using System.Collections.Generic;
using System.Linq;

namespace FavoriteArtists.DLA.Repos
{
    public interface IPlaylistCoverRepo
    {
        int GetPlaylistCoverById(int id);
    }

    public class PlaylistCoverRepo : IPlaylistCoverRepo
    {
        private readonly ICoverRepo _coverRepo;
        public PlaylistCoverRepo(ICoverRepo coverRepo)
        {
            _coverRepo = coverRepo;
        }

        public int GetPlaylistCoverById(int id)
        {
            return _coverRepo.GetCoverByPlaylistId(id);
        }
    }

    public class PlaylistRepo : IPlaylistRepo
    {
        private readonly IPlaylistCoverRepo _playlistCoverRepo;
        private static List<Playlist> _playlists = new List<Playlist>();

        public PlaylistRepo(IPlaylistCoverRepo playlistCoverRepo)
        {
            if (_playlists.Count == 0)
                _playlists = DataGenerator.GeneratePlaylist();
            _playlistCoverRepo = playlistCoverRepo;
        }

        public List<Playlist> GetAllPlaylists()
        {
            return _playlists;
        }

        public Playlist GetPlaylistById(int id)
        {
            Playlist playlist = _playlists.FirstOrDefault(p => p.Id == id);
            playlist.CoverId = _playlistCoverRepo.GetPlaylistCoverById(playlist.Id);
            return playlist;
        }

        public Playlist Create(Playlist playlist)
        {
            var exists = _playlists.FirstOrDefault(p => p.Id == playlist.Id);
            if (exists == null)
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
