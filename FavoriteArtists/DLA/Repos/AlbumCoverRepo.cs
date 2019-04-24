using FavoriteArtists.DLA.Models;

namespace FavoriteArtists.DLA.Repos
{
    public class AlbumCoverRepo : IAlbumCoverRepo
    {
        private readonly ICoverRepo _coverRepo;

        public AlbumCoverRepo(ICoverRepo coverRepo)
        {
            _coverRepo = coverRepo;
        }

        public int GetCoverByAlbumId(int id)
        {
            return _coverRepo.GetCoverByAlbumId(id);
        }
    }
}
