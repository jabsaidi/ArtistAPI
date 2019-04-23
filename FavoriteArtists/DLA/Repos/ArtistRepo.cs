using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using FavoriteArtists.DLA.Models;
using FavoriteArtists.Extensions;
using System.Collections.Generic;

namespace FavoriteArtists.DLA.Repos
{
    public class ArtistRepo : IArtistRepo
    {
        private IAlbumSongRepo _albumSongRepo;
        private IArtistAlbumRepo _artistAlbumRepo;
        private static List<Artist> _db = new List<Artist>();

        public ArtistRepo(IArtistAlbumRepo artistAlbumRepo, IAlbumSongRepo albumSongRepo)
        {
            if (_db.Count == 0)
                GenerateData();

            _albumSongRepo = albumSongRepo;
            _artistAlbumRepo = artistAlbumRepo;
        }

        public Artist Create(Artist newArtist)
        {
            newArtist.Name = newArtist.Name.FirstCharToUpper();
            _db.Add(newArtist);
            return newArtist;
        }

        public Artist Delete(int id)
        {
            var toBeDelete = _db.FirstOrDefault(a => a.Id == id);
            if (toBeDelete == null)
                return null;
            _db.Remove(toBeDelete);
            return toBeDelete;
        }

        public void GenerateData()
        {
            _db.Add(new Artist() { Id = 1, Name = "Travis Scott", IsGroup = false, Style="His own", Description="GOAT. No cap."});
            _db.Add(new Artist() { Id = 2, Name = "Pnl", IsGroup = true, Style = "Cloud Rap", Description = "French cloud rapers" });
            _db.Add(new Artist() { Id = 3, Name = "Brayden & $erna", IsGroup = true, Style = "Hip-Hop", Description = "Upcoming artists from Sherbrooke City." });
            _db.Add(new Artist() { Id = 4, Name = "DISIZ", IsGroup = false, Style = "Rap", Description = "Un daron du rap francais." });
            _db.Add(new Artist() { Id = 5, Name = "Chris Brown", IsGroup = false, Style = "R&B", Description = "Greatest overall artist of all time, but also the most hated of all time." });
            _db.Add(new Artist() { Id = 6, Name = "Dinos", IsGroup = false, Style = "Rap", Description = "Jeune rapeur francais. PUNCHLINES!" });
        }
        public List<Artist> GetAll()
        {
            // Circular dependency error
            foreach (var artist in _db)
            {
                artist.Albums = _artistAlbumRepo.GetAlbumsByArtistId(artist.Id);
                foreach (var album in artist.Albums)
                    album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);
            }
            return _db;
        }

        public Artist GetArtistById(int id)
        {
            var artist = _db.SingleOrDefault(a => a.Id == id);
            return artist;
        }

        public Artist GetArtistByName(string name)
        {
            name = name.FirstCharToUpper();
            var artist = _db.FirstOrDefault(a => a.Name == name);
            return artist;
        }

        public List<Artist> GetGroups()
        {
            var allArtists = GetAll();
            var groups = new List<Artist>();

            foreach(var artist in allArtists)
            {
                if (artist.IsGroup == true)
                    groups.Add(artist);
            }
            return groups;
        }
         
        public List<Artist> GetRapers()
        {
            var allArtists = GetAll();
            var rappers = new List<Artist>();
            foreach(var artist in allArtists)
            {
                if (artist.Style == "Rap" || artist.Style == "Hip-Hop")
                    rappers.Add(artist);
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
