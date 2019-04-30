using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface ISongRepo : IBaseRepo<Song>
    {
        bool SongExists(Song song);
        int GetSongCoverByAlbumId(int id);
        List<Song> GetSongsByAlbumId(int id);
        List<Song> GetSongsByArtistId(int id);
        List<Song> GetSongsByName(string name);
    }
}
