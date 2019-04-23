using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Models
{
    public class ArtistJsonBody
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string IsGroup { get; set; }
        public string Style { get; set; }
        public string Description { get; set; }

        public Artist GenerateTemplate(ArtistJsonBody body)
        {
            Artist newArtist = new Artist()
            {
                Name = body.Name,
                Style = body.Style,
                Description = body.Description,
                IsGroup = Convert.ToBoolean(body.IsGroup),
            };
            return newArtist;
        }
    }
}
