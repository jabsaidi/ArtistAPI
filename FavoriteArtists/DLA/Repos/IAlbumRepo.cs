using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface IAlbumRepo : IBaseRepo<Album>
    {
        List<Album> GetAlbumsByArtistId(int id);
        List<Album> GetAlbumsByName(string name);
    }
}
