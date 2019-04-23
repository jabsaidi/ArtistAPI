using System.Linq;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public class AlbumRepo : IAlbumRepo
    {
        private static List<Album> _albums = new List<Album>();

        public AlbumRepo()
        {
            if (_albums.Count == 0)
                DataGenerator.GenerateAlbum();
        }

        public List<Album> GetAlbumsByArtistId(int id)
        {
            var albums = new List<Album>();
            foreach(var album in _albums)
            {
                if (album.ArtistId == id)
                {
                    if (album.Id == 0)
                    {
                        Album single = CreateSingle(album.ArtistId);
                        albums.Add(single);
                    }
                    albums.Add(album);
                }
            }
            return albums;
        }

        public Album CreateSingle(int artistId)
        {
            Album single = new Album()
            {
                Id = 0,
                ArtistId = artistId,
                Name = "Single"
            };
            return single;
        }

        public List<Album> GetAll()
        {
            return _albums;
        }

        public Album GetAlbumByName(string name)
        {
            return _albums.FirstOrDefault(a=>a.Name == name);
        }

        public Song GetSongFromAlbum(Album album, string song)
        {
            Song foundSong = new Song();
            foreach(Song _song in album.Songs)
            {
                if(_song.Name == song)
                {
                    foundSong = _song;
                    break;
                }
            }
            return foundSong;
        }
    }
}
