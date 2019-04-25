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
    }
}
