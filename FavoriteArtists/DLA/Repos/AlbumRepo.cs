using FavoriteArtists.DLA.Models;
using System.Collections.Generic;
using System.Linq;

namespace FavoriteArtists.DLA.Repos
{
    public class AlbumRepo : IAlbumRepo, IBaseRepo<Album>
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
            List<Album> albums = _albums.Where(a => a.ArtistId == id)
                .Select(album =>
                {
                    album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);
                    album.CoverId = _albumCoverRepo.GetCoverByAlbumId(album.Id);
                    return album;
                }).ToList();
            return albums;
        }

        public List<Album> GetAll()
        {
            foreach (var album in _albums)
            {
                if (album.Songs.Count == 0)
                    album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);

                album.CoverId = _albumCoverRepo.GetCoverByAlbumId(album.Id);
            }
            return _albums;
        }

        public List<Album> GetAlbumsByName(string name)
        {
            List<Album> albums = _albums.Where(a => a.Name == name).Select(album =>
            {
                album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);
                album.CoverId = _albumCoverRepo.GetCoverByAlbumId(album.Id);
                return album;
            }).ToList();
            return albums;
        }

        public Album GetById(int id)
        {
            Album album = _albums.FirstOrDefault(a => a.Id == id);
            if (album == null)
                return null;

            if (album.Songs.Count == 0)
                album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);

            album.CoverId = _albumCoverRepo.GetCoverByAlbumId(album.Id);
            return album;
        }

        public int GetNextId()
        {
            return _albums.Count + 1;
        }

        public Album Create(Album newAlbum)
        {
            var exists = GetById(newAlbum.Id);
            if (exists != null)
                return null;
            foreach (var song in newAlbum.Songs)
                _albumSongRepo.Create(song);

            _albums.Add(newAlbum);
            return newAlbum;
        }

        public Album Update(Album updatedAlbum)
        {
            Album tobeUpdated = GetById(updatedAlbum.Id);
            if (tobeUpdated == null)
                return null;
            foreach (var song in tobeUpdated.Songs)
                song.IsActive = false;

            tobeUpdated.Name = updatedAlbum.Name;
            tobeUpdated.Songs = updatedAlbum.Songs;
            tobeUpdated.CoverId = updatedAlbum.CoverId;
            tobeUpdated.ArtistId = updatedAlbum.ArtistId;

            foreach (var song in tobeUpdated.Songs)
            {
                if (song.Id == 0)
                    song.Id = _albumSongRepo.GetNextId();

                if (!_albumSongRepo.SongExists(song))
                    _albumSongRepo.Create(song);
            }

            return tobeUpdated;
        }
    }
}