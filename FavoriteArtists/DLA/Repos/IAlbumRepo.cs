using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface IAlbumRepo
    {
        List<Album> GetAll();
        Album GetAlbumByName(string name);
        List<Album> GetAlbumsByArtistId(int id);
        Song GetSongFromAlbum(Album album, string song);
    }
}
