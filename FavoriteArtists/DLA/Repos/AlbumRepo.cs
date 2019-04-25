using FavoriteArtists.DLA.Models;
using System.Collections.Generic;
using System.Linq;

namespace FavoriteArtists.DLA.Repos
{
    public class AlbumRepo : IAlbumRepo
    {
        private IAlbumSongRepo _albumSongRepo;
        private readonly IAlbumCoverRepo _albumCoverRepo;
        private static List<Album> _albums = new List<Album>();

        public AlbumRepo(IAlbumCoverRepo albumCoverRepo, IAlbumSongRepo albumSongRepo)
        {
            if (_albums.Count == 0)
                _albums = DataGenerator.GenerateAlbum();

            _albumSongRepo = albumSongRepo;
            _albumCoverRepo = albumCoverRepo;
        }

        public List<Album> GetAlbumsByArtistId(int id)
        {
            var albums = new List<Album>();
            foreach (var album in _albums)
            {
                if (album.ArtistId == id)
                {
                    album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);
                    album.CoverId = _albumCoverRepo.GetCoverByAlbumId(album.Id);
                    albums.Add(album);
                }
            }
            return albums;
        }

        public List<Album> GetAll()
        {
            foreach (var album in _albums)
            {
                album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);
                album.CoverId = _albumCoverRepo.GetCoverByAlbumId(album.Id);
            }
            return _albums;
        }

        public List<Album> GetAlbumsByName(string name)
        {
            List<Album> albums = new List<Album>();
            foreach (var album in _albums)
            {
                if (album.Name == name)
                {
                    album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);
                    album.CoverId = _albumCoverRepo.GetCoverByAlbumId(album.Id);
                    albums.Add(album);
                }
            }
            return albums;
        }

        public Album GetById(int id)
        {
            Album album = _albums.FirstOrDefault(a => a.Id == id);
            album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);
            album.CoverId = _albumCoverRepo.GetCoverByAlbumId(album.Id);
            return album;
        }
    }
}