using System.Linq;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public class SongRepo : ISongRepo
    {
        private static List<Song> _songs = new List<Song>();

        public SongRepo()
        {
            if (_songs.Count == 0)
                DataGenerator.GenerateSongs();
        }

        
        public Song Create(Song newSong)
        {
            if (newSong.Duration != 0 && NotNull(newSong.Name) && newSong.ArtistId != 0)
            {
                _songs.Add(newSong);
                return newSong;
            }
            else
                return null;
        }

        public List<Song> GetAll()
        {
            return _songs;
        }

        public bool NotNull(params string[] inputs)
        {
            bool notNull = true;
            foreach(string input in inputs)
            {
                if(input == null)
                {
                    notNull = false;
                    break;
                }
            }
            return notNull;
        }

        public List<Song> GetSongsByArtistId(int id)
        {
            List<Song> songs = new List<Song>();

            foreach (Song song in _songs)
            {
                if (song.ArtistId == id)
                    songs.Add(song);
            }
            return songs;
        }

        public int GetNextId()
        {
            return _songs.Count + 1;
        }

        public List<Song> GetSongsByAlbumId(int id)
        {
            List<Song> songs = new List<Song>();

            foreach (Song song in _songs)
            {
                if (song.ArtistId == id)
                    songs.Add(song);
                if (song.AlbumId == 0)
                    GetSingles();
            }
            return songs;
        }

        public List<Song> GetSingles()
        {
            var singles = new List<Song>();

            foreach(Song song in _songs)
            {
                if (song.AlbumId == 0)
                    singles.Add(song);
            }
            return singles;
        }
    }
}
