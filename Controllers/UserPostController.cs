using LystfiskerPortalen.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using LystfiskerPortalen.Models;

namespace LystfiskerPortalen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPostController : ControllerBase
    {
        private readonly IUserPostRepository _userPostRepository;
        public UserPostController(IUserPostRepository userPostRepository) // Dependency injected from Program.cs; Dependency still need implementation
        {
            _userPostRepository = userPostRepository;
        }

        [HttpGet("getall")]
        public async Task<ActionResult> GetAll() // Endpoint: "localhost:7114/api/userpost/getall"
        {
            var userPosts = await _userPostRepository.GetAllAsync();
            if (userPosts == null)
            {
                Console.WriteLine("DebugLine24");
                return NotFound(); // Returns NotFound 404 error code if list is null
            }
            return Ok(userPosts);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromForm] UserPost userPost) // Endpoint: "localhost:7114/api/userpost/post"
        {
            if (!ModelState.IsValid) // Checks if model state is valid for the userPost
            {
                return BadRequest();
            }
            await _userPostRepository.AddAsync(userPost);
            return Ok();
        }

        [HttpDelete("{id}")] 
        public async  Task<ActionResult> Delete(int id) // Endpoint "localhost:7114/api/userpost/delete/{id}"
        {
            if (id <= 0) return BadRequest(); // id needs to be bigger than 0.
            await _userPostRepository.DeleteAsync(id);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id) // Endpoint "localhost:7114/api/userpost/getbyid/{id}"
        {
            if (id <= 0) return BadRequest(); // id needs to be bigger than 0.
            var existingUserPost = await _userPostRepository.GetByIdAsync(id);
            return Ok(existingUserPost); // Returns Ok with the UserPost found by the Id
        }




    } 
}
