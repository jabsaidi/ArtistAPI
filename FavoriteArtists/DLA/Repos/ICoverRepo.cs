using System.Linq;
using System.Threading.Tasks;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface ICoverRepo : IBaseRepo<Cover>
    {
        int GetCoverByAlbumId(int id);
        List<Cover> GetProfileCovers();
        int GetCoverByPlaylistId(int id);
        int GetArtistProfileCoverByArtistId(int id);
    }
}
