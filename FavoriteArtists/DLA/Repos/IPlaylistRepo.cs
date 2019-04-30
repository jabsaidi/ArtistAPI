using System;
using System.Linq;
using System.Threading.Tasks;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface IPlaylistRepo : IBaseRepo<Playlist>
    {
        List<Playlist> GetPlaylistsByName(string name);
    }
}
