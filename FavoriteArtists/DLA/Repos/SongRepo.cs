using FavoriteArtists.DLA.Models;
using FavoriteArtists.Helpers;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public class SongRepo : ISongRepo
    {
        private readonly ISongCoverRepo _songCoverRepo;
        private static List<Song> _songs = new List<Song>();

        public SongRepo(ISongCoverRepo songCoverRepo)
        {
            if (_songs.Count == 0)
                _songs = DataGenerator.GenerateSongs();
            _songCoverRepo = songCoverRepo;
        }

        public Song Create(Song newSong)
        {
            if (newSong.Duration != 0 && Validations.NotNull(newSong.Name) && newSong.ArtistId != 0)
            {
                _songs.Add(newSong);
                return newSong;
            }
            else
                return null;
        }

        public List<Song> GetAll()
        {
            foreach (var song in _songs)
            {
                song.CoverId = GetSongCoverByAlbumId(song.AlbumId);
            }
            return _songs;
        }

        public List<Song> GetSongsByArtistId(int id)
        {
            List<Song> songs = new List<Song>();

            foreach (Song song in _songs)
            {
                if (song.ArtistId == id)
                {
                    song.CoverId = GetSongCoverByAlbumId(song.AlbumId);
                    songs.Add(song);
                }
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
                {
                    songs.Add(song);
                    GetSongCoverByAlbumId(song.AlbumId);
                }
                if (song.AlbumId == 0)
                    GetSingles();
            }
            return songs;
        }

        public List<Song> GetSingles()
        {
            var singles = new List<Song>();

            foreach (Song song in _songs)
            {
                if (song.AlbumId == 0)
                    singles.Add(song);
            }
            return singles;
        }

        public int GetSongCoverByAlbumId(int id)
        {
            return _songCoverRepo.GetSongCoverByAlbumId(id);
        }
    }

    public interface ISongCoverRepo
    {
        int GetSongCoverByAlbumId(int id);
    }

    public class SongCoverRepo : ISongCoverRepo
    {
        private readonly ICoverRepo _coverRepo;
        public SongCoverRepo(ICoverRepo coverRepo)
        {
            _coverRepo = coverRepo;
        }

        public int GetSongCoverByAlbumId(int id)
        {
            return _coverRepo.GetCoverByAlbumId(id);
        }
    }
}
