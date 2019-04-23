using System.Linq;
using System.Threading.Tasks;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface IArtistAlbumRepo
    {
        List<Album> GetAlbumsByArtistId(int id);
    }
}
