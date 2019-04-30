using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface IAlbumSongRepo
    {
        int GetNextId();
        Song Create(Song song);
        bool SongExists(Song song);
        List<Song> GetSongsByAlbumId(int id);
    }
}
