using LystfiskerPortalen.Interfaces;
using LystfiskerPortalen.Models;
using LystfiskerPortalen.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace LystfiskerPortalen.Controllers
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
        public async Task<ActionResult> GetAll() 
        {
            var Catches = await _catchRepository.GetAllAsync();
            if (Catches == null)
            {
                Console.WriteLine("DebugLine24");
                return NotFound(); // Returns NotFound 404 error code if list is null
            }
            return Ok(Catches);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] Catch _catch) 
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest();
            }
            await _catchRepository.AddAsync(_catch);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id) 
        {
            if (id <= 0) return BadRequest(); // id needs to be bigger than 0.
            await _catchRepository.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            if (id <= 0) return BadRequest(); // id needs to be bigger than 0.
            var existingCatch = await _catchRepository.GetByIdAsync(id);
            return Ok(existingCatch); // Returns Ok with the UserPost found by the Id
        }
    }
}
