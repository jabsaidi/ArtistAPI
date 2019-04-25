using FavoriteArtists.DLA.Models;
using FavoriteArtists.Extensions;
using FavoriteArtists.Helpers;
using System.Collections.Generic;
using System.Linq;

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
                song.CoverId = GetSongCoverByAlbumId(song.AlbumId);
            return _songs;
        }

        public List<Song> GetSongsByArtistId(int id)
        {
            List<Song> songs = _songs.Where(s => s.ArtistId == id).Select(s =>
            {
                s.CoverId = GetSongCoverByAlbumId(s.AlbumId);
                return s;
            }).ToList();
            return songs;
        }

        public int GetNextId()
        {
            return _songs.Count + 1;
        }

        public List<Song> GetSongsByAlbumId(int id)
        {
            List<Song> songs = _songs.Where(s => s.AlbumId == id).Select(song =>
            {
                song.CoverId = GetSongCoverByAlbumId(song.AlbumId);
                return song;
            }).ToList();
            return songs;
        }

        public int GetSongCoverByAlbumId(int id)
        {
            return _songCoverRepo.GetSongCoverByAlbumId(id);
        }

        public Song GetById(int id)
        {
            Song song = _songs.FirstOrDefault(s => s.Id == id);
            song.CoverId = _songCoverRepo.GetSongCoverByAlbumId(song.AlbumId);
            return song;
        }

        public List<Song> GetSongsByName(string name)
        {
            name = name.FirstCharToUpper();

            var sameNameSongs = _songs.Where(s => s.Name == name).Select(song =>
            {
                song.CoverId = GetSongCoverByAlbumId(song.AlbumId);
                return song;
            }).ToList();
            return sameNameSongs;
        }

        public Song UpdateSong(Song song)
        {
            Song originalSong = _songs.FirstOrDefault(s => s.Id == song.Id);
            if (song == null)
                return null;

            originalSong.Name = song.Name;
            originalSong.AlbumId = song.AlbumId;
            originalSong.CoverId = song.CoverId;
            originalSong.ArtistId = song.ArtistId;
            originalSong.Duration = song.Duration;

            return originalSong;
        }
    }
}
