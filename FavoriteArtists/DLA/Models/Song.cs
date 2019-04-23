namespace FavoriteArtists.DLA.Models
{
    public class Song : EntityBase
    {
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public int? AlbumId { get; set; }
        public double Duration { get; set; }
        public Cover Cover { get; set; }
    }
}
