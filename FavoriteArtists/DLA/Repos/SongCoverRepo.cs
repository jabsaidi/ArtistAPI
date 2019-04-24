namespace FavoriteArtists.DLA.Repos
{
    public class SongCoverRepo : ISongCoverRepo
    {
        private readonly ICoverRepo _coverRepo;
        public SongCoverRepo(ICoverRepo coverRepo)
        {
            _coverRepo = coverRepo;
        }

        public int GetSongCoverByAlbumId(int id)
        {
            return _coverRepo.GetCoverByAlbumId(id);
        }
    }
}
