using Microsoft.AspNetCore.Mvc;
using FavoriteArtists.DLA.Repos;
using FavoriteArtists.DLA.Models;

namespace FavoriteArtists.Controllers
{
    [Route("api/playlists")]
    [ApiController]
    public class PlaylistsController : ControllerBase
    {
        private IPlaylistRepo _playlistRepo;

        public PlaylistsController(IPlaylistRepo playlistRepo)
        {
            _playlistRepo = playlistRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var playlists = _playlistRepo.GetAllPlaylists();
            return Ok(playlists);
        }

        [HttpGet("{id}", Name = "Get playlist by Id")]
        public IActionResult GetById(int id)
        {
            var playlist = _playlistRepo.GetPlaylistById(id);
            if (playlist == null)
                return NotFound();
            return Ok(playlist);
        }

        [HttpPost("create/")]
        public IActionResult Create(PlaylistJsonBody body)
        {
            var toCreate = body.ConvertToPlaylist(body);
            toCreate.Id = _playlistRepo.GetNextId();
            var created = _playlistRepo.Create(toCreate);

            if (created == null)
                return BadRequest();
            return Ok(created);
        }
    }
}