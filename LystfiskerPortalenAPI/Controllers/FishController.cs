using LystfiskerPortalenShared.Models;
using LystfiskerPortalenAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LystfiskerPortalenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FishController : ControllerBase
    {
        private readonly IFishRepository _fishRepository;
        public FishController(IFishRepository fishRepository) // Dependency injected from Program.cs;
        {
            _fishRepository = fishRepository;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll() // Endpoint: "localhost:7114/api/userpost/getall"
        {
            var userPosts = await _fishRepository.GetAllAsync();
            if (userPosts == null)
            {
                Console.WriteLine("DebugLine24");
                return NotFound(); // Returns NotFound 404 error code if list is null
            }
            return Ok(userPosts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id) // Endpoint "localhost:7114/api/userpost/{id}"
        {
            if (id <= 0) return BadRequest(); // id needs to be bigger than 0.
            var existingUserPost = await _fishRepository.GetByIdAsync(id);
            return Ok(existingUserPost); // Returns Ok with the UserPost found by the Id
        }
    }
}
