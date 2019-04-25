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

        public AlbumsController(IAlbumRepo albumRepo, IAlbumSongRepo albumSongRepo)
        {
            _albumRepo = albumRepo;
            _albumSongRepo = albumSongRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var albums = _albumRepo.GetAll();

            foreach (var album in albums)
                album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);
            return Ok(albums);
        }

        [HttpGet("name/{name}", Name = "Get album by name")]
        public IActionResult GetAlbumByName(string name)
        {
            name = name.FirstCharToUpper();

            Album album = _albumRepo.GetAlbumByName(name);

            if (album == null)
                return NotFound();
            album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);
            return Ok(album);
        }

        [HttpGet("{album}/{song}", Name = "Get Song in Album")]
        public IActionResult GetSongByAlbum(string albumName, string songName)
        {
            songName = songName.FirstCharToUpper();
            albumName = albumName.FirstCharToUpper();

            Album album = _albumRepo.GetAlbumByName(albumName);
            album.Songs = _albumSongRepo.GetSongsByAlbumId(album.Id);

            Song _song = _albumRepo.GetSongFromAlbum(album, songName);

            if (_song.Name == null)
                return NotFound();
            return Ok(_song);
        }

        [HttpGet("{id}", Name = "Get album by Id")]
        public IActionResult GetById(int id)
        {
            Album album = _albumRepo.GetById(id);
            if (album == null)
                return NotFound();
            return Ok(album);
        }
    }
}
