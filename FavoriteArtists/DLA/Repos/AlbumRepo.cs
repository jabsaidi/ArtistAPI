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
                    albums.Add(album);
                    album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);
                    album.CoverId = _albumCoverRepo.GetCoverByAlbumId(album.Id);
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

        public Album GetAlbumByName(string name)
        {
            Album album = _albums.FirstOrDefault(a => a.Name == name);
            album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);
            album.CoverId = _albumCoverRepo.GetCoverByAlbumId(album.Id);
            return album;
        }

        public Song GetSongFromAlbum(Album album, string song)
        {
            Song foundSong = new Song();
            foreach (Song _song in album.Songs)
            {
                if (_song.Name == song)
                {
                    foundSong = _song;
                    break;
                }
            }
            return foundSong;
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