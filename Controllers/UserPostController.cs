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
        public UserPostController(IUserPostRepository userPostRepository) // Dependency injected from Program.cs // Dependency still need implementation
        {
            _userPostRepository = userPostRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll() // Endpoint: "api/userpost/getalluserposts"
        {
            var userPosts = await _userPostRepository.GetAllAsync();
            if(userPosts == null)
            {
                return NotFound(); // Returns NotFound 404 error code if list is null
            }
            return Ok(userPosts);
        }

        [HttpPost]
        public async Task<ActionResult> Post(UserPost userPost) // Endpoint: "api/userpost/post"
        {
            if (!ModelState.IsValid) // Checks if model state is valid for the userPost
            {
                return BadRequest();
            }
            await _userPostRepository.AddAsync(userPost);
            return Ok();
        }
    }
}
