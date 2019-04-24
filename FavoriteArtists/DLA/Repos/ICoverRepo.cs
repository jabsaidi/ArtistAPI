using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FavoriteArtists.DLA.Models;

namespace FavoriteArtists.DLA.Repos
{
    public interface ICoverRepo
    {
        int GetNextId();
        List<Cover> GetAll();
        Cover Create(Cover cover);
        int GetCoverByAlbumId(int id);
        int GetArtistProfileCoverByArtistId(int id);
    }
}
