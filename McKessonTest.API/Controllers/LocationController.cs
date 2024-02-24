using AutoMapper;
using McKessonTest.API.Models;
using McKessonTest.API.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace McKessonTest.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        public readonly ILocationService _locationService;
        private readonly IMapper _mapper;
        public LocationController(ILocationService locationService, IMapper mapper)
        {
            _locationService = locationService; 
            _mapper = mapper;
        }
        [HttpGet]
        [Route("All", Name = "GetAllLocations")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAsync()
        {
            var result =await _locationService.GetLocationsAsync();
            var retModel = _mapper.Map<List<LocationModel>>(result);
            //throw new Exception("Testing exception."); //for testing exception handling
            return Ok(retModel);
        }
    }
}
