using Microsoft.AspNetCore.Mvc;
using FavoriteArtists.DLA.Repos;
using FavoriteArtists.DLA.Models;

namespace FavoriteArtists.Controllers
{
    [Route("api/covers")]
    [ApiController]
    public class CoverController : Controller
    {
        private readonly ICoverRepo _coverRepo;
        private readonly IBaseRepo<Cover> _baseRepo; 

        public CoverController(ICoverRepo coverRepo, IBaseRepo<Cover> baseRepo)
        {
            _baseRepo = baseRepo;
            _coverRepo = coverRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var covers = _baseRepo.GetAll();
            return Ok(covers);
        }

        [HttpGet("{id}", Name = "Get by Id")]
        public IActionResult GetById(int id)
        {
            Cover cover = _baseRepo.GetById(id);
            if (cover == null)
                return NotFound();
            return Ok(cover);
        }

        [HttpPost("create/")]
        public IActionResult Create(CoverJsonBody body)
        {
            Cover toCreate = body.ConvertToCover(body);
            toCreate.Id = _baseRepo.GetNextId();

            var created = _baseRepo.Create(toCreate);
            if (created == null)
                return BadRequest();
            return Ok(created);
        }

        [HttpGet("profile/")]
        public IActionResult GetProfileCovers()
        {
            var covers = _coverRepo.GetProfileCovers();
            return Ok(covers);
        }

        [HttpPut("update/{id}")]
        public IActionResult Modify(int id, CoverJsonBody body)
        {
            var updatedCover = body.ConvertToCover(body);
            updatedCover.Id = id;

            var updated = _baseRepo.Update(updatedCover);
            if (updated == null)
                return BadRequest();
            return Ok(updated);
        }
    }
}