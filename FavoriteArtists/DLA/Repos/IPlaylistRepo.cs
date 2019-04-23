using System;
using System.Linq;
using System.Threading.Tasks;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface IPlaylistRepo
    {
        int GetNextId();
        Playlist GetPlaylistById(int id);
        List<Playlist> GetAllPlaylists();
        Playlist Create(Playlist playlist);
    }
}
