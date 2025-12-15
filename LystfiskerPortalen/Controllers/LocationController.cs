using LystfiskerPortalen.Interfaces;
using LystfiskerPortalen.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace LystfiskerPortalen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationRepository _locationRepository;
        public LocationController(ILocationRepository locationRepository) // Dependency injected from Program.cs;
        {
            _locationRepository = locationRepository;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll() 
        {
            var locations = await _locationRepository.GetAllAsync();
            if (locations == null)
            {
                Console.WriteLine("DebugLine23");
                return NotFound(); // Returns NotFound 404 error code if list is null
            }
            return Ok(locations);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id) 
        {
            if (id <= 0) return BadRequest(); // id needs to be bigger than 0.
            var existingLocation = await _locationRepository.GetByIdAsync(id);
            return Ok(existingLocation); 
        }
    }
}
