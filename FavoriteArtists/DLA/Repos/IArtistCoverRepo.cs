namespace FavoriteArtists.DLA.Repos
{
    public interface IArtistCoverRepo
    {
        int GetProfileCoverByArtistId(int id);
    }
}
