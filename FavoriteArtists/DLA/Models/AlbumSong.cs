using FavoriteArtists.DLA.Models;

namespace FavoriteArtists.DLA.Repos
{
    public class AlbumSong : EntityBase
    {
        public int SongId { get; set; }
        public int AlbumId { get; set; }
    }
}
