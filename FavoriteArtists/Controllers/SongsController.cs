using System;
using System.Linq;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FavoriteArtists.DLA.Repos;
using FavoriteArtists.DLA.Models;
using System.Collections.Generic;
using FavoriteArtists.DLA.Repos.FileRepos;

namespace FavoriteArtists.Controllers
{
    [Route("api/songs")]
    [ApiController]
    public class SongsController : ControllerBase
    {
        private ISongRepo _songRepo;
        private readonly IBaseRepo<Song> _baseRepo;

        public SongsController(ISongRepo songRepo, IBaseRepo<Song> baseRepo)
        {
            _baseRepo = baseRepo;
            _songRepo = songRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var songs = _baseRepo.GetAll();
            return Ok(songs);
        }

        [HttpPost("create/")]
        public IActionResult Create(SongJsonBody body)
        {
            Song newSong = body.ConvertToSong(body);
            newSong.Id = _baseRepo.GetNextId();

            Song createdSong = _baseRepo.Create(newSong);
            if (createdSong == null)
                return BadRequest();
            return Ok(createdSong);
        }

        [HttpGet("{id}", Name = "Get song by id")]
        public IActionResult GetById(int id)
        {
            Song song = _baseRepo.GetById(id);
            if (song == null)
                return NotFound();
            return Ok(song);
        }

        [HttpGet("name/{name}", Name = "Get songs with same name")]
        public IActionResult GetSongsByName(string name)
        {
            List<Song> songs = _songRepo.GetSongsByName(name);
            return Ok(songs);
        }

        [HttpPut("update/{id}", Name = "Update song by id")]
        public IActionResult UpdateSongById(int id, SongJsonBody body)
        {
            Song songToUpdate = body.ConvertToSong(body);

            Song updatedSong = _baseRepo.Update(songToUpdate);
            if (updatedSong == null)
                return BadRequest();
            return Ok(updatedSong);
        }

        [HttpDelete("delete/{id}", Name = "Delete song by Id")]
        public IActionResult Delete(int id)
        {
            bool deleted = _baseRepo.Delete(id);
            if (!deleted)
                return BadRequest();
            return Ok();
        }
    }
}
