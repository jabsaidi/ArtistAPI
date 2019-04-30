using System.Collections.Generic;

namespace FavoriteArtists.DLA.Models
{
    public class Album : EntityBase
    {
        public string Name { get; set; }
        public int ArtistId { get; set; }
        public List<Song> Songs { get; set; }
        public int CoverId { get; set; }

        public Album()
        {
            Songs = new List<Song>();
        }
    }
}
