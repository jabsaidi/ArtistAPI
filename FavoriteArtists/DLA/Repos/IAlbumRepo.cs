using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface IAlbumRepo
    {
        List<Album> GetAll();
        Album GetById(int id);
        List<Album> GetAlbumsByName(string name);
        List<Album> GetAlbumsByArtistId(int id);
    }
}
