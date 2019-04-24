namespace FavoriteArtists.DLA.Models
{
    public class CoverJsonBody
    {
        public int ArtistId { get; set; }
        public int? AlbumId { get; set; }
        public int? SongId { get; set; }
        public int? PlayListId { get; set; }
        public string ImagePath { get; set; }

        public Cover ConvertToCover(CoverJsonBody body)
        {
            Cover cover = new Cover()
            {
                AlbumId = body.AlbumId,
                ArtistId = body.ArtistId,
                ImagePath = body.ImagePath,
                PlayListId = body.PlayListId,
                SongId =  body.SongId
            };
            return cover;
        }
    }
}
