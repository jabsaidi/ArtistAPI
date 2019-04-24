using System;
using System.Linq;
using System.Threading.Tasks;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public interface IArtistRepo
    {
        int GetNextId();
        bool Delete(int id);
        List<Artist> GetAll();
        List<Artist> GetGroups();
        List<Artist> GetRapers();
        Artist GetArtistById(int id);
        Artist Create(Artist newArtist);
        Artist GetArtistByName(string name);
        Artist ModifyArtist(Artist artistToBeModified);
    }
}
