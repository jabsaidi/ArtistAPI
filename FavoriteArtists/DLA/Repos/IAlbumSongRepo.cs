using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface IAlbumSongRepo
    {
        List<Song> GetSongsByAlbumId(int id);
    }
}
