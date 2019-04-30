using FavoriteArtists.DLA.Models;
using FavoriteArtists.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace FavoriteArtists.DLA.Repos
{
    public class PlaylistRepo : IPlaylistRepo
    {
        private static int _startup = 0;
        private readonly IPlaylistCoverRepo _playlistCoverRepo;
        private static List<Playlist> _playlists = new List<Playlist>();

        public PlaylistRepo(IPlaylistCoverRepo playlistCoverRepo)
        {
            _startup++;
            if (_startup == 1)
                _playlists = DataGenerator.GeneratePlaylist();

            _playlistCoverRepo = playlistCoverRepo;
        }

        public List<Playlist> GetAll()
        {
            return _playlists;
        }

        public Playlist GetById(int id)
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

        public Playlist Update(Playlist playlist)
        {
            var toUpdate = GetById(playlist.Id);
            if (toUpdate == null)
                return null;

            toUpdate.CoverId = playlist.CoverId;
            toUpdate.Name = playlist.Name;
            toUpdate.Songs = playlist.Songs;

            return toUpdate;
        }

        public List<Playlist> GetPlaylistsByName(string name)
        {
            name = name.FirstCharToUpper();

            List<Playlist> playlists = _playlists.Where(p => p.Name == name).Select(playlist =>
                {
                    playlist.CoverId = _playlistCoverRepo.GetPlaylistCoverById(playlist.Id);
                    return playlist;
                }).ToList();
            return playlists;
        }

        public bool Delete(int id)
        {
            Playlist tobeDeleted = _playlists.FirstOrDefault(p => p.Id == id);

            _playlists.Remove(tobeDeleted);
            return true;
        }
    }
}
