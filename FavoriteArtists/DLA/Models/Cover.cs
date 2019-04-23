namespace FavoriteArtists.DLA.Models
{
    public class Cover : EntityBase
    {
        public int ArtistId { get; set; }
        public int? AlbumId { get; set; }
        public int? SongId { get; set; }
        public string ImagePath { get; set; }
    }
}
