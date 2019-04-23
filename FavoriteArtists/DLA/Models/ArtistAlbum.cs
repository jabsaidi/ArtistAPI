using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Models
{
    public class ArtistAlbum : EntityBase
    {
        public int AlbumId { get; set; }
        public int ArtistId { get; set; }
    }
}
