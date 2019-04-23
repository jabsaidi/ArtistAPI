using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Models
{
    public class Playlist : EntityBase
    {
        public string Name { get; set; }
        public List<Song> Songs { get; set; }
        public Cover Cover { get; set; }

        public Playlist()
        {
            Songs = new List<Song>();
        }
    }
}
