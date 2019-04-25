using System.Linq;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

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
            var profilesCovers = new List<Cover>();
            foreach (var cover in _covers)
            {
                if (cover.IsProfilePicture == true)
                    profilesCovers.Add(cover);
            }
            return profilesCovers;
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
    }
}