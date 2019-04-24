using FavoriteArtists.DLA.Models;
using FavoriteArtists.DLA.Repos;
using Microsoft.AspNetCore.Mvc;

namespace FavoriteArtists.Controllers
{
    [Route("api/covers")]
    [ApiController]
    public class CoverController : Controller
    {
        private readonly ICoverRepo _coverRepo;

        public CoverController(ICoverRepo coverRepo)
        {
            _coverRepo = coverRepo;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var covers = _coverRepo.GetAll();

            return Ok(covers);
        }

        [HttpPost("create/")]
        public IActionResult Create(CoverJsonBody body)
        {
            Cover toCreate = body.ConvertToCover(body);
            toCreate.Id = _coverRepo.GetNextId();

            var created = _coverRepo.Create(toCreate);
            if (created == null)
                return BadRequest();
            return Ok(created);
        }
    }
}