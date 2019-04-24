using FavoriteArtists.DLA.Models;
using FavoriteArtists.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace FavoriteArtists.DLA.Repos
{
    public interface IArtistCoverRepo
    {
        int GetProfileCoverByArtistId(int id);
    }

    public class ArtistCoverRepo : IArtistCoverRepo
    {
        private readonly ICoverRepo _coverRepo;
        public ArtistCoverRepo(ICoverRepo coverRepo)
        {
            _coverRepo = coverRepo;
        }
        public int GetProfileCoverByArtistId(int id)
        {
            return _coverRepo.GetArtistProfileCoverByArtistId(id);
        }
    }

    public class ArtistRepo : IArtistRepo
    {
        private readonly IArtistAlbumRepo _artistAlbumRepo;
        private readonly IArtistCoverRepo _artistCoverRepo;
        private static List<Artist> _db = new List<Artist>();

        public ArtistRepo(IArtistAlbumRepo artistAlbumRepo, IArtistCoverRepo artistCoverRepo)
        {
            if (_db.Count == 0)
                _db = DataGenerator.GenerateArtists();

            _artistAlbumRepo = artistAlbumRepo;
            _artistCoverRepo = artistCoverRepo;
        }

        public Artist Create(Artist newArtist)
        {
            newArtist.Name = newArtist.Name.FirstCharToUpper();
            _db.Add(newArtist);
            return newArtist;
        }

        public bool Delete(int id)
        {
            var toBeDelete = _db.FirstOrDefault(a => a.Id == id);
            if (toBeDelete == null)
                return false;
            _db.Remove(toBeDelete);
            return true;
        }

        public List<Artist> GetAll()
        {
            // Circular dependency error
            foreach (var artist in _db)
            {
                artist.Albums = _artistAlbumRepo.GetAlbumsByArtistId(artist.Id);
                artist.CoverId = _artistCoverRepo.GetProfileCoverByArtistId(artist.Id);
            }
            return _db;
        }

        public Artist GetArtistById(int id)
        {
            var artist = _db.SingleOrDefault(a => a.Id == id);
            artist.CoverId = _artistCoverRepo.GetProfileCoverByArtistId(artist.Id);
            return artist;
        }

        public Artist GetArtistByName(string name)
        {
            name = name.FirstCharToUpper();
            var artist = _db.FirstOrDefault(a => a.Name == name);
            artist.CoverId = _artistCoverRepo.GetProfileCoverByArtistId(artist.Id);
            return artist;
        }

        public List<Artist> GetGroups()
        {
            var allArtists = GetAll();
            var groups = new List<Artist>();

            foreach (var artist in allArtists)
            {
                if (artist.IsGroup == true)
                {
                    artist.CoverId = _artistCoverRepo.GetProfileCoverByArtistId(artist.Id);
                    groups.Add(artist);
                }
            }
            return groups;
        }

        public List<Artist> GetRapers()
        {
            var allArtists = GetAll();
            var rappers = new List<Artist>();
            foreach (var artist in allArtists)
            {
                if (artist.Style == "Rap" || artist.Style == "Hip-Hop")
                {
                    artist.CoverId = _artistCoverRepo.GetProfileCoverByArtistId(artist.Id);
                    rappers.Add(artist);
                }
            }
            return rappers;
        }

        public Artist ModifyArtist(Artist modifiedArtist)
        {
            var toBeModified = GetArtistById(modifiedArtist.Id);
            if (toBeModified == null)
                return null;

            toBeModified.Name = modifiedArtist.Name;
            toBeModified.Style = modifiedArtist.Style;
            toBeModified.IsGroup = modifiedArtist.IsGroup;
            toBeModified.Description = modifiedArtist.Description;

            return toBeModified;
        }

        public int GetNextId()
        {
            return _db.Count + 1;
        }
    }
}
