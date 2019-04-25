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

        public SongsController(ISongRepo songRepo)
        {
            _songRepo = songRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var songs = _songRepo.GetAll();
            return Ok(songs);
        }

        [HttpPost("create/")]
        public IActionResult Create(SongJsonBody body)
        {
            Song newSong = body.ConvertToSong(body);
            newSong.Id = _songRepo.GetNextId();

            Song createdSong = _songRepo.Create(newSong);
            if (createdSong == null)
                return BadRequest();
            return Ok(createdSong);
        }

        [HttpGet("{id}", Name = "Get song by id")]
        public IActionResult GetById(int id)
        {
            Song song = _songRepo.GetById(id);
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
            songToUpdate.Id = id;

            Song updatedSong = _songRepo.UpdateSong(songToUpdate);
            if (updatedSong == null)
                return BadRequest();
            return Ok(updatedSong);
        }
    }
}
