using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TravelsFreak.Models.Status;
using TravelsFreak.Repository.IRepository;

namespace TravelFreak.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourPackageController : ControllerBase
    {
        private readonly ITourPackageRepository _TourPackageRepository;

        public TourPackageController(ITourPackageRepository tourPackageRepository)
        {
            _TourPackageRepository = tourPackageRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _TourPackageRepository.GetAll());
        }

        [HttpGet("{TourPackageId}")]
        public async Task<IActionResult> Get(int? TourPackageId)
        {
            if(TourPackageId == 0)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Invalid Id",
                    StatusCode = StatusCodes.Status400BadRequest
                });
            }

            var tourpackage = await _TourPackageRepository.Get(TourPackageId.Value);
            if(tourpackage == null)
            {
                return BadRequest(new ErrorModelDTO()
                {
                    ErrorMessage = "Not Found",
                    StatusCode = StatusCodes.Status404NotFound
                });
            }

            return Ok(tourpackage);
        }
    }
}
