using FavoriteArtists.DLA.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteArtists.DLA.Repos.FileRepos
{
    public interface ISongFileRepo
    {
        List<Song> GetAllSongs();
        Song Create(Song newSong);
    }
}
