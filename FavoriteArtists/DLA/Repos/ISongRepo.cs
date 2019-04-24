using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface ISongRepo
    {
        int GetNextId();
        List<Song> GetAll();
        List<Song> GetSingles();
        Song Create(Song newSong);
        int GetSongCoverByAlbumId(int id);
        List<Song> GetSongsByAlbumId(int id);
        List<Song> GetSongsByArtistId(int id);
    }
}
