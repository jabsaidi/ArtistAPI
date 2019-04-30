using System.Linq;
using FavoriteArtists.Helpers;
using FavoriteArtists.DLA.Models;
using FavoriteArtists.Extensions;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public class SongRepo : ISongRepo
    {
        private static int _startup = 0;
        private readonly ISongCoverRepo _songCoverRepo;
        private static List<Song> _songs = new List<Song>();

        public SongRepo(ISongCoverRepo songCoverRepo)
        {
            _startup++;
            if (_startup == 1)
                _songs = DataGenerator.GenerateSongs();
            _songCoverRepo = songCoverRepo;
        }

        public Song Create(Song newSong)
        {
            if (newSong.Duration != 0 && Validations.NotNull(newSong.Name) && newSong.ArtistId != 0)
            {
                newSong.Id = GetNextId();
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
            List<Song> songs = _songs.Where(s => s.AlbumId == id && s.IsActive == true).Select(song =>
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
            if (song == null)
                return null;
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

        public Song Update(Song song)
        {
            Song originalSong = _songs.FirstOrDefault(s => s.Id == song.Id);
            if (originalSong == null)
                return null;

            originalSong.IsActive = true;
            originalSong.Name = song.Name;
            originalSong.AlbumId = song.AlbumId;
            originalSong.CoverId = song.CoverId;
            originalSong.ArtistId = song.ArtistId;
            originalSong.Duration = song.Duration;

            return originalSong;
        }

        public bool SongExists(Song song)
        {
            Song existingSong = _songs.FirstOrDefault(s => s.Id == song.Id);
            if (existingSong != null)
                return true;
            return false;
        }

        public bool Delete(int id)
        {
            Song tobeDeleted = _songs.FirstOrDefault(s => s.Id == id);
            if (tobeDeleted == null)
                return false;

            _songs.Remove(tobeDeleted);
            return true;
        }
    }
}