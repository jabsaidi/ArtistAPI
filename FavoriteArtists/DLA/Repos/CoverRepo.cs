﻿using System.Linq;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public class CoverRepo : ICoverRepo
    {
        private static int startUp = 0;
        private static List<Cover> _covers = new List<Cover>();

        public CoverRepo()
        {
            startUp++;
            if(startUp == 1)
                _covers = DataGenerator.GenerateCovers();
        }

        public Cover Create(Cover cover)
        {
            if (cover != null)
                _covers.Add(cover);
            return cover;
        }

        public List<Cover> GetAll()
        {
            return _covers;
        }

        public int GetArtistProfileCoverByArtistId(int id)
        {
            var cover = _covers.FirstOrDefault(c => c.ArtistId == id && c.IsProfilePicture == true);
            if (cover == null)
                return 0;
            return cover.Id;
        }

        public int GetCoverByAlbumId(int id)
        {
            var cover = _covers.FirstOrDefault(c => c.AlbumId == id);
            if (cover == null)
                return 0;
            return cover.Id;
        }

        public Cover GetById(int id)
        {
            return _covers.FirstOrDefault(c => c.Id == id);
        }

        public int GetNextId()
        {
            return _covers.Count + 1;
        }

        public List<Cover> GetProfileCovers()
        {
            var profileCovers = _covers.Where(c => c.IsProfilePicture == true).ToList();
            return profileCovers;
        }

        public Cover Update(Cover updatedCover)
        {
            var toUpdate = GetById(updatedCover.Id);
            if (toUpdate == null)
                return null;

            toUpdate.SongId = updatedCover.SongId;
            toUpdate.AlbumId = updatedCover.AlbumId;
            toUpdate.ArtistId = updatedCover.ArtistId;
            toUpdate.ImagePath = updatedCover.ImagePath;
            toUpdate.PlayListId = updatedCover.PlayListId;
            toUpdate.IsProfilePicture = updatedCover.IsProfilePicture;

            return toUpdate;
        }

        public int GetCoverByPlaylistId(int id)
        {
            Cover cover = _covers.FirstOrDefault(c => c.PlayListId == id);
            if (cover == null)
                return 0;
            return cover.Id;
        }

        public bool Delete(int id)
        {
            Cover tobeDeleted = _covers.FirstOrDefault(c => c.Id == id);
            if (tobeDeleted == null)
                return false;
            _covers.Remove(tobeDeleted);
            return true;
        }
    }
}