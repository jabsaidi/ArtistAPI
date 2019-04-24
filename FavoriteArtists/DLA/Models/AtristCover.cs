using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FavoriteArtists.DLA.Models
{
    public class AtristCover : EntityBase
    {
        public int CoverId { get; set; }
        public int ArtistId { get; set; }
    }
}
