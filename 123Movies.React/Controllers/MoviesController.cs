using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Movies.Core.Models;
using Movies.Core.Service.Interfaces;
using System.Threading.Tasks;

namespace Movies.React.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MoviesController : ControllerBase
    {
        private readonly IMoviesService _moviesService;
        public MoviesController(IMoviesService moviesService)
        {
            _moviesService = moviesService;
        }

        [AllowAnonymous, HttpGet("all")]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await _moviesService.GetAllAsync();
            return Ok(new { result });
        }
    }
}