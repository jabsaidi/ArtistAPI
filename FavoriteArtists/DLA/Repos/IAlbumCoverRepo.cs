using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoriteArtists.DLA.Models;

namespace FavoriteArtists.DLA.Repos
{
    public interface IAlbumCoverRepo
    {
        int GetCoverByAlbumId(int id);
    }
}
