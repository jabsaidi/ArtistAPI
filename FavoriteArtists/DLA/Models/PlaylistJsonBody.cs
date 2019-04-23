using System.Collections.Generic;

namespace FavoriteArtists.DLA.Models
{
    public class PlaylistJsonBody
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<SongJsonBody> songs = new List<SongJsonBody>();

        public Playlist ConvertToPlaylist(PlaylistJsonBody body)
        {
            SongJsonBody songbody = new SongJsonBody();
            List<Song> convertedSongs = new List<Song>();

            foreach (var song in body.songs)
            {
                convertedSongs.Add(songbody.ConvertToSong(song));
            }

            Playlist playlist = new Playlist()
            {
                Name = body.name,
                Songs = convertedSongs,
            };
            return playlist;
        }
    }
}