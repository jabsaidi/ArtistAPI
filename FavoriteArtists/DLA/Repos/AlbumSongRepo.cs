using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public class AlbumSongRepo : IAlbumSongRepo
    {
        private readonly ISongRepo _songRepo;
        private readonly IBaseRepo<Song> _baseRepo;

        public AlbumSongRepo(ISongRepo songRepo, IBaseRepo<Song> baseRepo)
        {
            _baseRepo = baseRepo;
            _songRepo = songRepo;
        }

        public Song Create(Song song)
        {
            return _baseRepo.Create(song);
        }

        public int GetNextId()
        {
            return _baseRepo.GetNextId();
        }

        public List<Song> GetSongsByAlbumId(int id)
        {
            return _songRepo.GetSongsByAlbumId(id);
        }

        public bool SongExists(Song song)
        {
            return _songRepo.SongExists(song);
        }
    }
}
