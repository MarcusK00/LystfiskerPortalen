using LystfiskerPortalenAPI.Interfaces;
using LystfiskerPortalenAPI.Persistence;
using LystfiskerPortalenShared.Models;
using Microsoft.AspNetCore.Mvc;

namespace LystfiskerPortalenAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatchController : ControllerBase
    {
        private readonly ICatchRepository _catchRepository;
        public CatchController(ICatchRepository catchRepository) // Dependency injected from Program.cs;
        {
            _catchRepository = catchRepository;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll() // Endpoint: "localhost:7114/api/catches/getall"
        {
            var catchPosts = await _catchRepository.GetAllAsync();
            if (catchPosts == null)
            {
                Console.WriteLine("DebugLine24");
                return NotFound(); // Returns NotFound 404 error code if list is null
            }
            return Ok(catchPosts);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] Catch userCatch) // Endpoint: "localhost:7114/api/catches"
        {
            if (!ModelState.IsValid) // Checks if model state is valid for the userPost
            {
                return BadRequest();
            }
            await _catchRepository.AddAsync(userCatch);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) // Endpoint "localhost:7114/api/catches/{id}"
        {
            if (id <= 0) return BadRequest(); // id needs to be bigger than 0.
            await _catchRepository.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id) // Endpoint "localhost:7114/api/catches/{id}"
        {
            if (id <= 0) return BadRequest(); // id needs to be bigger than 0.
            var existingCatch = await _catchRepository.GetByIdAsync(id);
            return Ok(existingCatch); // Returns Ok with the UserPost found by the Id
        }
    }
}
