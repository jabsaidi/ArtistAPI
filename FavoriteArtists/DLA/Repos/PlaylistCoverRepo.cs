namespace FavoriteArtists.DLA.Repos
{
    public class PlaylistCoverRepo : IPlaylistCoverRepo
    {
        private readonly ICoverRepo _coverRepo;
        public PlaylistCoverRepo(ICoverRepo coverRepo)
        {
            _coverRepo = coverRepo;
        }

        public int GetPlaylistCoverById(int id)
        {
            return _coverRepo.GetCoverByPlaylistId(id);
        }
    }
}
