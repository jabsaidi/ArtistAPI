using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FavoriteArtists.DLA.Repos;
using FavoriteArtists.DLA.Models;
using FavoriteArtists.Extensions;
using System.Collections.Generic;

namespace FavoriteArtists.Controllers
{
    [Route("api/albums")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private IAlbumRepo _albumRepo;
        private IAlbumSongRepo _albumSongRepo;
        private readonly IBaseRepo<Album> _baseRepo;

        public AlbumsController(IAlbumRepo albumRepo, IAlbumSongRepo albumSongRepo, IBaseRepo<Album> baseRepo)
        {
            _baseRepo = baseRepo;
            _albumRepo = albumRepo;
            _albumSongRepo = albumSongRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var albums = _baseRepo.GetAll();

            foreach (var album in albums)
                album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);
            return Ok(albums);
        }

        [HttpGet("name/{name}", Name = "Get album by name")]
        public IActionResult GetAlbumByName(string name)
        {
            name = name.FirstCharToUpper();

            List<Album> albums = _albumRepo.GetAlbumsByName(name);

            return Ok(albums);
        }

        [HttpGet("{id}", Name = "Get album by Id")]
        public IActionResult GetById(int id)
        {
            Album album = _baseRepo.GetById(id);
            if (album == null)
                return NotFound();
            return Ok(album);
        }

        [HttpPost("create/", Name = "Create new Album")]
        public IActionResult Create(AlbumJsonBody body)
        {
            Album toCreate = body.ConvertToAlbum(body);
            toCreate.Id = _baseRepo.GetNextId();

            Album created = _baseRepo.Create(toCreate);
            if (created == null)
                return BadRequest();
            return Ok(created);
        }

        [HttpPut("update/{id}", Name = "Update album by Id")]
        public IActionResult Update(int id, AlbumJsonBody body)
        {
            Album updateTo = body.ConvertToAlbum(body);
            updateTo.Id = id;

             Album updated = _baseRepo.Update(updateTo);
            if (updated == null)
                return BadRequest();
            return Ok(updated);
        }

        [HttpDelete("delete/{id}", Name = "Delete album by Id")]
        public IActionResult Delete(int id)
        {
            bool deleted = _baseRepo.Delete(id);
            if (!deleted)
                return BadRequest();
            return Ok();
        }
    }
}
