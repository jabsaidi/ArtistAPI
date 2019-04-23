using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Models
{
    public class Artist : EntityBase
    {
        public string Name { get; set; }
        public bool IsGroup { get; set; }
        public string Style { get; set; }
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
        public Cover Cover { get; set; }

        public Artist()
        {
            Albums = new List<Album>();
        }
    }
}