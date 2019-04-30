using System.Collections.Generic;
using System.Linq;

namespace FavoriteArtists.DLA.Models
{
    public class PlaylistJsonBody
    {
        public string id { get; set; }
        public string name { get; set; }
        public int coverId { get; set; }

        public List<SongJsonBody> songs = new List<SongJsonBody>();

        public Playlist ConvertToPlaylist(PlaylistJsonBody body)
        {
            SongJsonBody songbody = new SongJsonBody();
            List<Song> convertedSongs = body.songs.Select(song => songbody.ConvertToSong(song)).ToList();

            Playlist playlist = new Playlist()
            {
                Name = body.name,
                Songs = convertedSongs,
                CoverId = body.coverId
            };
            return playlist;
        }
    }
}