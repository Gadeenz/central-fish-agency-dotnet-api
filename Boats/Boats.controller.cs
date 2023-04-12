using Microsoft.AspNetCore.Mvc;

namespace central_fish_agency_dotnet.Boats.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoatsController : ControllerBase
    {

        private readonly IBoats _boatsService;

        public BoatsController(IBoats boatsService)
        {
            _boatsService = boatsService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetBoatsResponseDto>>> GetOne(int id)
        {
            return Ok(await _boatsService.GetBoatById(id));
        }

        [HttpGet("getAll")]
        public async Task<ActionResult<ServiceResponse<List<GetBoatsResponseDto>>>> Get()
        {
            return Ok(await _boatsService.GetAllBoats());
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetBoatsResponseDto>>>> AddBoat(AddBoatRequestDto newBoat)
        {
            return Ok(await _boatsService.AddBoat(newBoat));
        }
    }
}