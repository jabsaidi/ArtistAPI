using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Models
{
    public class SongJsonBody
    {
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public double Duration { get; set; }
        public int ArtistId { get; set; }
        public int CoverId { get; set; }
        public bool IsActive { get; set; }

        public Song ConvertToSong(SongJsonBody body)
        {
            Song newSong = new Song()
            {
                IsActive = true,
                Name = body.Name,
                AlbumId = body.AlbumId,
                CoverId = body.CoverId,
                ArtistId = body.ArtistId,
                Duration = body.Duration,
            };
            return newSong;
        }
    }
}
