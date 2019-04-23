using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public class AlbumSongRepo : IAlbumSongRepo
    {
        private ISongRepo _songRepo;

        public AlbumSongRepo(ISongRepo songRepo)
        {
            _songRepo = songRepo;
        }

        public List<Song> GetSongsByAlbumId(int id)
        {
            return _songRepo.GetSongsByAlbumId(id);
        }

        public List<Song> GetSingles()
        {
            return _songRepo.GetSingles();
        }
    }
}
