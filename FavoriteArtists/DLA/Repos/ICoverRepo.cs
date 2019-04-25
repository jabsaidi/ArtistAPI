using System.Linq;
using System.Threading.Tasks;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface ICoverRepo
    {
        int GetNextId();
        List<Cover> GetAll();
        Cover GetById(int id);
        Cover Create(Cover cover);
        int GetCoverByAlbumId(int id);
        List<Cover> GetProfileCovers();
        Cover Update(Cover updatedCover);
        int GetCoverByPlaylistId(int id);
        int GetArtistProfileCoverByArtistId(int id);
    }
}
