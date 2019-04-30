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
        private readonly IBaseRepo<Playlist> _baseRepo;

        public PlaylistsController(IPlaylistRepo playlistRepo, IBaseRepo<Playlist> baseRepo)
        {
            _baseRepo = baseRepo;
            _playlistRepo = playlistRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var playlists = _baseRepo.GetAll();
            return Ok(playlists);
        }

        [HttpGet("{id}", Name = "Get playlist by Id")]
        public IActionResult GetById(int id)
        {
            var playlist = _baseRepo.GetById(id);
            if (playlist == null)
                return NotFound();
            return Ok(playlist);
        }

        [HttpPost("create/")]
        public IActionResult Create(PlaylistJsonBody body)
        {
            var toCreate = body.ConvertToPlaylist(body);
            toCreate.Id = _baseRepo.GetNextId();
            var created = _baseRepo.Create(toCreate);

            if (created == null)
                return BadRequest();
            return Ok(created);
        }

        [HttpPut("modify/{id}", Name = "Update playlist by id")]
        public IActionResult Update(int id, PlaylistJsonBody body)
        {
            Playlist originalPlaylist = _baseRepo.GetById(id);
            Playlist updateTo = body.ConvertToPlaylist(body);
            updateTo.Id = id;
            if (updateTo.CoverId == 0)
                updateTo.CoverId = originalPlaylist.CoverId;

            Playlist updated = _baseRepo.Update(updateTo);
            if (updated == null)
                return BadRequest();
            return Ok(updated);
        }

        [HttpGet("name/{name}", Name = "Get playlists by name")]
        public IActionResult GetPlaylistsByName(string name)
        {
            var playlists = _playlistRepo.GetPlaylistsByName(name);
            return Ok(playlists);
        }
    }
}