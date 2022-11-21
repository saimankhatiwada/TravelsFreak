using Microsoft.AspNetCore.Mvc;
using TravelsFreak.Models.Status;
using TravelsFreak.Repository.IRepository;

namespace TravelFreak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IBlogRepository _BlogRepository;

        public BlogController(IBlogRepository blogRepository)
        {
            _BlogRepository = blogRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _BlogRepository.GetAll());
        }

        [HttpGet("{BlogId}")]
        public async Task<IActionResult> Get(int? BlogId)
        {
            if (BlogId == 0)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var blog = await _BlogRepository.Get(BlogId.Value);
            if (blog == null)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Not Found",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(blog);
        }
    }
}
