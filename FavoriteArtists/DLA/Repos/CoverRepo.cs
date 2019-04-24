using System;
using System.Collections.Generic;
using System.Linq;
using FavoriteArtists.DLA.Models;

namespace FavoriteArtists.DLA.Repos
{
    public class CoverRepo : ICoverRepo
    {
        private static List<Cover> _covers = new List<Cover>();

        public CoverRepo()
        {
            if (_covers.Count == 0)
                _covers = DataGenerator.GenerateCovers();
        }

        public Cover Create(Cover cover)
        {
            if(cover != null)
                _covers.Add(cover);
            return cover;
        }

        public List<Cover> GetAll()
        {
            return _covers;
        }

        public int GetArtistProfileCoverByArtistId(int id)
        {
            var cover = _covers.FirstOrDefault(c => c.ArtistId == id);
            if (cover == null)
                return 0;
            return cover.Id;
        }

        public int GetCoverByAlbumId(int id)
        {
            var cover = _covers.FirstOrDefault(c => c.AlbumId == id);
            return cover.Id;
        }

        public int GetNextId()
        {
            return _covers.Count + 1;
        }
    }
}
