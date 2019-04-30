using FavoriteArtists.DLA.Models;
using FavoriteArtists.Extensions;
using System.Collections.Generic;
using System.Linq;

namespace FavoriteArtists.DLA.Repos
{
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
            foreach (var artist in _db)
            {
                artist.Albums = _artistAlbumRepo.GetAlbumsByArtistId(artist.Id);
                artist.CoverId = _artistCoverRepo.GetProfileCoverByArtistId(artist.Id);
            }
            return _db;
        }

        public Artist GetById(int id)
        {
            var artist = _db.FirstOrDefault(a => a.Id == id);
            artist.Albums = _artistAlbumRepo.GetAlbumsByArtistId(artist.Id);
            artist.CoverId = _artistCoverRepo.GetProfileCoverByArtistId(artist.Id);
            return artist;
        }

        public Artist GetArtistByName(string name)
        {
            name = name.FirstCharToUpper();
            var artist = _db.FirstOrDefault(a => a.Name == name);
            if (artist == null)
                return null;
            artist.CoverId = _artistCoverRepo.GetProfileCoverByArtistId(artist.Id);
            return artist;
        }

        public List<Artist> GetGroups()
        {
            var groups = _db.Where(a => a.IsGroup == true).Select(artist =>
            {
                artist.Albums = _artistAlbumRepo.GetAlbumsByArtistId(artist.Id);
                artist.CoverId = _artistCoverRepo.GetProfileCoverByArtistId(artist.Id);
                return artist;
            }).ToList();

            return groups;
        }

        public List<Artist> GetRapers()
        {
            var rappers = _db.Where(a => a.Style == "Rap" || a.Style == "Hip-Hop").Select(artist =>
            {
                artist.Albums = _artistAlbumRepo.GetAlbumsByArtistId(artist.Id);
                artist.CoverId = _artistCoverRepo.GetProfileCoverByArtistId(artist.Id);
                return artist;
            }).ToList();

            return rappers;
        }

        public Artist Update(Artist modifiedArtist)
        {
            var toBeModified = GetById(modifiedArtist.Id);
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

        public List<Artist> GetArtistsByName(string name)
        {
            name = name.FirstCharToUpper();

            List<Artist> artists = _db.Where(a => a.Name == name).Select(artist =>
            {
                artist.Albums = _artistAlbumRepo.GetAlbumsByArtistId(artist.Id);
                artist.CoverId = _artistCoverRepo.GetProfileCoverByArtistId(artist.Id);
                return artist;
            }).ToList();

            return artists;
        }
    }
}
