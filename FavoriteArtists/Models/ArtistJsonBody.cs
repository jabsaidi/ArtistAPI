using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Models
{
    public class ArtistJsonBody
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsGroup { get; set; }
        public string Style { get; set; }
        public string Description { get; set; }
        public List<AlbumJsonBody> Albums { get; set; }

        public Artist GenerateTemplate(ArtistJsonBody body)
        {
            List<Album> albums = body.Albums.Select(album =>
            {
                Album converted = album.ConvertToAlbum(album);
                return converted;
            }).ToList();

            Artist newArtist = new Artist()
            {
                Name = body.Name,
                Style = body.Style,
                Description = body.Description,
                IsGroup = body.IsGroup,
                Albums = albums
            };
            return newArtist;
        }
    }
}
