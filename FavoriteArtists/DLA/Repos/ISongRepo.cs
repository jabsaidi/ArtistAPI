using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface ISongRepo
    {
        int GetNextId();
        List<Song> GetAll();
        Song GetById(int id);
        Song Create(Song newSong);
        Song UpdateSong(Song song);
        int GetSongCoverByAlbumId(int id);
        List<Song> GetSongsByAlbumId(int id);
        List<Song> GetSongsByArtistId(int id);
        List<Song> GetSongsByName(string name);
    }
}
