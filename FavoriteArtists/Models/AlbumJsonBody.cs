using System.Collections.Generic;
using System.Linq;

namespace FavoriteArtists.DLA.Models
{
    public class AlbumJsonBody
    {
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public List<SongJsonBody> Songs { get; set; }
        public int CoverId { get; set; }

        public Album ConvertToAlbum(AlbumJsonBody body)
        {
            List<Song> songs = body.Songs.Select(song =>
            {
                Song converted = song.ConvertToSong(song);
                return converted;
            }).ToList();

            Album album = new Album()
            {
                Songs = songs,
                Name = body.Name,
                CoverId = body.CoverId,
                ArtistId = body.ArtistId
            };
            return album;
        }
    }
}
