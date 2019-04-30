using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface IArtistRepo : IBaseRepo<Artist>
    {
        List<Artist> GetGroups();
        List<Artist> GetRapers();
        Artist GetArtistByName(string name);
        List<Artist> GetArtistsByName(string name);
    }
}
