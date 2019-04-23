using System;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public class ArtistAlbumRepo : IArtistAlbumRepo
    {
        private IAlbumRepo _albumRepo;

        public ArtistAlbumRepo(IAlbumRepo albumRepo)
        {
            _albumRepo = albumRepo;
        }
        public List<Album> GetAlbumsByArtistId(int id)
        {
            return _albumRepo.GetAlbumsByArtistId(id);
        }
    }
}
