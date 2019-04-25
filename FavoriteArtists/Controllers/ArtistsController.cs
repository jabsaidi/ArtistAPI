using System;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using FavoriteArtists.DLA.Repos;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;

namespace FavoriteArtists.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistsController : ControllerBase
    {
        private IArtistRepo _artistRepo;

        public ArtistsController(IArtistRepo artistRepo)
        {
            _artistRepo = artistRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Artist> artists = _artistRepo.GetAll();
            if (artists == null)
                return NotFound();
            return Ok(artists);
        }

        [HttpPost]
        public IActionResult Create(ArtistJsonBody body)
        {
            Artist newArtist = body.GenerateTemplate(body);
            newArtist.Id = _artistRepo.GetNextId();

            Artist artist = _artistRepo.Create(newArtist);
            if (artist == null)
                return BadRequest();
            return Ok(artist);
        }

        [HttpGet("{id}", Name = "Get artist by id")]
        public IActionResult GetById(int id)
        {
            Artist artist = _artistRepo.GetArtistById(id);
            if (artist == null)
                return NotFound();
            return Ok(artist);
        }

        [HttpDelete("{id}", Name ="Delete artist by id")]
        public IActionResult Delete(int id)
        {
            bool toBeDeleted = _artistRepo.Delete(id);
            if (toBeDeleted == false)
                return BadRequest($"Id {id} does not exist.");
            return Ok(toBeDeleted);
        }

        [HttpPut("{id}", Name = "Update artist by id")]
        public IActionResult Modify(int id, ArtistJsonBody body)
        {
            Artist toBeModified = body.GenerateTemplate(body);
            toBeModified.Id = id;

            Artist modified = _artistRepo.ModifyArtist(toBeModified);
            if (modified == null)
                return BadRequest($"Id {id} does not exist.");
            return Ok(modified);
        }

        [HttpGet("groups/", Name ="Get groups")]
        public IActionResult GetGroups()
        {
            List <Artist> groups = _artistRepo.GetGroups();
            return Ok(groups);
        }

        [HttpGet("rapers/", Name ="Get rapers")]
        public IActionResult GetRapers()
        {
            var rapers = _artistRepo.GetRapers();
            return Ok(rapers);
        }

        [HttpGet("name/{name}", Name ="Get by Name")]
        public IActionResult GetByName(string name)
        {
            var artist = _artistRepo.GetArtistByName(name);
            if (artist == null)
                return NotFound();
            return Ok(artist);
        }
    }
}
