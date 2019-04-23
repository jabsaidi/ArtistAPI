using System;
using System.Collections.Generic;
using FavoriteArtists.DLA.Models;

namespace FavoriteArtists.DLA.Repos.FileRepos
{
    public class SongFileRepo : ISongFileRepo
    {
        private readonly object _fileLock = new object();
        private BaseFileRepo _baseFile = new BaseFileRepo("songs.txt");
        private Persistor<Song> _persistor = new Persistor<Song>("songs.txt");

        public SongFileRepo()
        {
            lock (_fileLock)
            {
                _baseFile.InitFile("name", "artistId", "albumId", "duration", "id");
            }
        }

        public Song Create(Song newSong)
        {
            return _persistor.Create(newSong);
        }

        public List<Song> GetAllSongs()
        {
            return _persistor.GetAll();
        }
    }
}
