namespace FavoriteArtists.DLA.Repos
{
    public class ArtistCoverRepo : IArtistCoverRepo
    {
        private readonly ICoverRepo _coverRepo;
        public ArtistCoverRepo(ICoverRepo coverRepo)
        {
            _coverRepo = coverRepo;
        }
        public int GetProfileCoverByArtistId(int id)
        {
            return _coverRepo.GetArtistProfileCoverByArtistId(id);
        }
    }
}
